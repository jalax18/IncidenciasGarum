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
        [HttpGet]
       public IHttpActionResult Get()
        {
            // creamos una lista del tipo Model.Request.Ficherosgarumclass que es la clase de nuestra estructura de base de datos
            List<Models.Request.FicherosGarumclass> lista = new List<Models.Request.FicherosGarumclass>();
            // hacemos la conexion a la base de datos
            using (Models.IncidenciasGarumEntities db = new Models.IncidenciasGarumEntities())
            {
                // vamos a rellenar nuestra lista con el formato que deseamos
                // d es el nombre con el que referencio la tabla de la base de datos ficherosgarums
                lista = (from d in db.ficherosgarums
                             // con esto relleno mi viewmodel qeu es la clase que ehms creado en Models.Request.FicherosGarumclass
                         select new Models.Request.FicherosGarumclass
                         {


                             Fecha_Estudio = d.Fecha_Estudio,
                             Fecha_Fichero = d.Fecha_Fichero,
                             Nombre_Estacion = d.Nombre_Estacion,
                             Nombre_Fichero = d.Nombre_Fichero,
                             TPV = d.TPV

                         }).ToList();

            }
            // devolvemos la lista
            return Ok(lista);

        }

        

        [HttpPost]
        public IHttpActionResult Add(Models.Request.FicherosGarumclass ficherosgarumclass )
        {
            using (Models.IncidenciasGarumEntities db = new Models.IncidenciasGarumEntities())

            {
                var Oincidencia = new Models.ficherosgarum();
                Oincidencia.Fecha_Estudio = ficherosgarumclass.Fecha_Estudio;
                Oincidencia.Fecha_Fichero = ficherosgarumclass.Fecha_Fichero;
                Oincidencia.Nombre_Estacion = ficherosgarumclass.Nombre_Estacion;
                Oincidencia.Nombre_Fichero = ficherosgarumclass.Nombre_Fichero;
                Oincidencia.TPV = ficherosgarumclass.TPV;
                db.ficherosgarums.Add(Oincidencia);
                db.SaveChanges();


            }
            return Ok(ficherosgarumclass);
            
        }
        
    }
        

}
