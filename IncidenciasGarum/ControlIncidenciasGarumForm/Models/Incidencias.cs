﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlIncidenciasGarumForm.Models
{
    public class Incidencias
    {

        public int IDFichero { get; set; }
        public DateTime? Fecha_Fichero { get; set; }
        public DateTime? Fecha_Estudio { get; set; }
        public String Nombre_Fichero { get; set; }
        public String Nombre_Estacion { get; set; }
        public String TPV { get; set; }

    }
}
