using System;
using System.Drawing;
using System.Windows.Forms;

namespace TP3
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            GenererTableauEtat(nbLignes, nbColonnes);
            FormConfiguration config = new FormConfiguration(this);
            InitializeComponent();
        }

        int[,] blocActif = new int[3, 3];
        int[,] blocActifLigneCarre = new int[4, 4];



        // Représentation visuelles du jeu en mémoire.
        PictureBox[,] toutesImagesVisuelles = null;
        public int nbLignes = 20;
        public int nbColonnes = 10;
        int[,] tableauEtats = new int[20, 10];

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

        #region Code à développer
        /// <summary>
        /// Faites ici les appels requis pour vos tests unitaires.
        /// </summary>
        void ExecuterTestsUnitaires()
        {
            ExecuterTestABC();
            // A compléter...
        }

        // A renommer et commenter!
        void ExecuterTestABC()
        {
            // Mise en place des données du test

            // Exécuter de la méthode à tester

            // Validation des résultats

            // Clean-up
        }

        #endregion

        private void configurationDuJeuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConfiguration config = new FormConfiguration(this);
            config.numericUpDown1.Value = nbLignes;
            config.numericUpDown2.Value = nbColonnes;
            config.ShowDialog();
        }

        private void quittezToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void réinitialiséPartieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitialiserSurfaceDeJeu(nbLignes = 20, nbColonnes = 10);
        }

        void InitialiserPieceDansTableau(int pieceRandom)
        {
            //for (int i = 0; i < )



        }

        int GenererEtatPiece()
        {
            Random rnd = new Random();
            int randomPiece = rnd.Next(2, 2);

            if (randomPiece == 2) //Si bloc carré
            {
                blocActifLigneCarre[0, 0] = (int)TypeEtat.CARRE;
                blocActifLigneCarre[0, 1] = (int)TypeEtat.CARRE;
                blocActifLigneCarre[1, 0] = (int)TypeEtat.CARRE;
                blocActifLigneCarre[1, 1] = (int)TypeEtat.CARRE;
            }
            else if (randomPiece == 3) //Si bloc ligne
            {

            }
            else if (randomPiece == 4) //Si bloc T
            {

            }
            else if (randomPiece == 5) //Si bloc L
            {

            }
            else if (randomPiece == 6) //Si bloc J
            {

            }
            else //Si bloc S
            {

            }

            return randomPiece;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nbLignes"></param>
        /// <param name="nbColonnes"></param>
        public void GenererTableauEtat(int nbLignes, int nbColonnes)
        {
            tableauEtats = new int[nbLignes, nbColonnes];

            for (int i = 0; i < nbLignes; i++)
            {
                for (int j = 0; j < nbColonnes; j++)
                {
                    tableauEtats[i, j] = (int)TypeEtat.NONE; // Initialisation au type -> None
                }
            }
        }

    }
}
