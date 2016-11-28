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
    public partial class FormConfiguration : Form
    {
        

        public FormConfiguration()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tBoxNbLignes_TextChanged(object sender, EventArgs e)
        {
            FormPrincipal principal = new FormPrincipal();
            principal.nbLignes = Convert.ToInt32(tBoxNbLignes.Text);
        }

        private void btnOkConfig_Click(object sender, EventArgs e)
        {

        }
    }
}
