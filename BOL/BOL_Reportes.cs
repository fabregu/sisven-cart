using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class BOL_Reportes
    {
        private DAL.DAL_Reportes dal = new DAL.DAL_Reportes();
        public Dashboard VerDashboard()
        {
            return dal.VerDashboard();
        }
    }
}
