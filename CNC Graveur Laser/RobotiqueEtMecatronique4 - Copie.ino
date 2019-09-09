#include<SoftwareSerial.h>

///
/// Pour collecter les données
///
String inputString = "";         // pour récolter les données arrivantes
boolean stringComplete = false; 
String command = "";
bool commandeManuelle = false;

///
/// Pour faire fonctionner le système
///
bool start = false; // Lancement du système



//-------Servomoteur------------------------------------------------


//------------------------------------------------------------------

//-------PontDiviseur-du-Potentiometre-de-la-Consigne-en-Pression---

//Pin sortant du pont diviseur
int pontDiviseur=0;
//Tension en Volts en entree du pont diviseur
int Vcc = 5;
//Valeur de la resistance en Ohms
int R=10000;
//Resistance Maximum du potentiometre en Ohms
int P=20000;

//------------------------------------------------------------------
//-------Interruption-----------------------------------------------

bool reset = false;
bool interruption = true;
bool interruptionConsigne = false;
int interruptPin1 = 2;
int interruptPin2 = 3;

//------------------------------------------------------------------

//Serrage de la Pince-----------------------------------------------

volatile byte serrageEstOk = LOW;
int angle = 20; //position initiale du servo = Pince ouverte

//(la pince serre jusqu'a rencontrer l'objet)

int AnalogPinFsr = 1; //Pin sortant du fsr linéarisé (c'est a dire sortant de l'aop)
double pression = 0; // pression mesurée par le FSR
int precisionServo = 1; // Precision en degré de la pince
double intervalleConsigne = 0.05; //Intervalle de 5%, la pince est en bonne position si la pression est +/- 5% de la pression souhaitée
double pressionSouhaitee = 600;
int pressionInitiale;
double coefficientDirecteur = -1;
int angleDebutSerrage = 0;


//------------------------------------------------------------------

//Bibi bas niveau---------------------------------------------------
//------------------------------------------------------------------

//Bibi bas niveau---------------------------------------------------
uint16_t ReadADC(uint8_t __channel)
{
   ADMUX = (ADMUX & 0xf0) | __channel; // Sélection du Pin
   ADCSRA |= _BV(ADSC);                // Début de conversion
   while(!bit_is_set(ADCSRA,ADIF));    // Loop jusqu'à la fin de la conversion
   ADCSRA |= _BV(ADIF);                // Clear ADIF en lui mettant la valeur à 0

   return(ADC); // Autant convertir directement non ? 
}

void adc_init()
{

  ADCSRA = _BV(ADEN) | _BV(ADPS2) | _BV(ADPS1) | _BV(ADPS0); // Permet les ADC

}


uint8_t Angle(uint16_t _writeAngle){
  OCR1A = map(_writeAngle,0,120,1600,4000);
}
 





void TestReceptionFSR(){
  int debutTest = millis();
  int nombreDePrise = 0;
  int valeurMaxInitiale = 0;
  int angleFinSerrage;
  int pressionFinale;
  int prise;
  //On attend 5s par sûreté
  delay(5000);
  
  //Pendant 1s on test la pression intiale du capteur
  //on fait bouger un peu la pince pour détecter plus tard le début du chagement de pression 
  //C'est pourquoi on se fait un intervalle de confiance [valeurMinInitiale;valeurMaxInitiale] 

  for(int i = 0; i < 10; i ++){
   Angle(5);
    prise = analogRead(AnalogPinFsr);
    pressionInitiale +=  prise;
    delay(200);
    Serial.println(prise);

    if(prise > valeurMaxInitiale){
      valeurMaxInitiale = prise;
              Serial.print("max : ");Serial.println(prise);

    }
     nombreDePrise++;  
     Angle(0);
     delay(200);   
  }
  pressionInitiale /= nombreDePrise;//valeur entre 0 et 1024 moyen sur 1 sec
  Serial.print("pression init : ");Serial.println(pressionInitiale);
      Serial.print("max : ");Serial.println(valeurMaxInitiale);
      valeurMaxInitiale = 300;
  ///On regarde maintenant le début et la fin de serrage selon l'objet placé
  while(analogRead(AnalogPinFsr) <= valeurMaxInitiale && angleDebutSerrage < 120){
    angleDebutSerrage++;
    Angle(angleDebutSerrage);
          Serial.print("on sert : ");Serial.println(analogRead(AnalogPinFsr));

    delay(500);
  }
        Serial.print("angle début : ");Serial.println(angleDebutSerrage);

  if(angleDebutSerrage > 115){
    //On considère qu'il ny a pas d'objet à serrer ou que le montage ne fonctionne pas correctement car le FSR ne renvoit pas de données hors des valeurs initiales
  }
  else{
    angleFinSerrage = angleDebutSerrage;
    int priseFin[5] = {-100,-100,-100,-100,-100};
    //On regarde maintenant la fin du serrage
    //Autrement dis, le serrage maximum que le FSR peut nous renvoyer avant que ce ne soit linéaire par manque de précision du FSR
    prise = analogRead(AnalogPinFsr);
    while(angleFinSerrage < 120  && prise >= (priseFin[angleFinSerrage%5] + valeurMaxInitiale)){
      angleFinSerrage++;
      Angle(angleFinSerrage);
      prise = analogRead(AnalogPinFsr);
      priseFin[angleFinSerrage%5] = prise;   
      delay(50);   
    }
    Angle(angleFinSerrage);
    delay(100);
    pressionFinale = analogRead(AnalogPinFsr);
    coefficientDirecteur = (pressionFinale - pressionInitiale)/(angleFinSerrage - angleDebutSerrage);
    Serial.print("coef "); Serial.println(coefficientDirecteur);
    Serial.print("angle début "); Serial.println(angleDebutSerrage);
  }  
}

