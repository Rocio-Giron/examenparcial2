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
    public class tipoDato
    {
        public async Task<DataTable> DevolverListaAsync()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM tipo;";
                using (MySqlConnection _conexion = new MySqlConnection(conexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType =System.Data.CommandType.Text;
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

         public async Task<bool>InsertarAsync(tipo tipo)
        {
            bool inserto = false;
            try
            {
                string sql = "INSERT INTO tipo VALUES(@codigo, @nombre, @descripcion, @precio);";
                using (MySqlConnection _conexion = new MySqlConnection(conexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using ( MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@codigo", MySqlDbType.VarChar, 45).Value = tipo.codigo;
                        comando.Parameters.Add("@nombre", MySqlDbType.VarChar, 45).Value = tipo.nombre;
                        comando.Parameters.Add("@descripcion", MySqlDbType.VarChar, 45).Value=tipo.descripcion;
                        comando.Parameters.Add("@precio", MySqlDbType.Decimal).Value = tipo.precio;

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
        public async Task<bool>ActualizarAsync(tipo tipo)
        {
            bool actualizo = false;
            try
            {
                string sql = "UPDATE tipo SET nombre=@nombre, descripcion=@descripcion, precio=@precio,  WHERE Codigo=@Codigo;";

                using (MySqlConnection _conexion = new MySqlConnection(conexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@codigo", MySqlDbType.VarChar, 45).Value = tipo.codigo;
                        comando.Parameters.Add("@nombre", MySqlDbType.VarChar, 45).Value = tipo.nombre;
                        comando.Parameters.Add("@descripcion", MySqlDbType.VarChar, 45).Value = tipo.descripcion;
                        comando.Parameters.Add("@Precio", MySqlDbType.Decimal).Value = tipo.precio;
                       

                        await comando.ExecuteNonQueryAsync();
                        actualizo = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return actualizo;
        }
        public async Task<bool>EliminarAsync(string codigo)
        {
            bool elimino = false;
            try
            {
                string sql = "DELETE FROM tipo WHERE codigo = @codigo;";

                using (MySqlConnection _conexion = new MySqlConnection(conexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@codigo", MySqlDbType.VarChar, 45).Value = codigo;
                        await comando.ExecuteNonQueryAsync();
                        elimino = true;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return elimino;
        }
        public async Task<tipo> Gettipocodigo(string codigo)
        {
            tipo tipo = new tipo();
            try
            {
                string sql = "SELECT * FROM tipo WHERE codigo = @codigo;";

                using (MySqlConnection _conexion = new MySqlConnection(conexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Codigo", MySqlDbType.Int32).Value = codigo;

                        MySqlDataReader dr = (MySqlDataReader)await comando.ExecuteReaderAsync();
                        if (dr.Read())
                        {
                             tipo.codigo= dr["codigo"].ToString();
                            tipo.nombre = dr["nombre"].ToString();
                            tipo.descripcion = dr["descripcion"].ToString();
                            tipo.precio = Convert.ToDecimal(dr["precio"]);
                            
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return tipo;
        }
    
    }
}
