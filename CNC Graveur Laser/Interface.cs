using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;

namespace RobotiqueEtMecatronique
{
    public partial class Interface : Form
    {
        /* ----------------------------------------------------------------------- *
         * ------------------------                        ----------------------- *
         * ------------------------  INTERFACE VOCALE TAJ  ----------------------- *
         * ------------------------                        ----------------------- *
         * ----------------------------------------------------------------------- */

        public SpeechSynthesizer taj = new SpeechSynthesizer(); //Voix
        public SpeechRecognitionEngine rec = new SpeechRecognitionEngine(); //Reconnaissance vocale
        Choices listRec = new Choices(); // Futur liste de vocabulaire pour rec
        Grammar grammar; //
        bool wake = true;
        string actionMemory; //comme son nom l'indique, retient l'action à faire avant d'avoir la donnée de l'action correspondante

        /// <summary>
        /// Fait parler la voix en mode Asynchrone
        /// </summary>
        /// <param name="s"></param>
        private void SayAsync(string s)// plus simple à écrire
        {
            taj.SpeakAsync(s);
        }

        /// <summary>
        /// Fait parler la voix en mode synchrone
        /// </summary>
        /// <param name="s"></param>
        private void Say(string s)// plus simple à écrire
        {
            taj.Speak(s);
        }

        /// <summary>
        /// Exécute une action en fonciton de la donnée "num"
        /// </summary>
        /// <param name="num"></param>
        private void Action(int num)//Lance l'action en fcontion de la donnée
        {
            switch (actionMemory)
            {
                case "sensibiliter effessaire":
                    if (!start)
                    {
                        numericSensitivity.Value = num;
                        checkBoxPersonnalisé.Checked = true;
                    }
                    break;
                case "angle":
                    {
                        if (checkBoxControl.Checked && num <= 120 && num >= 0)
                        {
                            if (Serial.IsOpen)
                            {
                                //On envoie la donnée
                                Serial.Write("#FSRS" + num + "\n");
                                labelDegre.Text = num.ToString();
                                trackBarDegre.Value = num;
                            }
                        }
                    }
                    break;
            }
            actionMemory = null;
        }

        /// <summary>
        /// Evenement de la reconnaissance d'un élément de grammaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            try
            {
                //Flemme de commenter, c'est juste les commandes qui parlent d'elles-mêmes
                int num;
                string r = e.Result.Text;
                if (r == "maurice s'il te plait")
                {
                    wake = true;
                }
                else if (r == "merci maurice")
                {
                    wake = false;
                }
                else if (int.TryParse(r, out num))
                {
                    Action(num);
                }
                if (wake)
                {
                    switch (r)
                    {
                        case "pince ouvre toi":
                            checkBoxOpen.Checked = true;
                            checkBoxClose.Checked = false;
                            break;
                        case "pince ferme toi":
                            checkBoxClose.Checked = true;
                            checkBoxOpen.Checked = false;
                            break;
                        case "sensibiliter effessaire":
                        case "angle":
                            actionMemory = r;
                            break;
                        case "oker":
                            actionMemory = null;
                            break;
                        case "bonjour toi":
                            SayAsync("Bonjour Monsieur");
                            break;
                        case "quelle heure est-il":
                            SayAsync("Il est " + DateTime.Now.ToString("hh:mm"));
                            break;
                        case "quel jour est-on":
                            SayAsync("On est le " + DateTime.Now.ToString("d/M/y"));
                            break;
                        case "cache l'interface":
                            this.WindowState = FormWindowState.Minimized;
                            break;
                        case "montre l'interface":
                            this.WindowState = FormWindowState.Normal;
                            break;
                        case "lancer le programme":
                            if (!start)
                            {
                                buttonStart_Click(buttonStart, null);
                            }
                            break;
                        case "arreter le programme":
                            if (start)
                            {
                                buttonStart_Click(buttonStart, null);
                            }
                            break;
                        case "interrompre le programme":
                            if (start)
                            {
                                checkBoxInterruption.Checked = true;
                            }
                            break;
                        case "reprendre le programme":
                            if (start)
                            {
                                checkBoxReset.Checked = false;
                                checkBoxInterruption.Checked = false;
                                checkBoxOpen.Checked = false;
                                checkBoxClose.Checked = false;
                            }
                            break;
                        case "reinitialiser angle":
                            checkBoxReset.Checked = !checkBoxReset.Checked;
                            break;
                        case "activation controle manuel":
                            checkBoxControl.Checked = true;
                            break;
                        case "desactivation controle manuel":
                            checkBoxControl.Checked = false;
                            break;
                        case "raconte moi une blague":
                            RaconteUneBlague();
                            break;
                        case "telecharger fiche technique":
                            Process.Start("http://julien-pytel.com/mes-projets/pince-de-mecatronique");
                            break;
                        case "objet rigide":
                            if (!start)
                            {
                                checkBoxRigide.Checked = true;
                            }
                            break;
                        case "objet semi rigide":
                            if (!start)
                            {
                                checkBoxSemiRigide.Checked = true;
                            }
                            break;
                        case "objet fragile":
                            if (!start)
                            {
                                checkBoxFragile.Checked = true;
                            }
                            break;
                        case "objet personnaliser":
                            if (!start)
                            {
                                checkBoxPersonnalisé.Checked = true;
                            }
                            break;
                        case "faire test effessaire":
                            Serial.Write("#TEST\n");
                            break;
                    }
                }
            }
            catch { return; }
        }

