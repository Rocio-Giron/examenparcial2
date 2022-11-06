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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Examen2
{
    public partial class Tickes : Form
    {
        public Tickes()
        {
            InitializeComponent();
        }
        tipo tipo ;
        string tipoOperacion=String.Empty;
       // List<detalleFactura>detalles=new List<detalleFactura>();
        factura factura;
        facturaDatos facturaDato= new facturaDatos();
        decimal subTotal = 0;
        decimal isv = 0;
        decimal total = 0;
        string usuario = System.Threading.Thread.CurrentPrincipal.Identity.Name;

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           

        }

        private void Tickes_Load(object sender, EventArgs e)
        {
           
            txtusuario.Text = variableGlobal.Usuariologin;
            txtusuario.ReadOnly = true;
            llenarsoporte();

            //txtdesc.Text = "0.00";
        }
        private async  void llenarsoporte()
        {
            dataGridView1.DataSource = await facturaDato.DevolverListaAsync();
        }

        private async void txttipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tipoDato tiposDatos = new tipoDato();
                tipo = new tipo();

                tipo = await tiposDatos.Gettipocodigo((txttipo.Text));

                if (tipo.codigo !=null)
                {
                    txtdescrip.Text = tipo.descripcion;
                    txtprecio.Text = tipo.precio.ToString();
                    txtsub.Text = tipo.precio.ToString();

                }
                else
                {
                    errorProvider1.SetError(txtdescrip, "No existe el producto");
                }
            }
        }
        private void txtprecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                   txtsub.Text = factura.subTotal.ToString();
                   // txtprecio.Text=txtsub.Text+txtprecio.Text;
                    //subTotal += detalle.Total;
                    isv = subTotal * 0.15M;
                    total = subTotal + isv - Convert.ToDecimal(txtdesc.Text);

                    ISV.Text = isv.ToString("N");
                    txtsub.Text = subTotal.ToString("N");
                    txttotal.Text = total.ToString("N");

                    //ExistenciaTextBox.Text = (producto.Existencia - Convert.ToInt32(CantidadTextBox.Text)).ToString();

                

            }
        }
            private async void button1_Click(object sender, EventArgs e)
        {
            
            factura = new factura();
           
            

            
           // factura.codigoUsuario = txtusuario.Text;
            //factura.fecha = dateTimePicker1.Value;
            //factura.codigoUsuario = txtusuario.Text;
            //factura.precio = Convert.ToDecimal(txtprecio.Text);
            factura.ISV = Convert.ToDecimal (ISV.Text);
            factura.subTotal = Convert.ToDecimal(txtsub.Text);
            factura.descuento = Convert.ToDecimal(txtdesc.Text);
            factura.total = Convert.ToDecimal(txttotal.Text);
            factura.nombrecliente = txtnombreCli.Text;
           // factura.CodigoTipo = txttipo.Text;

            facturaDato = new facturaDatos();
            bool inserto = await facturaDato.InsertarAsync(factura);

            if (inserto)
            {
                MessageBox.Show("Factura guardada");
                llenarsoporte();
            }
            else
            {
                MessageBox.Show("Factura  guardada");

            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ISV.Text = (Convert.ToInt32(txtsub.Text) * 15/100).ToString();
            txtdesc.Text = (Convert.ToInt32(txtsub.Text) * 10 / 100).ToString();
            txttotal.Text = ((Convert.ToInt16(txtsub.Text)+ Convert.ToInt16(ISV.Text))- Convert.ToInt16(txtdesc.Text)).ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
           // tipoOperacion = "Nuevo";
        }
    }
    
}
