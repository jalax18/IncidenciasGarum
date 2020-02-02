using IncidenciasGarum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IncidenciasGarum.Controllers
{
    public class ficherosgarumController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Add(Models.Request.FicherosGarumclass ficherosgarumclass )
        {
            using (Models.IncidenciasGarumEntities db = new Models.IncidenciasGarumEntities())

            {
                var Oincidencia = new Models.ficherosgarum();
                Oincidencia.Fecha_Estudio = ficherosgarumclass.Fecha_Estudio;
                Oincidencia.Fecha_Fichero = ficherosgarumclass.Fecha_Fichero;
                Oincidencia.Nombre_Estacion = ficherosgarumclass.Nombre_Fichero;
                Oincidencia.Nombre_Fichero = ficherosgarumclass.Nombre_Fichero;
                db.ficherosgarums.Add(Oincidencia);
                db.SaveChanges();


            }
            return Ok(ficherosgarumclass.Nombre_Fichero);
            
        }
        
    }
        

}
