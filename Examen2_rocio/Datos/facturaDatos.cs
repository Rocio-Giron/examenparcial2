using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class facturaDatos
    {
        public async Task<DataTable> DevolverListaAsync()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM factura;";
                using (MySqlConnection _conexion = new MySqlConnection(conexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        MySqlDataReader dr = (MySqlDataReader)await comando.ExecuteReaderAsync();
                        dt.Load(dr);
                    }
                }
            }
            catch (Exception ex)
            {

                //throw;
            }
            return dt;
        }


        public async Task<bool> InsertarAsync(factura factura)
        {
            bool inserto = false;
            try
            {
                string sql = "INSERT INTO factura VALUES(@codigo, @nombrecliente, @descrip, @descripcionRes, @precio, @ISV, @descuento,@SubTotal,@total);";
                using (MySqlConnection _conexion = new MySqlConnection(conexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        //comando.Parameters.Add("@codigo", MySqlDbType.Int32).Value = factura.codigo;
                        //comando.Parameters.Add("@fecha", MySqlDbType.DateTime).Value = factura.fecha;
                        //comando.Parameters.Add("@codigoUsuario", MySqlDbType.VarChar, 45).Value = factura.codigoUsuario;
                        comando.Parameters.Add("@nombreCliente", MySqlDbType.VarChar, 25).Value = factura.nombrecliente;
                        comando.Parameters.Add("@descrip", MySqlDbType.VarChar, 45).Value = factura.descrip;
                        comando.Parameters.Add("@descripRes", MySqlDbType.VarChar, 45).Value = factura.descripcionRes;
                        //comando.Parameters.Add("@precio", MySqlDbType.Decimal).Value = factura.precio;
                        comando.Parameters.Add("@ISV", MySqlDbType.Decimal).Value = factura.ISV;
                        comando.Parameters.Add("@descuento", MySqlDbType.Decimal).Value = factura.descuento;
                        comando.Parameters.Add("@subTotal", MySqlDbType.Decimal).Value = factura.subTotal;
                        comando.Parameters.Add("@total", MySqlDbType.Decimal).Value = factura.total;
                        //comando.Parameters.Add("@codigoTipo", MySqlDbType.VarChar, 45).Value = factura.CodigoTipo;

                        await comando.ExecuteNonQueryAsync();
                        inserto = true;
                    }
                }
            }
            catch (Exception)
            {

                //  throw;
            }
            return inserto;
        }
    }
}
