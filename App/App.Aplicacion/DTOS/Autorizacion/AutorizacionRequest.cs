﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Aplicacion.DTOS.Autorizacion
{
    public class AutorizacionRequest
    {
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
    }
}
