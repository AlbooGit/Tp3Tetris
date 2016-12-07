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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(principal.nbDeSeconde >= 60)
            {
                principal.nbDeSeconde = principal.nbDeSeconde / 60;
                textBox1.Text = principal.nbDeSeconde.ToString();
            }
        }
    }
}
