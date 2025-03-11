using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Usuarios
    {
        public List<Usuario> Listar() { 
             List<Usuario> lista = new List<Usuario>();
            
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cnn))
                {
                    string sql = "select * from Usuario";
                    SqlCommand cmd = new SqlCommand(sql, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Usuario()
                                {
                                    IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                    Nombres = dr["Nombres"].ToString(),
                                    Apellidos = dr["Apellidos"].ToString(),
                                    Correo = dr["Correo"].ToString(),
                                    Clave = dr["Clave"].ToString(),
                                    Restablecer = Convert.ToBoolean(dr["Restablecer"]),
                                    Activo = Convert.ToBoolean(dr["Activo"]),
                                }
                                );
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                lista = new List<Usuario>();
            }
            return lista;
        }
    }
}
