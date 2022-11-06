using Datos;
using Entidades;
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
    public partial class tipos : Form
    {
        public tipos()
        {
            InitializeComponent();
        }
        tipoDato tiDato = new tipoDato();
        tipo tipo;
        string tipoOperacion = string.Empty;

        private void button1_Click(object sender, EventArgs e)
        {
            tipoOperacion = "Nuevo";
             Habilitarcontroles();
        }

        private void tipos_Load(object sender, EventArgs e)
        {
            LLenarDatos();
        }
        private async void LLenarDatos()
        {
            dataGridView1.DataSource = await tiDato.DevolverListaAsync();

        }
        private void Habilitarcontroles()
        {
            txtcodigo.Enabled = true;
            txtsoporte.Enabled = true;
            txtdescrip.Enabled = true;
            txtprecio.Enabled = true;
        }
        private void LimpiarControles()
        {
            txtcodigo.Clear();
            txtsoporte.Clear();
            txtdescrip.Clear();
            txtprecio.Clear();
        }
        private void DesabilitarControles()
        {
            txtcodigo.Enabled = false;
            txtsoporte.Enabled = false;
            txtdescrip.Enabled = false;
            txtprecio.Enabled = false;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                tipoOperacion = "Modificar";
                Habilitarcontroles();
                txtcodigo.ReadOnly = true;
                txtcodigo.Text = dataGridView1.CurrentRow.Cells["codigo"].Value.ToString();
                txtsoporte.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
                txtdescrip.Text = dataGridView1.CurrentRow.Cells["descripcion"].Value.ToString();
                txtprecio.Text = dataGridView1.CurrentRow.Cells["precio"].Value.ToString();
            }

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcodigo.Text))
            {
                errorProvider1.SetError(txtcodigo, "Ingrese el codigo");
                txtcodigo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtsoporte.Text))
            {
                errorProvider1.SetError(txtsoporte, "Ingrese el tipo");
                txtsoporte.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtdescrip.Text))
            {
                errorProvider1.SetError(txtdescrip, "Ingrese una descripcion");
                txtdescrip.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtprecio.Text))
            {
                errorProvider1.SetError(txtprecio, "Ingrese un precio");
                txtprecio.Focus();
                return;
            }

            tipo = new tipo();
            tipo.codigo = txtcodigo.Text;
            tipo.nombre = txtsoporte.Text;
            tipo.descripcion = txtdescrip.Text;
            tipo.precio = Convert.ToDecimal(txtprecio.Text);
            if (tipoOperacion == "Nuevo")
            {
                bool inserto = await tiDato.InsertarAsync(tipo);
                if (inserto)
                {
                    LLenarDatos();
                    LimpiarControles();
                    DesabilitarControles();
                    MessageBox.Show("Producto Guardado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Producto no se pudo guardar", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (tipoOperacion == "Modificar")
            {
                bool modifico = await tiDato.ActualizarAsync(tipo);
                if (modifico)
                {
                    LLenarDatos();
                    LimpiarControles();
                    DesabilitarControles();
                    MessageBox.Show("Producto Guardado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Producto no se pudo guardar", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
           // variableGlobal.dactura = txtcodigo.Text;
            //variableGlobal.dactura = txtdescrip.Text;
           // variableGlobal.dactura = txtprecio.Text;
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                bool elimino = await tiDato.EliminarAsync(dataGridView1.CurrentRow.Cells["codigo"].Value.ToString());
                if (elimino)
                {
                    LLenarDatos();
                    MessageBox.Show("Producto Eliminado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Producto no se pudo eliminar", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtprecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
