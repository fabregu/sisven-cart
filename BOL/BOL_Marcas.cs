using DAL;
using Entity;
using System;
using System.Collections.Generic;

namespace BOL
{
    public class BOL_Marcas
    {
        private DAL_Marcas objDatos = new DAL_Marcas();
        public List<Marca> Listar()
        {
            return objDatos.Listar();
        }

        public int RegistrarMarca(Marca obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "la descripciòn de la marca no puede ser vacio";
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

        public bool EditarMarca(Marca obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "la descripciòn de la marca no puede ser vacio";
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