        /// <summary>
        /// Raconte une blague aléatoirement
        /// </summary>
        void RaconteUneBlague()
        {
            Random blague = new Random();
            string[] blagues = { "Qu'est ce qui fait. toin toin ? c'est un tanard ... toin toin ... un canard mais avec un t  . enfin ta compris",
            "C'est deux grains de sable qui arrivent à la plage. purée c'est blindé ici !",
            "C'est l'histoire d'un hibou dans une casserole. Et du coup. iiibout",
            "Le petit poucet. mais rien ne sortait",
            "Melon et Melèche prennent une maison. Melon l'achète. Melèche l'habite",
            "Je pense que vous devez connaitre la blague de la chaise. Elle est pliiiante",
            "Avec quoi ramasseuton la papaye ? . . avec une fou foursh",
            "Qu'est-ce qu'un canife ? . . . c'est un petit fi un",
            "femme qui rit. Femme fromage",
            "un combat entre un petit poi et une carotte c'est un bon duel"};
            SayAsync(blagues[blague.Next(0, blagues.Length)]);
        }

        /* ----------------------------------------------------------------------- *
         * ---------------------------                  -------------------------- *
         * ---------------------------  INITIALISATION  -------------------------- *
         * ---------------------------                  -------------------------- *
         * ----------------------------------------------------------------------- */

        bool start = false;

