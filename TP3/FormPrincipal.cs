﻿using System;
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

        // Déclaration des tableaux pour le blocActif
        // 3x3 = L, S, T, J, Z
        // 4x4 = Ligne et Carré     
        int[,] blocActif = new int[3, 3];
        int[,] blocActifCarreLigne = new int[4, 4];

        // Représentation visuelles du jeu en mémoire.

        PictureBox[,] toutesImagesVisuelles = null;
        public int nbLignes = 20;
        public int nbColonnes = 10;

        #region CodeProf
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

        #endregion

        #region InitialiserTableauEtat 
        // <scloutier>
        void InitialiserTableauEtat(int nbLignes, int nbColonnes)
        {
            int[,] tableauEtats = new int[nbLignes, nbColonnes];

            for (int i = 0; i < nbLignes; i++)
            {
                for (int j = 0; j < nbColonnes; j++)
                {
                    tableauEtats[i, j] = 2;
                }
            }

        }
        // </scloutier>
        #endregion
        
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

        void InitialiserPiece()
        {
            Random rnd = new Random();
            int randomPiece = rnd.Next(2, 8);

            if (randomPiece == 2)
            {

            }

        }
    }








}
