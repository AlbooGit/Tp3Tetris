using System;
using System.Drawing;
using System.Windows.Forms;

namespace TP3
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            FormConfiguration config = new FormConfiguration(this);
            InitializeComponent();
        }

        int[] blocActifY = new int[4];
        int[] blocActifX = new int[4];
        int ligneCourante = 0;
        int colonneCourante = 0;


        // Représentation visuelles du jeu en mémoire.
        PictureBox[,] toutesImagesVisuelles = null;
        public int nbLignes = 20;
        public int nbColonnes = 10;
        TypeEtat[,] tableauEtats = new TypeEtat[20, 10];

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
            GenererTableauEtat(nbLignes = 20, nbColonnes = 10);
        }

        void InitialiserPieceDansTableau()
        {
            TypeEtat randomPiece = GenererPieceAleatoire();
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

        void blocDescend()
        {
            for (int i = 0; i < blocActifY.Length - 1; i++)
            {
                if (tableauEtats[ligneCourante + blocActifY[i + 1], colonneCourante + blocActifX[i]] == TypeEtat.GELE)
                {
                    tableauEtats[ligneCourante + blocActifY[i], colonneCourante + blocActifX[i]] = tableauEtats[ligneCourante + 1 + blocActifY[i], colonneCourante + 1 + blocActifX[i]];
                }
            }
        }


        // <scloutier>
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
        //</scloutier>j

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nbLignes"></param>
        /// <param name="nbColonnes"></param>
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

        public void EffacerLigne(int nbDeLaLigneComplete)
        {
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                tableauEtats[nbDeLaLigneComplete, i] = (int)TypeEtat.NONE;
            }
        }

        //<aouellet>
        public int VerifierLigne()
        {
            int nbLigneComplete = 0;
            bool ligneEstComplete = false;
            int compteurSiLigneComplete = 0;
            for (int i = 0; i < tableauEtats.GetLength(0); i++)
            {

                for (int j = 0; j < tableauEtats.GetLength(1); j++)
                {


                    if (tableauEtats[i, j] == TypeEtat.GELE)
                    {
                        compteurSiLigneComplete++;
                    }

                    if (compteurSiLigneComplete == tableauEtats.GetLength(1))
                    {
                        ligneEstComplete = true;
                        compteurSiLigneComplete = 0;
                    }


                    if (ligneEstComplete == true)
                    {
                        nbLigneComplete = i;
                    }
                    else
                    {
                        nbLigneComplete = 0;
                    }

                }
                compteurSiLigneComplete = 0;
            }
            return nbLigneComplete;
        }



        void RotationPiece()
        {

        }

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

        private void btnStart_Click(object sender, EventArgs e)
        {
            ReinitialiserPictureBox();
            ligneCourante = 0;
            colonneCourante = tableauEtats.GetLength(1) / 2 - 1;
            GenererTableauEtat(nbLignes, nbColonnes);
            InitialiserPieceDansTableau();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            blocDescend();
        }
    }
}