        /// <summary>
        /// Initialise l'interface
        /// </summary>
        public Interface()
        {
            rec.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(rec_SpeechRecognized); //Event pour la reconnaisance d'un vocabulaire

            listRec.Add(File.ReadAllLines("listRec.txt"));// Liste de vocabulaire de rec
            grammar = new Grammar(new GrammarBuilder(listRec)); //On l'ajoute 

            taj.SetOutputToDefaultAudioDevice();
            taj.Rate = 1;
            InitializeComponent();
            timer1.Enabled = true;
            string[] ports = SerialPort.GetPortNames();

            try
            {
                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(grammar);
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);

            }
            catch { return; }
            SayAsync("Bienvenu dans l'interfacecontrôle de la pince !");
            checkBoxRigide.Checked = true;
        }

        /// <summary>
        /// Récupère tous les ports ouvert, en sélectionne un, ss'il existe
        /// </summary>
        private void GetPorts()
        {
            string[] oldPorts = new string[BoxPort.Items.Count];

            for (int i = 0; i < BoxPort.Items.Count; i++)
            {
                oldPorts[i] = BoxPort.Items[i].ToString();
            }
            //On vide la Boxport de ces elements
            BoxPort.Items.Clear();
            //On obtient la liste des ports disponibles
            string[] ports = SerialPort.GetPortNames();
            if(start && !Serial.IsOpen)
            {
                buttonStart_Click(buttonStart, null);
            }
            //On ajoute les ports disponibles à la BoxPort
            foreach (string port in ports)
            {
                BoxPort.Items.Add(port);
            }
            // Si plusieurs ports sont disponibles : Par defaut c'est le premier de la liste
            if (ports != null && ports.Length > 0) { BoxPort.Text = ports[0]; BoxPort.BackColor = Color.FromArgb(180, 210, 180); buttonStart.BackColor = Color.FromArgb(180, 210, 180); }
            //Sinon on affiche qu'aucun port n'est disponible
            else { BoxPort.BackColor = Color.FromArgb(210, 180, 180); buttonStart.BackColor = Color.FromArgb(210, 180, 180); BoxPort.Text = "None"; };
            if (oldPorts.Length > ports.Length)
            {
                SayAsync("Port déconnecté");
            }
            if (oldPorts.Length < ports.Length)
            {
                SayAsync("Port connecté");
            }
        }

        /// <summary>
        /// Vérifie que le port existe
        /// </summary>
        /// <param name="portName"></param>
        /// <returns></returns>
        private bool PortExist(string portName)
        {
            bool exist = false;
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                if (portName == port)
                {
                    exist = true;
                }
            }
            return exist;
        }

        /// <summary>
        /// Bouton Start : Lance le programme en fonction des données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!start && PortExist(BoxPort.Text))
            {
                start = true;
                buttonStart.Text = "Arreter";
                if (!Serial.IsOpen)
                {
                    Serial.PortName = BoxPort.Text;
                    Serial.Open();
                }
                //On creer l'evenement de la réception de donnée depuis l'Arduino
                Serial.DataReceived += new SerialDataReceivedEventHandler(Serial_DataReceived);
                //On lui envoie la sensibilité choisie pour le FSR
                Serial.Write("#FSRS" + numericSensitivity.Value.ToString() + "\n");


                //On affiche tout bb !
                checkBoxClose.Visible = true;
                checkBoxOpen.Visible = true;
                trackBarDegre.Visible = true;
                numericMin.Visible = true;
                labelMin.Visible = true;
                numericMax.Visible = true;
                labelMax.Visible = true;
                labelDegre.Visible = true;
                checkBoxInterruption.Visible = true;
                checkBoxReset.Visible = true;
                labelPressure.Visible = true;
                checkBoxPressure.Visible = true;
                checkBoxControl.Visible = true;
                //On laisse affiché le type d'objet choisi
                if (!checkBoxRigide.Checked)
                {
                    checkBoxRigide.Visible = false;
                }
                else
                {
                    checkBoxRigide.Enabled = false;
                }
                if (!checkBoxSemiRigide.Checked)
                {
                    checkBoxSemiRigide.Visible = false;
                }
                else
                {
                    checkBoxSemiRigide.Enabled = false;
                }
                if (!checkBoxFragile.Checked)
                {
                    checkBoxFragile.Visible = false;
                }
                else
                {
                    checkBoxFragile.Enabled = false;
                }
                if (!checkBoxPersonnalisé.Checked)
                {
                    checkBoxPersonnalisé.Visible = false;
                }
                else
                {
                    checkBoxPersonnalisé.Enabled = false;
                }
                //Puis on lui dit que c'est parti
                Serial.Write("#STRT1\n");
                Serial.Write("#STAR1\n");
                Serial.Write("#STAR1\n");
            }
            else if (start)
            {
                Serial.DataReceived -= Serial_DataReceived;
                start = false;
                buttonStart.Text = "Lancer";
                //On enleve tout
                checkBoxClose.Visible = false;
                checkBoxOpen.Visible = false;
                trackBarDegre.Visible = false;
                numericMin.Visible = false;
                labelMin.Visible = false;
                numericMax.Visible = false;
                labelMax.Visible = false;
                labelDegre.Visible = false;
                checkBoxInterruption.Visible = false;
                checkBoxReset.Visible = false;
                labelPressure.Visible = false;
                checkBoxPressure.Visible = false;
                checkBoxControl.Visible = false;
                checkBoxPersonnalisé.Enabled = true;
                checkBoxPersonnalisé.Visible = true;
                checkBoxFragile.Enabled = true;
                checkBoxFragile.Visible = true;
                checkBoxRigide.Enabled = true;
                checkBoxRigide.Visible = true;
                checkBoxSemiRigide.Enabled = true;
                checkBoxSemiRigide.Visible = true;
            }
        }

        /* ----------------------------------------------------------------------- *
         * ------------------------                        ----------------------- *
         * ------------------------  RECEPTION DE DONNEES  ----------------------- *
         * ------------------------                        ----------------------- *
         * ----------------------------------------------------------------------- */

        char command = ' ';                 // Commande de la données recue
        int perCent = 0;                    // Pourcentage de la consigne donnée pour le FSR 
        bool interruption = false;          // Interruption système
        bool reset = false;                 // Reset système
        bool interruptionConsigne = false;  // Interruption dûe à l'atteinte de la consigne par le FSR
        delegate void SetDataCallback(string text); // Pour réenvoyer la chaine (changement de thread)

        /// <summary>
        /// Event pou la réception de donnée depuis le port Serial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Serial_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                //S'il y a des données on les lit
                SetData(Serial.ReadLine());
            }
            catch (Exception ex)
            {
                //Sinon ca bug, d'où le try/catch
                SetData(ex.ToString());
            }
        }

        /// <summary>
        /// Traitement de la donnée reçue depuis l'Arduino
        /// </summary>
        /// <param name="text"></param>
        private void SetData(string text)
        {
            command = text[1];
            if (command == 'F') // Commande pour signaler un changement de % de la consigne du FSR
            {
                perCent = Convert.ToInt32(text.Substring(2));
            }
            if (command == 'I') //Commande pour l'interrution
            {
                if (text[2] == '0')
                {
                    interruption = false;
                }
                else
                {
                    interruption = true;
                }
            }
            if (command == 'R') //Commande pour reset
            {
                if (text[2] == '0')
                {
                    reset = false;
                    interruption = false;
                }
                else
                {
                    interruption = false;
                    reset = true;
                }
            }
            if (command == 'C') //Commande pour l'interrution consigne
            {
                if (text[2] == '0')
                {
                    interruptionConsigne = false;
                }
                else
                {
                    interruptionConsigne = true;
                }
            }

            /* S'il la Form qu'on veut modifier ne fait pas partie 
               du thread event on fait un CallBack :
               En gros, à chaque fois */

            if (this.labelPressure.InvokeRequired) //% FSR
            {
                SetDataCallback d = new SetDataCallback(SetData);
                this.BeginInvoke(d, new object[] { "Pressure on FSR : " + perCent + "%" });
            }
            else
            {
                labelPressure.Text = "Pressure on FSR : " + perCent + "%";
            }

            if (this.checkBoxInterruption.InvokeRequired) // Check interruption
            {
                SetDataCallback d = new SetDataCallback(SetData);
                this.BeginInvoke(d, new object[] { text });
            }
            else
            {
                checkBoxInterruption.Checked = interruption;
            }
            if (this.checkBoxReset.InvokeRequired) // Check reset
            {
                SetDataCallback d = new SetDataCallback(SetData);
                this.BeginInvoke(d, new object[] { text });
            }
            else
            {
                checkBoxReset.Checked = reset;
            }
            if (this.checkBoxPressure.InvokeRequired) // Check interruption consigne
            {
                SetDataCallback d = new SetDataCallback(SetData);
                this.BeginInvoke(d, new object[] { text });
            }
            else
            {
                checkBoxPressure.Checked = interruptionConsigne;
            }
        }

        /* ----------------------------------------------------------------------- *
         * --------------------------                   -------------------------- *
         * --------------------------  CONTROLE MANUEL  -------------------------- *
         * --------------------------                   -------------------------- *
         * ----------------------------------------------------------------------- */

        /// <summary>
        /// Active/Desactive le controle manuel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxControl_CheckedChanged(object sender, EventArgs e)
        {
            //Rend utilisable ou non le control manuel en fontion de la checkBox
            labelMax.Enabled = labelMin.Enabled = trackBarDegre.Enabled = numericMin.Enabled = numericMax.Enabled = labelDegre.Enabled = checkBoxControl.Checked;
            if (checkBoxControl.Checked)
            {
                Serial.WriteLine("#CMDM1");

            }
            else
            {
                Serial.WriteLine("#CMDM0");
                Serial.Write("#FSRS" + numericSensitivity.Value.ToString() + "\n");
            }
        }

        /// <summary>
        /// Pour contrôle manuel : Event sur le changement de valeur de la Trackbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //On vérifie que le port soit ouvert sinon ça crash
            if (Serial.IsOpen)
            {
                //On envoie la donnée
                Serial.Write("#FSRS" + trackBarDegre.Value.ToString() + "\n");
                labelDegre.Text = trackBarDegre.Value.ToString();
            }
        }

        /// <summary>
        /// Change le valeur minimum de la Trackbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericMin_ValueChanged(object sender, EventArgs e)
        {
            //On change le minimum de la Trackbar
            trackBarDegre.Minimum = (int)numericMin.Value;
        }

        /// <summary>
        /// Change la valeur maximum de la Trackbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelMax_Click(object sender, EventArgs e)
        {
            //On change le minimum de la Trackbar
            trackBarDegre.Maximum = (int)numericMax.Value;
        }


        /* ----------------------------------------------------------------------- *
         * ---------------------------                ---------------------------- *
         * ---------------------------  INTERRUPTION  ---------------------------- *
         * ---------------------------                ---------------------------- *
         * ----------------------------------------------------------------------- */

        /// <summary>
        /// Envoie à l'Arduino le changement d'état de l'interruption si faite via l'interface
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxInterruption_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxInterruption.Checked == true)
            {
                Serial.Write("#INTE1\n");
                interruption = true;
            }
            else
            {
                Serial.Write("#INTE0\n");
                interruption = false;
            }
        }

        /// <summary>
        /// Envoie à l'Arduino le reset ou non de l'angle du servo si fait via l'interface
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxReset_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxReset.Checked == true)
            {
                Serial.Write("#RESE1\n");
                reset = true;
                interruption = true;
            }
            else
            {
                Serial.Write("#RESE0\n");
                reset = false;
                interruption = false;
            }
        }

        /// <summary>
        /// Evenement de la case fermeture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxClose_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOpen.Checked && checkBoxClose.Checked)
                checkBoxOpen.Checked = false;

            if (checkBoxClose.Checked == true)
            {
                Serial.Write("#FERM1\n");
            }
            else
            {
                Serial.Write("#FERM0\n");
            }
        }

        /// <summary>
        /// Evenement de la case ouverture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxOpen_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOpen.Checked && checkBoxClose.Checked)
                checkBoxClose.Checked = false;

            if (checkBoxOpen.Checked == true)
            {
                Serial.Write("#OUVE1\n");
            }
            else
            {
                Serial.Write("#OUVE0\n");
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------
        //--------------                        ----------------------------------------------------------------------------------------
        //--------------         AUTRE          ----------------------------------------------------------------------------------------
        //--------------                        ----------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------

        bool inChange = false;

        /// <summary>
        /// Récupère continuellement les ports ouverts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            GetPorts();
        }

        /// <summary>
        /// Lancement Interface
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Interface_Load(object sender, EventArgs e)
        {
            string listeCommandes = File.ReadAllText("listRec.txt");
            for (int i = 0; i < listeCommandes.Length; i++)
            {
                if (listeCommandes.Substring(i, 1).All(char.IsDigit)) { listeCommandes = listeCommandes.Substring(0, i - 1); break; }
            }
            richTextBox1.Text = listeCommandes;
        }

        /// <summary>
        /// Permet de télécharger le manuel d'utilisation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxFiche_Click(object sender, EventArgs e)
        {
            Process.Start("http://julien-pytel.com/mes-projets/pince-de-mecatronique");
        }

        /// <summary>
        /// Permet de choisir une force exercée selon un objet rigide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxRigide_CheckedChanged(object sender, EventArgs e)
        {
            if (!inChange && checkBoxRigide.Checked)
            {
                numericSensitivity.Value = 100;
                inChange = true;
                checkBoxPersonnalisé.Checked = false;
                checkBoxSemiRigide.Checked = false;
                checkBoxFragile.Checked = false;
                inChange = false;
            }
        }

        /// <summary>
        /// Permet de choisir une force exercée selon un objet semi-rigide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxSemiRigide_CheckedChanged(object sender, EventArgs e)
        {
            if (!inChange && checkBoxSemiRigide.Checked)
            {
                numericSensitivity.Value = 80;
                inChange = true;
                checkBoxPersonnalisé.Checked = false;
                checkBoxRigide.Checked = false;
                checkBoxFragile.Checked = false;
                inChange = false;
            }
        }

        /// <summary>
        /// Permet de choisir une force exercée selon un objet fragile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxFragile_CheckedChanged(object sender, EventArgs e)
        {
            if (!inChange && checkBoxFragile.Checked)
            {
                numericSensitivity.Value = 50;
                inChange = true;
                checkBoxPersonnalisé.Checked = false;
                checkBoxSemiRigide.Checked = false;
                checkBoxRigide.Checked = false;
                inChange = false;
            }
        }

        /// <summary>
        /// Permet de personnaliser la sforce exercée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxPersonnalisé_CheckedChanged(object sender, EventArgs e)
        {
            numericSensitivity.Enabled = false;
            if (!inChange && checkBoxPersonnalisé.Checked)
            {
                inChange = true;
                numericSensitivity.Enabled = true;
                checkBoxRigide.Checked = false;
                checkBoxSemiRigide.Checked = false;
                checkBoxFragile.Checked = false;
                inChange = false;
            }
        }

        private void numericSensitivity_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}