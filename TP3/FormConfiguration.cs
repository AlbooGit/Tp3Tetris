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
        FormPrincipal principal = new FormPrincipal();

        public FormConfiguration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void btnOkConfig_Click(object sender, EventArgs e)
        {

            principal.InitialiserSurfaceDeJeu((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            Close();
        }

        public void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        public void ConfigurationJeu()
        {
            
        }
    }
}
