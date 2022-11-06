using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vista;

namespace Examen2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (txtusuario.Text == String.Empty)
            {
                errorProvider1.SetError(txtusuario, "Ingrese un código de usuario");
                txtusuario.Focus();
                return;
            }
            errorProvider1.Clear();
            if (txtclave.Text == String.Empty)
            {
                errorProvider1.SetError(txtclave, "Ingrese una clave");
                txtclave.Focus();
                return;
            }
            errorProvider1.Clear();

            UsuarioDato userDatos = new UsuarioDato();
            bool valido = await userDatos.loginAsync(txtusuario.Text, txtclave.Text);
            if (valido)
            {
                menu formulario = new menu();
                variableGlobal.Usuariologin = txtusuario.Text;
                Hide();
                formulario.Show();
            }
            else
            {
                MessageBox.Show("Datos de usuario incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