bool ouverture = false;
bool fermeture = false;


//------------------------------------------------------------------

//------------------------------------------------------------------
void setup() {

  /*EICRA |= (1<<ISC10)|(1<<ISC11); //Choix des interruptions sur frond montant
  EIMSK = (1<<INT0) | (1<<INT1); //Pin 2 puis pin 3 sur l'arduino UNO choisis comme pin d'interuption 
  sei(); // active toutes les interruptions*/
  DDRB  |= (1 << DDB1); // sortie sur PB1  (Pin 9 sur l'arduino UNO)
  //mode 14 fast pwm, clear OC1A 
  TCCR1A = ((1 << COM1A1) | (1 << WGM11)); 
  TCCR1B = ((1 << WGM12)  | (1 << WGM13) | (1 << CS11)); 
                    
  ICR1  = 20000;      // periode 20000 ms (50 Hz)
  Serial.begin(9600);
  adc_init();
  //on cree les evenements d'interruption

//attachInterrupt(digitalPinToInterrupt(interruptPin1), Int1, CHANGE);
//attachInterrupt(digitalPinToInterrupt(interruptPin2), Int2, CHANGE);

// On place le servo de maniere a ouvrir la pince au maximum
Angle(0);
//TestReceptionFSR();

}




void loop() {


//Si une donnée arrive...
if(stringComplete)
{    


  stringComplete = false;

  //On récupère sa commande (ce sur quoi elle agit)...
  getCommand();


  //...Puis on la fait agir sur la variable dont il est question
  if(command.equals("FSRS")) //Sensibilité du FSR
  {
      pressionSouhaitee = getData();
  }
  else if(command.equals("TEST")){
   //TestReceptionFSR();
  }
  else if(command.equals("INTE")) // Interruption
  {
      if(getData() == 1){
        interruption = true;
      }
      else{
        interruption = false;
      }
  }
  else if(command.equals("RESE")) // Reset
  {
      if(getData() == 1){
        reset = true;
        interruption = true;
        angle =0;
        Angle(0);
      }
      else{
        reset = false;
        interruption = false;
      }
  }
  else if(command.equals("OUVE")) //Ouverture de la pince
  {
      if(getData() == 1){
        ouverture = true;
      }
      else{
        ouverture = false;
      }
  }
  else if(command.equals("FERM")) //Fermeture de la pince
  {
      if(getData() == 1){
        fermeture = true;
      }
      else{
        fermeture = false;
      }
  }
  else if(command.equals("INTC")) // Interruption consigne
  {
      if(getData() == 1){
        interruptionConsigne = true;
      }
      else{
        interruptionConsigne = false;
      }
  }
  else if(command.equals("STRT"))
  {             
    if(getData() == 1){
        interruption = false;
      }
      else{
        interruption = true;
      }  
  }
  else if(command.equals("CMDM"))// Commande manuelle
  {
      if(getData() == 1){
        commandeManuelle = true;
        Angle(60);
      }
      else{
        commandeManuelle = false;
      }  
  }


  // Une fois la commande executée on laisse place à la prochaine
  inputString = "";
}
else if(commandeManuelle){
  Angle(pressionSouhaitee);
}
else if(ouverture){
  Angle(0);
}
else if(fermeture){
  Angle(120);
}
else if(!interruption && !interruptionConsigne)
{
      Serial.print("#F"); 
    Serial.println(analogRead(AnalogPinFsr));
    //On mesure la Pression mesurée par le FSR
    pression = ReadADC(AnalogPinFsr); // resultat entre 0 et 1024

    // Si la pression est insuffisante, on serre la pince ( +1 degré sur le servo)
    if(pression<(1-intervalleConsigne)*pressionSouhaitee && angle<=120)
    {
        angle+=precisionServo;
        serrageEstOk = LOW;
    }
    // Si la pression est trop elevée, on on dessere la pince ( -1 degré sur le servo)
    else if(pression>(1+intervalleConsigne)*pressionSouhaitee && angle>=0)
    {
        angle-=precisionServo;
        serrageEstOk = LOW;
    }
    else if(angle>=120 || angle<=0){
      serrageEstOk =LOW;
    }
    else{
          serrageEstOk=HIGH;
    }
    // Si la pression sur l'objet n'est pas bonne ( trop faible ou trop eleve), on envoie l'ordre au servo de changer l'angle ( +1 ou -1 degré)
    if (!serrageEstOk)
    {
        Angle(angle);
    }
    //on reinitialise le booleen pour le prochain test
    if(serrageEstOk){
      Serial.println("#C1");
    }
    else
    {
            Serial.println("#C0");
    }
}

else{

}

    // Si le systeme est interrompu (INT2), on remet le servo dans sa position initiale
   

    
    
}
   

 
  


void serialEvent() {
  analogWrite(4,1000);

while (Serial.available()) {
    // Récupère char par char les données
    char inChar = (char)Serial.read();
    // On les met dans un string
    inputString += inChar;
    // Jusqu'à avoir en donnée un retour à la ligne qui indique sa fin
    // On en informe la boucle loop
    if (inChar == '\n') {
      stringComplete = true;
    }

  }


  
}


void getCommand()
{
  if(inputString.length()>0)
  {
     //La commande est un string de 4 lettres 
     command = inputString.substring(1,5);
  }
}


int getData()
{
   //La donnée de la commande sont l'entier qui suit cette dernière
   return inputString.substring(5,inputString.length()-1).toInt();
}
/*
void Int1()

{
// On arrete le programme principale

interruption = true;
Serial.println("#I1");

}

//------------------------------------------------------------------

void Int2()

{
// On replace le servo dans la position initiale
interruption = true;
reset = true;
Serial.println("#I1");Serial.println("#R1");
Angle(0);

}

//------------------------------------------------------------------

*/

