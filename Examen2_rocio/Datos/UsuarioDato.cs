using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class UsuarioDato
    {
        public async Task<bool> loginAsync(string codigo, string clave)
        {
            bool valido = false;
            try
            {
                string sql = "SELECT 1 FROM usuario WHERE codigo=@codigo AND clave=@clave;";
                using (MySqlConnection _conexion = new MySqlConnection(conexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType=System.Data.CommandType.Text;
                        comando.Parameters.Add("@codigo", MySqlDbType.VarChar, 35).Value = codigo;
                        comando.Parameters.Add("@clave", MySqlDbType.VarChar, 35).Value= clave;
                        valido = Convert.ToBoolean(await comando.ExecuteScalarAsync());
                    }
                }

            }
            catch(Exception ex)
            {

            }
            return valido;
        }
    }
}
