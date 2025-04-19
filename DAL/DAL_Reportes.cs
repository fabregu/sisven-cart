using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Reportes
    {
        public Dashboard VerDashboard() 
        { 
            Dashboard dashboard = new Dashboard();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cnn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ReporteDashboard", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            dashboard = new Dashboard()
                            {
                                TotalVentas = Convert.ToInt32(dr["TotalVentas"]),
                                TotalClientes = Convert.ToInt32(dr["TotalClientes"]),
                                TotalProductos = Convert.ToInt32(dr["TotalProductos"]),
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dashboard = new Dashboard();
            }
            return dashboard;
        }
    }
}
