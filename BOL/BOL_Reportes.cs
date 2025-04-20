using Entity;
using System.Collections.Generic;
using DAL;

namespace BOL
{
    public class BOL_Reportes
    {
        private DAL_Reportes dal = new DAL_Reportes();

        public List<Reporte> Ventas(string fechaInicio, string fechaFin, string idTransaccion)
        {
            return dal.Ventas(fechaInicio, fechaFin, idTransaccion);
        }
        public Dashboard VerDashboard()
        {
            return dal.VerDashboard();
        }
    }
}
