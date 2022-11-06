using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen2
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void ingresarLosTiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tipos usuarioform = new tipos();
            usuarioform.Show();
        }

        private void ingresarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tickes tic = new Tickes();
            tic.Show();
        }
    }
}
