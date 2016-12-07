// Jeu de Tetris
// Programmé par Samuel Cloutier & Albert Ouellet
// Le jeu consiste à placer les blocs de façons à créer des lignes qui vont disparaitre
// pour gagner des points. Le but du jeu est de faire le plus de point possible.
// La partie se termine lorsque le joueur n'est plus capable de placer les blocs
// au point que le bloc va se geler dans le "spawn" du bloc.
//<scloutier> pour les commentaires & fonctions de Samuel Cloutier
//<aouellet> pour les commentaires & fonctions d'Albert Ouellet
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace TP3
{
    public partial class FormPrincipal : Form
    {
        /// <summary>
        /// <scloutier>Génère le FormPrincipal(Tableau de Jeu)
        /// </summary>
        public FormPrincipal()
        {
            FormStatistique stats = new FormStatistique(this);
            FormConfiguration config = new FormConfiguration(this);
            InitializeComponent();
        }

        #region Variable Partagées


        int[] blocActifY = new int[4]; // <scloutier> Tableau 1D qui va servir à notre pièce
        int[] blocActifX = new int[4]; // <scloutier> Tableau 1D qui va servir à notre pièce
        int[] nouveauBlocActifY = new int[4]; // <scloutier> Tableau 1D qui va servir à nos vérifications
        int[] nouveauBlocActifX = new int[4]; // <scloutier> Tableau 1D qui va servir à nos vérifications
        int ligneCourante = 0; // <scloutier> L'emplacement du Tableau(pièce)
        int colonneCourante = 0; // <scloutier> L'emplacement du Tableau(pièce)
        Deplacement mouvement = 0; //<scloutier> Appel pour le mouvement utilisé plus loin pour les déplacements

        // Représentation visuelles du jeu en mémoire.
        PictureBox[,] toutesImagesVisuelles = null;

        public int nbLignes = 20;
        public int nbColonnes = 10;
        TypeEtat[,] tableauEtats = new TypeEtat[20, 10];
        TypeEtat pieceTableau;
        bool partieEnCours = false;
        bool deplacementPossible = false;
        public int nbDeSeconde = 0;
        int score = 0;

        //Statistiques // <scloutier> Initialisation en partagée pour une utilisation plus facile

        public int nbDeCarre = 0;
        public int nbDeCarrePourcentage = 0;

        public int nbDeLigne = 0;
        public int nbDeLignePourcentage = 0;

        public int nbDeT = 0;
        public int nbDeTPourcentage = 0;

        public int nbDeL = 0;
        public int nbDeLPourcentage = 0;

        public int nbDeS = 0;
        public int nbDeSPourcentage = 0;

        public int nbDeZ = 0;
        public int nbDeZPourcentage = 0;

        public int nbDeJ = 0;
        public int nbDeJPourcentage = 0;

        public int nbDePieceJouer = 0;

        #endregion

        #region frmLoad
        /// <summary>
        /// Gestionnaire de l'événement se produisant lors du premier affichage 
        /// du formulaire principal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLoad(object sender, EventArgs e)
        {
            // Ne pas oublier de mettre en place les valeurs nécessaires à une partie.
            ExecuterTestsUnitaires();
            InitialiserSurfaceDeJeu(nbLignes, nbColonnes);
        }
        #endregion

        #region InitialiserSurFaceDeJeu
        /// <summary>
        /// <scloutier>Crée la surface de jeu sur laquelle le joueur va placer les blocs.
        /// </summary>
        /// <param name="nbLignes"><scloutier>Dimensions en hauteur du tableau de jeu</param>
        /// <param name="nbCols"><scloutier>Dimensions en largeur du tableau de jeu</param>
        public void InitialiserSurfaceDeJeu(int nbLignes, int nbCols)
        {
            // Création d'une surface de jeu 10 colonnes x 20 lignes
            toutesImagesVisuelles = new PictureBox[nbLignes, nbCols];
            tableauJeu.Controls.Clear();
            tableauJeu.ColumnCount = toutesImagesVisuelles.GetLength(1);
            tableauJeu.RowCount = toutesImagesVisuelles.GetLength(0);
            for (int i = 0; i < tableauJeu.RowCount; i++)
            {
                tableauJeu.RowStyles[i].Height = tableauJeu.Height / tableauJeu.RowCount;
                for (int j = 0; j < tableauJeu.ColumnCount; j++)
                {
                    tableauJeu.ColumnStyles[j].Width = tableauJeu.Width / tableauJeu.ColumnCount;
                    // Création dynamique des PictureBox qui contiendront les pièces de jeu
                    PictureBox newPictureBox = new PictureBox();
                    newPictureBox.Width = tableauJeu.Width / tableauJeu.ColumnCount;
                    newPictureBox.Height = tableauJeu.Height / tableauJeu.RowCount;
                    newPictureBox.BackColor = Color.Black;
                    newPictureBox.Margin = new Padding(0, 0, 0, 0);
                    newPictureBox.BorderStyle = BorderStyle.FixedSingle;
                    newPictureBox.Dock = DockStyle.Fill;

                    // Assignation de la représentation visuelle.
                    toutesImagesVisuelles[i, j] = newPictureBox;
                    // Ajout dynamique du PictureBox créé dans la grille de mise en forme.
                    // A noter que l' "origine" du repère dans le tableau est en haut à gauche.
                    tableauJeu.Controls.Add(newPictureBox, j, i);
                }
            }
        }
        #endregion

        #region TypeEtat
        /// <summary>
        /// <scloutier> Énumération des types de blocs
        /// </summary>
        enum TypeEtat
        {
            NONE,
            GELE,
            CARRE,
            LIGNE,
            T,
            L,
            J,
            S,
            Z
        }
        #endregion

        #region Code à développer
        /// <summary>
        /// Faites ici les appels requis pour vos tests unitaires.
        /// </summary>
        void ExecuterTestsUnitaires()
        {
            /*
            Albert Ouellet
            ExecuterTestRetirerLigneA();
            ExecuterTestRetirerLigneB();
            ExecuterTestRetirerLigneC();
            ExecuterTestRetirerLigneD();
            ExecuterTestRetirerLigneE();
            ExecuterTestRetirerLigneF();
            
            Samuel Cloutier
            ExecuterTestRotationBlocAuCentre();
            ExecuterTestRotationBlocAuMurDroit();
            ExecuterTestRotationBlocAuMurGauche();
            ExecuterTestFinDePartieNonTerminer();
            ExecuterTestFinDePartieTerminer();
            ExecuterTestRotationBlocAuCentre();*/
        }

        // A renommer et commenter!


        /// <summary>
        /// <scloutier>Fait tourner un bloc au centre du tableau de Jeu pour savoir si la rotation marche ou non
        /// </summary>
        void ExecuterTestRotationBlocAuCentre()
        {
            int[] testBlocActifY = new int[4];
            int[] testBlocActifX = new int[4];
            int[] testNouveauBlocActifY = new int[4];
            int[] testNouveauBlocActifX = new int[4];

            pieceTableau = TypeEtat.LIGNE;
            VerifierDeplacement(Deplacement.ROTATION_HORAIRE);
            // Test avec la Ligne
            ligneCourante = nbLignes / 2;
            colonneCourante = nbColonnes / 2;
            //PositionY
            testBlocActifY[0] = 0;
            testBlocActifY[1] = 0;
            testBlocActifY[2] = 0;
            testBlocActifY[3] = 0;
            //PositionX
            testBlocActifX[0] = 0;
            testBlocActifX[1] = 1;
            testBlocActifX[2] = 2;
            testBlocActifX[3] = 3;

            for (int i = 0; i < blocActifX.Length; i++)
            {
                Debug.Assert(testBlocActifX[i] == testBlocActifY[i], "Erreur, le bloc n'est pas capable de tourner au centre.");
            }
        }


        /// <summary>
        /// <scloutier>Fait tourner un bloc collé sur le mur droit du tableau pour savoir si la rotation marche ou non
        /// </summary>
        void ExecuterTestRotationBlocAuMurDroit()
        {
            int[] testBlocActifY = new int[4];
            int[] testBlocActifX = new int[4];
            int[] testNouveauBlocActifY = new int[4];
            int[] testNouveauBlocActifX = new int[4];

            pieceTableau = TypeEtat.LIGNE;
            VerifierDeplacement(Deplacement.ROTATION_HORAIRE);
            // Test avec la Ligne
            ligneCourante = nbLignes / 2;
            colonneCourante = nbColonnes;
            //PositionY
            testBlocActifY[0] = 0;
            testBlocActifY[1] = 0;
            testBlocActifY[2] = 0;
            testBlocActifY[3] = 0;
            //PositionX
            testBlocActifX[0] = 0;
            testBlocActifX[1] = 1;
            testBlocActifX[2] = 2;
            testBlocActifX[3] = 3;

            for (int i = 0; i < blocActifX.Length; i++)
            {
                Debug.Assert(testBlocActifX[i] == testBlocActifY[i], "Erreur, le bloc sort du tableau de jeu.");
            }
        }

        /// <summary>
        /// <scloutier>Fait tourner un bloc collé sur le mur droit du tableau pour savoir si la rotation marche ou non
        /// </summary>
        void ExecuterTestRotationBlocAuMurGauche()
        {
            int[] testBlocActifY = new int[4];
            int[] testBlocActifX = new int[4];
            int[] testNouveauBlocActifY = new int[4];
            int[] testNouveauBlocActifX = new int[4];

            pieceTableau = TypeEtat.LIGNE;
            VerifierDeplacement(Deplacement.ROTATION_ANTIHORAIRE);
            // Test avec la Ligne
            ligneCourante = nbLignes / 2;
            colonneCourante = 0;
            //PositionY
            testBlocActifY[0] = 0;
            testBlocActifY[1] = 0;
            testBlocActifY[2] = 0;
            testBlocActifY[3] = 0;
            //PositionX
            testBlocActifX[0] = 0;
            testBlocActifX[1] = 1;
            testBlocActifX[2] = 2;
            testBlocActifX[3] = 3;

            for (int i = 0; i < blocActifX.Length; i++)
            {
                Debug.Assert(testBlocActifX[i] == testBlocActifY[i], "Erreur, le bloc sort du tableau de jeu.");
            }
        }

        /// <summary>
        /// <scloutier> Fait tourner un bloc sur le mur gauche avec des blocs gelés autours
        /// </summary>
        void ExecuterTestRotationBlocAuMurGaucheAvecBlocAutour()
        {
            int[] testBlocActifY = new int[4];
            int[] testBlocActifX = new int[4];
            int[] testNouveauBlocActifY = new int[4];
            int[] testNouveauBlocActifX = new int[4];

            pieceTableau = TypeEtat.LIGNE;
            VerifierDeplacement(Deplacement.ROTATION_HORAIRE);
            // Test avec la Ligne
            ligneCourante = nbLignes / 2;
            colonneCourante = 0;
            //PositionY
            testBlocActifY[0] = 0;
            testBlocActifY[1] = 0;
            testBlocActifY[2] = 0;
            testBlocActifY[3] = 0;
            //PositionX
            testBlocActifX[0] = 0;
            testBlocActifX[1] = 1;
            testBlocActifX[2] = 2;
            testBlocActifX[3] = 3;

            for (int i = nbLignes; i > 10; i++)
            {
                tableauEtats[i, 0] = TypeEtat.GELE;
            }

            for (int i = 0; i < blocActifX.Length; i++)
            {
                Debug.Assert(testBlocActifX[i] == testBlocActifY[i], "Erreur, le bloc sort du tableau de jeu et écrase des blocs gelés.");
            }
        }

        /// <summary>
        /// <scloutier> Test si la partie se termine quand elle ne dois pas se terminé
        /// </summary>
        void ExecuterTestFinDePartieNonTerminer()
        {
            int[] testBlocActifY = new int[4];
            int[] testBlocActifX = new int[4];

            pieceTableau = TypeEtat.LIGNE;
            VerifierFinDePartie();
            // Test avec la Ligne
            ligneCourante = 0;
            colonneCourante = nbColonnes;
            //PositionY
            testBlocActifY[0] = 0;
            testBlocActifY[1] = 0;
            testBlocActifY[2] = 0;
            testBlocActifY[3] = 0;
            //PositionX
            testBlocActifX[0] = 0;
            testBlocActifX[1] = 1;
            testBlocActifX[2] = 2;
            testBlocActifX[3] = 3;

            for (int i = nbLignes; i > 10; i++)
            {
                tableauEtats[i, 0] = TypeEtat.GELE;
            }

            for (int i = 0; i < blocActifX.Length; i++)
            {
                Debug.Assert(partieEnCours == true, "Erreur, la partie n'est pas terminée.");
            }
        }

        /// <summary>
        /// <scloutier> Test si la partie se termine quand le tableau est remplit de bloc gelé
        /// </summary>
        void ExecuterTestFinDePartieTerminer()
        {
            int[] testBlocActifY = new int[4];
            int[] testBlocActifX = new int[4];

            pieceTableau = TypeEtat.LIGNE;
            VerifierFinDePartie();
            // Test avec la Ligne
            ligneCourante = 0;
            colonneCourante = nbColonnes / 2;
            //PositionY
            testBlocActifY[0] = 0;
            testBlocActifY[1] = 0;
            testBlocActifY[2] = 0;
            testBlocActifY[3] = 0;
            //PositionX
            testBlocActifX[0] = 0;
            testBlocActifX[1] = 1;
            testBlocActifX[2] = 2;
            testBlocActifX[3] = 3;

            for (int i = 0; i < tableauEtats.GetLength(0); i++)
            {
                for (int j = 0; j < tableauEtats.GetLength(1); j++)
                {
                    tableauEtats[i, 0] = TypeEtat.GELE;
                }
            }

            for (int i = 0; i < blocActifX.Length; i++)
            {
                Debug.Assert(partieEnCours == false, "Erreur, la partie est terminée.");
            }
        }


        void ExecuterTestRetirerLigneA()
        {
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                tableauEtats[tableauEtats.GetLength(0) - 1, i] = TypeEtat.GELE;
            }
            List<int> lignesCompleterTest = new List<int>();
            lignesCompleterTest = VerifierLigne();
            foreach (int line in lignesCompleterTest)
            {
                EffacerLigne(line);
                DecalerLignes(line);
            }
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                Debug.Assert(tableauEtats[tableauEtats.GetLength(0), i] == TypeEtat.NONE, "Erreur, n'a pas été effacé correctement.");
            }

            btnStart.Enabled = true;
            InitialiserSurfaceDeJeu(nbLignes = 20, nbColonnes = 10);
            GenererTableauEtat(nbLignes = 20, nbColonnes = 10);
            ReinitialiserPictureBox();
            ligneCourante = 0;
            colonneCourante = tableauEtats.GetLength(1) / 2 - 1;
            timer1.Stop();
            score = 0;
            GererScore();
        }

        void ExecuterTestRetirerLigneB()
        {
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                tableauEtats[tableauEtats.GetLength(0), i] = TypeEtat.GELE;
            }
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                tableauEtats[tableauEtats.GetLength(0) - 1, i] = TypeEtat.LIGNE;
            }

            List<int> lignesCompleterTest = new List<int>();
            lignesCompleterTest = VerifierLigne();
            foreach (int line in lignesCompleterTest)
            {
                EffacerLigne(line);
                DecalerLignes(line);
            }
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                Debug.Assert(tableauEtats[tableauEtats.GetLength(0), i] == TypeEtat.LIGNE, "Erreur, n'a pas été effacé correctement / mauvais décalage.");
            }

            btnStart.Enabled = true;
            InitialiserSurfaceDeJeu(nbLignes = 20, nbColonnes = 10);
            GenererTableauEtat(nbLignes = 20, nbColonnes = 10);
            ReinitialiserPictureBox();
            ligneCourante = 0;
            colonneCourante = tableauEtats.GetLength(1) / 2 - 1;
            timer1.Stop();
            score = 0;
            GererScore();
        }

        void ExecuterTestRetirerLigneC()
        {
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                tableauEtats[tableauEtats.GetLength(0), i] = TypeEtat.GELE;
            }
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                tableauEtats[tableauEtats.GetLength(0) - 1, i] = TypeEtat.GELE;
            }
            List<int> lignesCompleterTest = new List<int>();
            lignesCompleterTest = VerifierLigne();
            foreach (int line in lignesCompleterTest)
            {
                EffacerLigne(line);
                DecalerLignes(line);
            }
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                Debug.Assert(tableauEtats[tableauEtats.GetLength(0), i] == TypeEtat.NONE, "Erreur, n'a pas été effacé correctement.");
            }
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                Debug.Assert(tableauEtats[tableauEtats.GetLength(0) - 1, i] == TypeEtat.NONE, "Erreur, n'a pas été effacé correctement.");
            }

            btnStart.Enabled = true;
            InitialiserSurfaceDeJeu(nbLignes = 20, nbColonnes = 10);
            GenererTableauEtat(nbLignes = 20, nbColonnes = 10);
            ReinitialiserPictureBox();
            ligneCourante = 0;
            colonneCourante = tableauEtats.GetLength(1) / 2 - 1;
            timer1.Stop();
            score = 0;
            GererScore();
        }

        void ExecuterTestRetirerLigneD()
        {
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                tableauEtats[tableauEtats.GetLength(0), i] = TypeEtat.GELE;
            }
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                tableauEtats[tableauEtats.GetLength(0) - 2, i] = TypeEtat.GELE;
            }
            List<int> lignesCompleterTest = new List<int>();
            lignesCompleterTest = VerifierLigne();
            foreach (int line in lignesCompleterTest)
            {
                EffacerLigne(line);
                DecalerLignes(line);
            }
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                Debug.Assert(tableauEtats[tableauEtats.GetLength(0), i] == TypeEtat.NONE, "Erreur, n'a pas été effacé correctement.");
            }
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                Debug.Assert(tableauEtats[tableauEtats.GetLength(0) - 2, i] == TypeEtat.NONE, "Erreur, n'a pas été effacé correctement.");
            }

            btnStart.Enabled = true;
            InitialiserSurfaceDeJeu(nbLignes = 20, nbColonnes = 10);
            GenererTableauEtat(nbLignes = 20, nbColonnes = 10);
            ReinitialiserPictureBox();
            ligneCourante = 0;
            colonneCourante = tableauEtats.GetLength(1) / 2 - 1;
            timer1.Stop();
            score = 0;
            GererScore();
        }

        void ExecuterTestRetirerLigneE()
        {
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                tableauEtats[tableauEtats.GetLength(0), i] = TypeEtat.GELE;
            }
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                tableauEtats[tableauEtats.GetLength(0) - 1, i] = TypeEtat.GELE;
            }
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                tableauEtats[tableauEtats.GetLength(0) - 2, i] = TypeEtat.GELE;
            }
            List<int> lignesCompleterTest = new List<int>();
            lignesCompleterTest = VerifierLigne();
            foreach (int line in lignesCompleterTest)
            {
                EffacerLigne(line);
                DecalerLignes(line);
            }
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                Debug.Assert(tableauEtats[tableauEtats.GetLength(0), i] == TypeEtat.NONE, "Erreur, n'a pas été effacé correctement.");
            }
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                Debug.Assert(tableauEtats[tableauEtats.GetLength(0) - 1, i] == TypeEtat.NONE, "Erreur, n'a pas été effacé correctement.");
            }
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                Debug.Assert(tableauEtats[tableauEtats.GetLength(0) - 2, i] == TypeEtat.NONE, "Erreur, n'a pas été effacé correctement.");
            }

            btnStart.Enabled = true;
            InitialiserSurfaceDeJeu(nbLignes = 20, nbColonnes = 10);
            GenererTableauEtat(nbLignes = 20, nbColonnes = 10);
            ReinitialiserPictureBox();
            ligneCourante = 0;
            colonneCourante = tableauEtats.GetLength(1) / 2 - 1;
            timer1.Stop();
            score = 0;
            GererScore();
        }

        void ExecuterTestRetirerLigneF()
        {
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                tableauEtats[tableauEtats.GetLength(0), i] = TypeEtat.GELE;
            }
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                tableauEtats[tableauEtats.GetLength(0) - 1, i] = TypeEtat.GELE;
            }
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                tableauEtats[tableauEtats.GetLength(0) - 2, i] = TypeEtat.GELE;
            }
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                tableauEtats[tableauEtats.GetLength(0) - 3, i] = TypeEtat.GELE;
            }

            List<int> lignesCompleterTest = new List<int>();
            lignesCompleterTest = VerifierLigne();
            foreach (int line in lignesCompleterTest)
            {
                EffacerLigne(line);
                DecalerLignes(line);
            }
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                Debug.Assert(tableauEtats[tableauEtats.GetLength(0), i] == TypeEtat.NONE, "Erreur, n'a pas été effacé correctement.");
            }
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                Debug.Assert(tableauEtats[tableauEtats.GetLength(0) - 1, i] == TypeEtat.NONE, "Erreur, n'a pas été effacé correctement.");
            }
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                Debug.Assert(tableauEtats[tableauEtats.GetLength(0) - 2, i] == TypeEtat.NONE, "Erreur, n'a pas été effacé correctement.");
            }
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                Debug.Assert(tableauEtats[tableauEtats.GetLength(0) - 3, i] == TypeEtat.NONE, "Erreur, n'a pas été effacé correctement.");
            }

            btnStart.Enabled = true;
            InitialiserSurfaceDeJeu(nbLignes = 20, nbColonnes = 10);
            GenererTableauEtat(nbLignes = 20, nbColonnes = 10);
            ReinitialiserPictureBox();
            ligneCourante = 0;
            colonneCourante = tableauEtats.GetLength(1) / 2 - 1;
            timer1.Stop();
            score = 0;
            GererScore();
        }

        #endregion



        #region configDuJeuToolStripMenuItem_Click
        /// <summary>
        /// Ne Pas Effacer
        /// <scloutier> Utilisé pour le clic du menu déroulant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void configurationDuJeuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region configurationToolStripMenuItem_Clicl
        //<scloutier>
        /// <summary>
        /// Ouvre le form de configuration pour choisir comment on veut jouer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConfiguration config = new FormConfiguration(this);
            config.numericUpDown1.Value = nbLignes;
            config.numericUpDown2.Value = nbColonnes;
            config.ShowDialog();
        }
        //</scloutier>
        #endregion

        #region quittezToolStripMenuItem_Click
        //<scloutier>
        /// <summary>
        /// Permet à l'utilisateur de quittez en tout temps
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quittezToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //</scloutier>
        #endregion

        #region réinitialiséPartieToolStripMenuItem_Click
        //<scloutier>
        /// <summary>
        /// Réinitialise le jeu en entier pour pouvoir recommencer sa partie ou commencer une nouvelle partie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void réinitialiséPartieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            InitialiserSurfaceDeJeu(nbLignes = 20, nbColonnes = 10);
            GenererTableauEtat(nbLignes = 20, nbColonnes = 10);
            ReinitialiserPictureBox();
            ligneCourante = 0;
            colonneCourante = tableauEtats.GetLength(1) / 2 - 1;
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();

            nbDeCarre = 0;
            nbDeCarrePourcentage = 0;

            nbDeLigne = 0;
            nbDeLignePourcentage = 0;

            nbDeT = 0;
            nbDeTPourcentage = 0;

            nbDeL = 0;
            nbDeLPourcentage = 0;

            nbDeS = 0;
            nbDeSPourcentage = 0;

            nbDeZ = 0;
            nbDeZPourcentage = 0;

            nbDeJ = 0;
            nbDeJPourcentage = 0;

            nbDePieceJouer = 0;
            nbDeSeconde = 0;

            StatistiqueEnJeu();
        }
        //</scloutier>
        #endregion

        #region InitialiserPieceDansTableau
        //<scloutier>
        /// <summary>
        /// Initialise les pièces dans le tableauEtats
        /// </summary>
        /// <param name="randomPiece">Utilisation de la piece aléatoire</param>
        void InitialiserPieceDansTableau(TypeEtat randomPiece)
        {
            for (int i = 0; i < blocActifY.Length; i++)
            {
                tableauEtats[ligneCourante + blocActifY[i], colonneCourante + blocActifX[i]] = randomPiece;
                if (randomPiece == TypeEtat.CARRE)
                {
                    toutesImagesVisuelles[ligneCourante + blocActifY[i], colonneCourante + blocActifX[i]].BackColor = Color.Yellow;
                }
                else if (randomPiece == TypeEtat.LIGNE)
                {
                    toutesImagesVisuelles[ligneCourante + blocActifY[i], colonneCourante + blocActifX[i]].BackColor = Color.Blue;
                }
                else if (randomPiece == TypeEtat.T)
                {
                    toutesImagesVisuelles[ligneCourante + blocActifY[i], colonneCourante + blocActifX[i]].BackColor = Color.Purple;
                }
                else if (randomPiece == TypeEtat.L)
                {
                    toutesImagesVisuelles[ligneCourante + blocActifY[i], colonneCourante + blocActifX[i]].BackColor = Color.Green;
                }
                else if (randomPiece == TypeEtat.J)
                {
                    toutesImagesVisuelles[ligneCourante + blocActifY[i], colonneCourante + blocActifX[i]].BackColor = Color.OrangeRed;
                }
                else if (randomPiece == TypeEtat.S)
                {
                    toutesImagesVisuelles[ligneCourante + blocActifY[i], colonneCourante + blocActifX[i]].BackColor = Color.Red;
                }
                else // Bloc Z
                {
                    toutesImagesVisuelles[ligneCourante + blocActifY[i], colonneCourante + blocActifX[i]].BackColor = Color.Pink;
                }
            }
        }
        //</scloutier>
        #endregion

        #region GenererPieceAleatoire
        // <scloutier>
        /// <summary>
        /// Génére une pièce aléatoire avec ses emplacement à elle
        /// </summary>
        /// <returns>Retourne la pièce eux aléatoirement</returns>
        TypeEtat GenererPieceAleatoire()
        {
            Random rnd = new Random();
            TypeEtat randomPiece = (TypeEtat)rnd.Next(2, 9);

            if (randomPiece == TypeEtat.CARRE) //Si bloc carré
            {
                //PositionY
                blocActifY[0] = 0;
                blocActifY[1] = 0;
                blocActifY[2] = 1;
                blocActifY[3] = 1;
                //PositionX
                blocActifX[0] = 0;
                blocActifX[1] = 1;
                blocActifX[2] = 0;
                blocActifX[3] = 1;
            }
            else if (randomPiece == TypeEtat.LIGNE) //Si bloc ligne
            {
                //PositionY
                blocActifY[0] = 0;
                blocActifY[1] = 0;
                blocActifY[2] = 0;
                blocActifY[3] = 0;
                //PositionX
                blocActifX[0] = 0;
                blocActifX[1] = 1;
                blocActifX[2] = 2;
                blocActifX[3] = 3;
            }

            else if (randomPiece == TypeEtat.T) //Si bloc T
            {
                //PositionY
                blocActifY[0] = 0;
                blocActifY[1] = 1;
                blocActifY[2] = 1;
                blocActifY[3] = 1;
                //PositionX
                blocActifX[0] = 1;
                blocActifX[1] = 0;
                blocActifX[2] = 1;
                blocActifX[3] = 2;
            }
            else if (randomPiece == TypeEtat.L)
            {
                //PositionY
                blocActifY[0] = 0;
                blocActifY[1] = 1;
                blocActifY[2] = 2;
                blocActifY[3] = 2;
                //PositionX
                blocActifX[0] = 0;
                blocActifX[1] = 0;
                blocActifX[2] = 0;
                blocActifX[3] = 1;
            }
            else if (randomPiece == TypeEtat.J)
            {
                //PositionY
                blocActifY[0] = 0;
                blocActifY[1] = 1;
                blocActifY[2] = 2;
                blocActifY[3] = 2;
                //PositionX
                blocActifX[0] = 1;
                blocActifX[1] = 1;
                blocActifX[2] = 1;
                blocActifX[3] = 0;
            }
            else if (randomPiece == TypeEtat.S)
            {
                //PositionY
                blocActifY[0] = 1;
                blocActifY[1] = 1;
                blocActifY[2] = 0;
                blocActifY[3] = 0;
                //PositionX
                blocActifX[0] = 0;
                blocActifX[1] = 1;
                blocActifX[2] = 1;
                blocActifX[3] = 2;
            }
            else // TypeEtat.Z
            {
                //PositionY
                blocActifY[0] = 0;
                blocActifY[1] = 0;
                blocActifY[2] = 1;
                blocActifY[3] = 1;
                //PositionX
                blocActifX[0] = 0;
                blocActifX[1] = 1;
                blocActifX[2] = 1;
                blocActifX[3] = 2;
            }

            return randomPiece;
        }
        //</scloutier>
        #endregion

        #region GenererTableauEtat
        //<scloutier>
        /// <summary>
        /// Génère le tableau des états à vide(None)
        /// </summary>
        /// <param name="nbLignes">Le nombre de ligne que le tableau va avoir</param>
        /// <param name="nbColonnes">Le nombre de colonne que le tableau va avoir</param>
        public void GenererTableauEtat(int nbLignes, int nbColonnes)
        {
            tableauEtats = new TypeEtat[nbLignes, nbColonnes];

            for (int i = 0; i < nbLignes; i++)
            {
                for (int j = 0; j < nbColonnes; j++)
                {
                    tableauEtats[i, j] = TypeEtat.NONE; // Initialisation au type -> None
                }
            }
        }
        //</scloutier>
        #endregion

        #region EffacerLigne
        // <aouellet>
        public void EffacerLigne(int nbDeLaLigneComplete)
        {
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                tableauEtats[nbDeLaLigneComplete, i] = (int)TypeEtat.NONE;
                toutesImagesVisuelles[nbDeLaLigneComplete, i].BackColor = Color.Black;
            }
        }
        //</aouellet>
        #endregion

        #region VerifierLigne
        //<aouellet>
        public List<int> VerifierLigne()
        {
            int nbLigneComplete = 0;
            bool ligneEstComplete = false;
            int compteurSiLigneComplete = 0;
            List<int> lignesCompleter = new List<int>();
            for (int i = 0; i < tableauEtats.GetLength(0); i++)
            {
                for (int j = 0; j < tableauEtats.GetLength(1); j++)
                {
                    if (tableauEtats[i, j] == TypeEtat.GELE)
                    {
                        compteurSiLigneComplete++;
                        if (compteurSiLigneComplete == tableauEtats.GetLength(1))
                        {
                            ligneEstComplete = true;
                            compteurSiLigneComplete = 0;
                            if (ligneEstComplete == true)
                            {
                                nbLigneComplete = i;
                                lignesCompleter.Add(i);
                            }
                        }
                    }
                    else
                    {
                        nbLigneComplete = 0;
                    }
                }
                compteurSiLigneComplete = 0;
            }
            return lignesCompleter;
        }
        #endregion

        #region ReinitialiserPictureBox
        //<scloutier>
        /// <summary>
        /// Réinitialise les couleurs des picturesBox à noirs
        /// Souvent utilisé pour recommencer une partie
        /// </summary>
        void ReinitialiserPictureBox()
        {
            for (int i = 0; i < tableauEtats.GetLength(0); i++)
            {
                for (int j = 0; j < tableauEtats.GetLength(1); j++)
                {
                    toutesImagesVisuelles[i, j].BackColor = Color.Black;
                }
            }
        }
        //</scloutier>
        #endregion

        #region btnStart_Click
        //<scloutier>
        /// <summary>
        /// Bouton qui démarre la partie du joueur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            partieEnCours = true;
            btnStart.Enabled = false;
            ReinitialiserPictureBox();
            ligneCourante = 0;
            colonneCourante = tableauEtats.GetLength(1) / 2 - 1;
            GenererTableauEtat(nbLignes, nbColonnes);
            pieceTableau = GenererPieceAleatoire();
            InitialiserPieceDansTableau(pieceTableau);
            timer3.Start();
            timer2.Start();
            timer1.Start();

        }
        //</scloutier>
        #endregion

        #region Deplacement
        //<scloutier>
        /// <summary>
        /// Énumération des types de déplacements qui vont être utilisé
        /// </summary>
        enum Deplacement
        {
            DESCENDRE,
            DROITE,
            GAUCHE,
            ROTATION_HORAIRE,
            ROTATION_ANTIHORAIRE,
            MONTER
        }
        //</scloutier>
        #endregion

        #region KeyPressDeplacement
        //<scloutier>
        /// <summary>
        /// Génére les mouvements lorsqu'une touche en particulier est appuyer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyPressDeplacement(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                mouvement = Deplacement.DESCENDRE;
                VerifierDeplacement(mouvement);
                if (deplacementPossible == true)
                {
                    EnleverAncienBloc();
                    ligneCourante++;
                    InitialiserPieceDansTableau(pieceTableau);
                }
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                mouvement = Deplacement.DROITE;
                VerifierDeplacement(mouvement);
                if (deplacementPossible == true)
                {

                    EnleverAncienBloc();
                    colonneCourante++;
                    InitialiserPieceDansTableau(pieceTableau);
                }
            }
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                mouvement = Deplacement.GAUCHE;
                VerifierDeplacement(mouvement);
                if (deplacementPossible == true)
                {
                    EnleverAncienBloc();
                    colonneCourante--;
                    InitialiserPieceDansTableau(pieceTableau);
                }
            }
            else if (e.KeyCode == Keys.E)
            {

                mouvement = Deplacement.ROTATION_HORAIRE;
                VerifierDeplacement(mouvement);
                if (deplacementPossible == true)
                {
                    EnleverAncienBloc();
                    int temp = 0;
                    for (int j = 0; j < blocActifX.Length; j++)
                    {
                        temp = -blocActifY[j];
                        blocActifY[j] = blocActifX[j];
                        blocActifX[j] = temp;
                    }
                    InitialiserPieceDansTableau(pieceTableau);
                }
            }
            else if (e.KeyCode == Keys.Q)
            {

                mouvement = Deplacement.ROTATION_ANTIHORAIRE;
                VerifierDeplacement(mouvement);
                if (deplacementPossible == true)
                {
                    EnleverAncienBloc();
                    int temp = 0;
                    for (int j = 0; j < blocActifX.Length; j++)
                    {
                        temp = -blocActifX[j];
                        blocActifX[j] = blocActifY[j];
                        blocActifY[j] = temp;
                    }
                    InitialiserPieceDansTableau(pieceTableau);
                }
            }
        }
        //</scloutier>
        #endregion

        #region VerifierDeplacement
        //<scloutier> & <aouellet>
        /// <summary>
        /// Vérifie les zones de déplacements avant de bouger un bloc pour ne pas avoir
        /// d'erreur tel qu'un "Out of range".
        /// </summary>
        /// <param name="sens"></param>
        /// <returns></returns>
        bool VerifierDeplacement(Deplacement sens)
        {
            if (sens == Deplacement.DESCENDRE)
            {
                for (int i = 0; i < blocActifY.Length; i++)
                {
                    if ((ligneCourante + 1 + blocActifY[i] <= tableauEtats.GetLength(0) - 1) &&
                           (int)tableauEtats[ligneCourante + 1 + blocActifY[i], colonneCourante + blocActifX[i]] <= tableauEtats.GetLength(0) - 1
                                && tableauEtats[ligneCourante + 1 + blocActifY[i], colonneCourante + blocActifX[i]] != TypeEtat.GELE)
                    {
                        deplacementPossible = true;
                    }
                    else
                    {
                        deplacementPossible = false;
                        GeleBlocs();
                        return deplacementPossible;
                    }
                }
            }
            else if (sens == Deplacement.GAUCHE)
            {
                for (int j = 0; j < blocActifX.Length; j++)
                {
                    if (colonneCourante - 1 + blocActifX[j] < 0)
                    {
                        deplacementPossible = false;
                        return false;
                    }
                    else if (tableauEtats[ligneCourante + blocActifY[j], colonneCourante - 1 + blocActifX[j]] == TypeEtat.GELE)
                    {
                        deplacementPossible = false;
                        return false;
                    }
                    else
                    {
                        deplacementPossible = true;
                    }
                }
            }

            else if (sens == Deplacement.DROITE)
            {
                for (int j = 0; j < blocActifX.Length; j++)
                {
                    if (colonneCourante + 1 + blocActifX[j] >= tableauEtats.GetLength(1))
                    {
                        deplacementPossible = false;
                        return false;
                    }
                    else if (tableauEtats[ligneCourante + blocActifY[j], colonneCourante + 1 + blocActifX[j]] == TypeEtat.GELE)
                    {
                        deplacementPossible = false;
                        return false;
                    }
                    else
                    {
                        deplacementPossible = true;
                    }
                }
            }
            else if (sens == Deplacement.ROTATION_HORAIRE)
            {
                for (int i = 0; i < blocActifX.Length; i++)
                {
                    nouveauBlocActifX[i] = -blocActifY[i];
                    nouveauBlocActifY[i] = blocActifX[i];

                    if (ligneCourante + blocActifX[i] > tableauEtats.GetLength(0) - 1 || ligneCourante + blocActifX[i] < 0 || colonneCourante - blocActifY[i] > tableauEtats.GetLength(1) - 1 || colonneCourante - blocActifY[i] < 0)
                    {
                        deplacementPossible = false;
                        return false;
                    }
                    else if (tableauEtats[ligneCourante + blocActifX[i], colonneCourante - blocActifY[i]] == TypeEtat.GELE)
                    {
                        deplacementPossible = false;
                        return false;
                    }
                    else if (pieceTableau == TypeEtat.CARRE)
                    {
                        deplacementPossible = false;
                        return false;
                    }
                }
            }
            else if (sens == Deplacement.ROTATION_ANTIHORAIRE)
            {
                for (int i = 0; i < blocActifX.Length; i++)
                {
                    nouveauBlocActifX[i] = blocActifY[i];
                    nouveauBlocActifY[i] = -blocActifX[i];

                    if (ligneCourante - blocActifX[i] < tableauEtats.GetLength(1) || ligneCourante + blocActifX[i] < 0 || colonneCourante - blocActifY[i] > tableauEtats.GetLength(1) - 1 || colonneCourante - blocActifY[i] < 0)
                    {
                        deplacementPossible = false;
                        return false;
                    }
                    else if (tableauEtats[ligneCourante - blocActifX[i], colonneCourante + blocActifY[i]] == TypeEtat.GELE)
                    {
                        deplacementPossible = false;
                        return false;
                    }
                    else if (pieceTableau == TypeEtat.CARRE)
                    {
                        deplacementPossible = false;
                        return false;
                    }
                }
            }
            return deplacementPossible;
        }
        //<scloutier> & <aouellet>
        #endregion

        //<aouellet>
        /// <summary>
        /// 
        /// </summary>
        void GeleBlocs()
        {
            for (int i = 0; i < blocActifY.Length; i++)
            {
                tableauEtats[ligneCourante + blocActifY[i], colonneCourante + blocActifX[i]] = TypeEtat.GELE;
                toutesImagesVisuelles[ligneCourante + blocActifY[i], colonneCourante + blocActifX[i]].BackColor = Color.Gray;
            }
            pieceTableau = GenererPieceAleatoire();                              //Il faudrait possiblement bouger ce code
            ligneCourante = 0;
            colonneCourante = tableauEtats.GetLength(1) / 2 - 1;
            InitialiserPieceDansTableau(pieceTableau);
        }
        //</aouellet>

        //<aouellet>
        /// <summary>
        /// 
        /// </summary>
        void EnleverAncienBloc()
        {
            for (int i = 0; i < blocActifY.Length; i++)
            {
                for (int j = 0; j < blocActifX.Length; j++)
                {
                    if (tableauEtats[ligneCourante + blocActifY[i], colonneCourante + blocActifX[j]] != TypeEtat.NONE)
                    {
                        tableauEtats[ligneCourante + blocActifY[i], colonneCourante + blocActifX[j]] = TypeEtat.NONE;
                        toutesImagesVisuelles[ligneCourante + blocActifY[i], colonneCourante + blocActifX[j]].BackColor = Color.Black;
                    }
                }
            }
        }
        //</aouellet>

        #region timer1 Tick
        // <scloutier> & <aouellet>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            VerifierFinDePartie();
            if (partieEnCours == false)
            {
                FormStatistique stats = new FormStatistique(this);
                stats.Show();
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
            }
            else
            {
                VerifierDeplacement(Deplacement.DESCENDRE);
                if (deplacementPossible == true)
                {
                    EnleverAncienBloc();
                    ligneCourante++;
                    InitialiserPieceDansTableau(pieceTableau);
                    List<int> nbLigneADecaler = VerifierLigne();
                    foreach (int ligne in nbLigneADecaler)
                    {
                        EffacerLigne(ligne);
                        DecalerLignes(ligne);
                        DessinerTableau();
                    }
                    score += nbLigneADecaler.Count * 100;

                }
            }
        }
        //</scloutier> & </aouellet>
        #endregion

        #region VerifierFinDePartie
        //<scloutier>
        /// <summary>
        /// Vérifie si la partie est terminé en regardant si les blocs
        /// qui apparaissent sont gelés quand un nouveau bloc apparait
        /// </summary>
        void VerifierFinDePartie()
        {
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                if (tableauEtats[0, i] == TypeEtat.GELE)
                {
                    partieEnCours = false;
                }
            }
        }
        #endregion

        //<scloutier>
        /// <summary>
        /// Timer qui sert à compter le nombre de temps de jeu en seconde.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void timer2_Tick(object sender, EventArgs e)
        {
            nbDeSeconde++;
        }

        //<aouellet>
        void DecalerLignes(int nbLigneADecaler)
        {
            for (int i = nbLigneADecaler; i > 0; i--)
            {
                for (int j = 0; j < tableauEtats.GetLength(1); j++)
                {
                    if (tableauEtats[i, j] == TypeEtat.GELE || tableauEtats[i, j] == TypeEtat.NONE)
                    {
                        tableauEtats[i, j] = tableauEtats[i - 1, j];
                    }
                }
            }
            for (int x = 0; x < tableauEtats.GetLength(1); x++)
            {
                tableauEtats[0, x] = TypeEtat.NONE;
            }
        }
        //</aouellet>

        //<aouellet>
        void DessinerTableau()
        {
            for (int i = 0; i < tableauEtats.GetLength(0); i++)
            {
                for (int j = 0; j < tableauEtats.GetLength(1); j++)
                {
                    if (tableauEtats[i, j] == TypeEtat.CARRE)
                    {
                        toutesImagesVisuelles[i, j].BackColor = Color.Yellow;
                    }
                    else if (tableauEtats[i, j] == TypeEtat.NONE)
                    {
                        toutesImagesVisuelles[i, j].BackColor = Color.Black;
                    }
                    else if (tableauEtats[i, j] == TypeEtat.GELE)
                    {
                        toutesImagesVisuelles[i, j].BackColor = Color.Gray;
                    }
                    else if (tableauEtats[i, j] == TypeEtat.LIGNE)
                    {
                        toutesImagesVisuelles[i, j].BackColor = Color.Blue;
                    }
                    else if (tableauEtats[i, j] == TypeEtat.S)
                    {
                        toutesImagesVisuelles[i, j].BackColor = Color.Red;
                    }
                    else if (tableauEtats[i, j] == TypeEtat.Z)
                    {
                        toutesImagesVisuelles[i, j].BackColor = Color.Pink;
                    }
                    else if (tableauEtats[i, j] == TypeEtat.J)
                    {
                        toutesImagesVisuelles[i, j].BackColor = Color.OrangeRed;
                    }
                    else if (tableauEtats[i, j] == TypeEtat.L)
                    {
                        toutesImagesVisuelles[i, j].BackColor = Color.Green;
                    }
                    else
                    {
                        toutesImagesVisuelles[i, j].BackColor = Color.Purple;
                    }
                }
            }

        }

        //<scloutier> J'ai fais mes statistiques très en retard, il est très possible des optimisés bien plus que sa
        /// <summary>
        /// Permet d'afficher les statistiques de jeux en les gardant à jour
        /// grâce au tick Timer3
        /// </summary>
        void StatistiqueEnJeu()
        {
            if (pieceTableau != TypeEtat.NONE || pieceTableau != TypeEtat.GELE)
            {
                nbDePieceJouer++;

                if (pieceTableau == TypeEtat.CARRE)
                {
                    nbDeCarre++;
                }
                else if (pieceTableau == TypeEtat.LIGNE)
                {
                    nbDeLigne++;
                }
                else if (pieceTableau == TypeEtat.T)
                {
                    nbDeT++;
                }
                else if (pieceTableau == TypeEtat.L)
                {
                    nbDeL++;
                }
                else if (pieceTableau == TypeEtat.S)
                {
                    nbDeS++;
                }
                else if (pieceTableau == TypeEtat.Z)
                {
                    nbDeZ++;
                }
                else if (pieceTableau == TypeEtat.J)
                {
                    nbDeJ++;
                }
            }

            nbDeCarrePourcentage = nbDeCarre * 100 / nbDePieceJouer;
            lblnbDeCarre.Text = nbDeCarrePourcentage.ToString() + " %";

            nbDeLignePourcentage = nbDeLigne * 100 / nbDePieceJouer;
            lblnbDeLigne.Text = nbDeLignePourcentage.ToString() + " %";

            nbDeTPourcentage = nbDeT * 100 / nbDePieceJouer;
            lblnbDeT.Text = nbDeTPourcentage.ToString() + " %";

            nbDeLPourcentage = nbDeL * 100 / nbDePieceJouer;
            lblnbDeL.Text = nbDeLPourcentage.ToString() + " %";

            nbDeSPourcentage = nbDeS * 100 / nbDePieceJouer;
            lblnbDeS.Text = nbDeSPourcentage.ToString() + " %";

            nbDeZPourcentage = nbDeZ * 100 / nbDePieceJouer;
            lblnbDeZ.Text = nbDeSPourcentage.ToString() + " %";

            nbDeJPourcentage = nbDeJ * 100 / nbDePieceJouer;
            lblnbDeJ.Text = nbDeJPourcentage.ToString() + " %";

            lblNbDeSecondes.Text = nbDeSeconde.ToString() + " secondes";
        }

        //<scloutier>
        /// <summary>
        /// Timer qui sert à "update" les statistiques du jeu en cour
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer3_Tick(object sender, EventArgs e)
        {
            StatistiqueEnJeu();
        }
        //</scloutier>

        //<aouellet>
        void GererScore()
        {
            scoreLabel.Text = score.ToString();
        }
        //</aouellet>
    }
}
