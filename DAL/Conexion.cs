﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL
{
    public class Conexion
    {
        public static string cnn = ConfigurationManager.ConnectionStrings["cnn"].ToString();
    }
}
