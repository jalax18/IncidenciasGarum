using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioWeb.Domain
{
    public class ficherosgarum
    {

        public int IDFichero { get; set; }

        public Nullable<System.DateTime> Fecha_Estudio { get; set; }

        public Nullable<System.DateTime> Fecha_Fichero { get; set; }

        public string Nombre_Estacion { get; set; }

        public string Nombre_Fichero { get; set; }

        public string TPV { get; set; }
    }
}
