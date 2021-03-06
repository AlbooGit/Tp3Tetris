﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP3
{
    public partial class FormConfiguration : Form
    {
        FormPrincipal principal;

        public FormConfiguration(FormPrincipal formPrincipal)
        {
            InitializeComponent();
            this.principal = formPrincipal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// <aouellet>Bouton qui initialise un nouveau tableau avec de nouvelle dimensions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnOkConfig_Click(object sender, EventArgs e)
        {

            principal.InitialiserSurfaceDeJeu(principal.nbLignes = (int)numericUpDown1.Value, principal.nbColonnes = (int)numericUpDown2.Value);
            principal.GenererTableauEtat(principal.nbLignes = (int)numericUpDown1.Value, principal.nbColonnes = (int)numericUpDown2.Value);
            this.Close();
        }

        public void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        public void ConfigurationJeu()
        {

        }

        /// <summary>
        /// <scloutier> Reinitialise les valeurs du tableau de jeu à celle d'origine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 20;
            numericUpDown2.Value = 10;
            principal.InitialiserSurfaceDeJeu(principal.nbLignes = (int)numericUpDown1.Value, principal.nbColonnes = (int)numericUpDown2.Value);
            principal.GenererTableauEtat(principal.nbLignes = (int)numericUpDown1.Value, principal.nbColonnes = (int)numericUpDown2.Value);
        }
    }
}
