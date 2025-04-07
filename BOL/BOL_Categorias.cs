using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class BOL_Categorias
    {
        private DAL_Categorias objDatos = new DAL_Categorias();
        public List<Categoria> Listar()
        {
            return objDatos.Listar();
        }

        public int RegistrarCategoria(Categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "la descripciòn de la categoria no puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                    return objDatos.Registrar(obj, out Mensaje);                
            }
            else
            {
                return 0;
            }
        }

        public bool EditarCategoria(Categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "la descripciòn de la categoria no puede ser vacio";
            }
            if (string.IsNullOrEmpty(Mensaje))
            {
                return objDatos.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }
        public bool Eliminar(int id, out string Mensaje)
        {
            return objDatos.Eliminar(id, out Mensaje);
        }
    }
}
