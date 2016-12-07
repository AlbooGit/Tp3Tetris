using System;
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
    public partial class FormStatistique : Form
    {
        FormPrincipal principal;

        public FormStatistique(FormPrincipal formPrincipal)
        {
            InitializeComponent();
            this.principal = formPrincipal;
            label2.Text = principal.nbDeSeconde.ToString() + " secondes";

            label11.Text = principal.nbDeCarre.ToString();
            lblnbDeCarre.Text = principal.nbDeCarrePourcentage.ToString() + " %";

            label12.Text = principal.nbDeLigne.ToString();
            lblnbDeLigne.Text = principal.nbDeLignePourcentage.ToString() + " %";

            label13.Text = principal.nbDeT.ToString();
            lblnbDeT.Text = principal.nbDeTPourcentage.ToString() + " %";

            label14.Text = principal.nbDeJ.ToString();
            lblnbDeJ.Text = principal.nbDeJPourcentage.ToString() + " %";

            label15.Text = principal.nbDeL.ToString();
            lblnbDeL.Text = principal.nbDeLPourcentage.ToString() + " %";

            label16.Text = principal.nbDeS.ToString();
            lblnbDeS.Text = principal.nbDeSPourcentage.ToString() + " %";

            label17.Text = principal.nbDeZ.ToString();
            lblnbDeZ.Text = principal.nbDeZPourcentage.ToString() + " %";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
