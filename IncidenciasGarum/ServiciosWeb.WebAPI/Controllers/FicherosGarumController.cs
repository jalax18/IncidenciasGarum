using ServiciosWeb.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiciosWeb.WebAPI.Controllers
{
    public class FicherosGarumController : ApiController
    {
        // conectamos a la base de datos y la referenciamos en un elemento llamado BD

        LibreriaConnection BD = new LibreriaConnection();

        // este ficherosgarum lo coge del proyecto serviciosweb.Datos la tabla ficherosgarum
        [HttpGet]
        public IEnumerable<ficherosgarum> Get()
        {
            // creamo un objeto listado  que va a ser la directamente la tabla ficherosgarum transformada en una lista
            var listado = BD.ficherosgarum.ToList();
            return listado;
        }

        [HttpGet]

        // en este metodo ya no nos devuelve un listado de ficheros si no un unico fichero
        public ficherosgarum Get(int id)
        {
            // creamo un objeto listado  que va a devolver el resultado de la consulta por linqqiu
            var ficherogarum = BD.ficherosgarum.FirstOrDefault(x =>x.IDFichero == id);
            return ficherogarum;
        }

        [HttpPost]

        // en el caso de un alta lo que queremos en la respuesta es un booleano para saber si se ha grabado o no y en los parametros
        // vamos a mandar un objeto ficherosgarum
        public bool Post(ficherosgarum Ficherogarum)
        {
            // lo que hacemos es en la tabla ficherosgarum añadir un registro del objeto ficheroalta que es del tipo ficherosgarum
            BD.ficherosgarum.Add(Ficherogarum);
            // BD.SaveChanges(); con esto ya se graba en base de datos pero vamos a modificar la linea para qeu retorne el valor que da y si es mas de cero es qeu se produjo y nos
            // nos vale como real
            return BD.SaveChanges() >0 ;
        }

        [HttpPut]
        // en el caso del put y estando trabajando con emptyty debemos primero buscar el registro para luego grabarlo
        public bool Put(ficherosgarum Ficherogarum)
        {
            // creamos un objeto fichero ficherogarumactualizar que va a tener la informacion del registro que vams a buscar en base de datos y que vamos a actualizar

            var ficherogarumactualizar = BD.ficherosgarum.FirstOrDefault(x => x.IDFichero == Ficherogarum.IDFichero);

            // vamos modificando el registro con los datos que nos vienen para actualizar y grabamos los cambios en base de datos

            ficherogarumactualizar.Fecha_Estudio = Ficherogarum.Fecha_Estudio;
            ficherogarumactualizar.Fecha_Fichero = Ficherogarum.Fecha_Fichero;
            ficherogarumactualizar.Nombre_Estacion = Ficherogarum.Nombre_Estacion;
            ficherogarumactualizar.Nombre_Fichero = Ficherogarum.Nombre_Fichero;
            ficherogarumactualizar.TPV = Ficherogarum.TPV;
            return BD.SaveChanges()>0;
            
        }

        [HttpDelete]
        public bool Delete(ficherosgarum Ficherogarum)
            
        {

            // buscamos el registro y lo guardamos en ficherogarumparaborrar y lo marcamos para borrar
            var ficherogarumparaborrar = BD.ficherosgarum.FirstOrDefault(x => x.IDFichero == Ficherogarum.IDFichero);
            // vamos a decirle que borre el registro del ficherogarumparaborrar
            BD.ficherosgarum.Remove(ficherogarumparaborrar) ;
            return BD.SaveChanges()>0;
        }


    }
}
