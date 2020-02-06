using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IncidenciasGarum.Models.Request
{
    public class FicherosGarumclass
    {
       public DateTime? Fecha_Fichero { get; set; }
       public DateTime? Fecha_Estudio { get; set; }
       public String Nombre_Fichero { get; set; }
       public String Nombre_Estacion { get; set; }
       public String TPV { get; set; }


    }
}