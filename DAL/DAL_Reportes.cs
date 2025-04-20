using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace DAL
{
    public class DAL_Reportes
    {
        public List<Reporte> Ventas(string fechaInicio, string fechaFin, string idTransaccion)
        {
            List<Reporte> lista = new List<Reporte>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cnn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ReporteVentas", oconexion);
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                    cmd.Parameters.AddWithValue("@IdTransaccion", idTransaccion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Reporte()
                                {
                                    FechaVenta = dr["IdUsuario"].ToString(),
                                    Cliente = dr["Cliente"].ToString(),
                                    Producto = dr["Producto"].ToString(),
                                    Precio = Convert.ToDecimal(dr["Precio"], new CultureInfo("es-PE")),
                                    Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                                    Total = Convert.ToDecimal(dr["Total"], new CultureInfo("es-PE")),
                                    IdTransaccion = dr["IdTransaccion"].ToString()
                                });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lista = new List<Reporte>();
            }
            return lista;
        }

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
