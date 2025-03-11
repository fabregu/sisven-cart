using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class BOL_Usuarios
    {
        private DAL_Usuarios objDatos = new DAL_Usuarios();
        public List<Usuario>Listar() 
        {
            return objDatos.Listar();
        }
    }
}
