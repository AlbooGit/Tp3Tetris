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

        #region Variable Partagées

        int[] blocActifY = new int[4];
        int[] blocActifX = new int[4];
        int ligneCourante = 0;
        int colonneCourante = 0;
        Deplacement mouvement = 0;
        // Représentation visuelles du jeu en mémoire.
        PictureBox[,] toutesImagesVisuelles = null;
        public int nbLignes = 20;
        public int nbColonnes = 10;
        TypeEtat[,] tableauEtats = new TypeEtat[20, 10];
        TypeEtat pieceTableau;

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

        #region configDuJeuToolStripMenuItem_Click
        private void configurationDuJeuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region configurationToolStripMenuItem_Clicl
        //<scloutier>
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
        private void quittezToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //</scloutier>
        #endregion

        #region réinitialiséPartieToolStripMenuItem_Click
        //<scloutier>
        private void réinitialiséPartieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            InitialiserSurfaceDeJeu(nbLignes = 20, nbColonnes = 10);
            GenererTableauEtat(nbLignes = 20, nbColonnes = 10);
        }
        //</scloutier>
        #endregion

        #region InitialiserPieceDansTableau
        //<scloutier>
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

        void blocDescend()
        {

        }

        #region GenererPieceAleatoire
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
        //</scloutier>
        #endregion

        #region GenererTableauEtat
        //<scloutier>
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
        //</scloutier>
        #endregion

        #region EffacerLigne
        public void EffacerLigne(int nbDeLaLigneComplete)
        {
            for (int i = 0; i < tableauEtats.GetLength(1); i++)
            {
                tableauEtats[nbDeLaLigneComplete, i] = (int)TypeEtat.NONE;
            }
        }
        #endregion

        #region VerifierLigne
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
        #endregion


        void RotationPiece()
        {

        }

        #region ReinitialiserPictureBox
        ////<scloutier>
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
        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            ReinitialiserPictureBox();
            ligneCourante = 0;
            colonneCourante = tableauEtats.GetLength(1) / 2 - 1;
            GenererTableauEtat(nbLignes, nbColonnes);
            pieceTableau = GenererPieceAleatoire();
            InitialiserPieceDansTableau(pieceTableau);
            
        }
        //</scloutier>
        #endregion

        #region Deplacement
        //<scloutier>
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
        private void KeyPressDeplacement(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                ligneCourante++;
                ReinitialiserPictureBox();
                InitialiserPieceDansTableau(pieceTableau);
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                mouvement = Deplacement.DROITE;
            }
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                mouvement = Deplacement.GAUCHE;
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                mouvement = Deplacement.MONTER;
            }
        }
        //</scloutier>
        #endregion

        #region mouvementDescendre
        //<scloutier>
        void mouvementDescendre(Deplacement sens)
        {
            if (sens == Deplacement.DESCENDRE)
            {
                ligneCourante++;
                ReinitialiserPictureBox();
                InitialiserPieceDansTableau(pieceTableau);
            }
        }
        //</scloutier>
        #endregion
    }
}
