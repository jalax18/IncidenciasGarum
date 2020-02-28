using ServicioWeb.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiciosWeb.WebAPI.Controllers
{
    public class EstudioAjustesController : ApiController
    {

        // conectamos a la base de datos y la referenciamos en un elemento llamado BD


        IncidenciasGarumConnectionEntities BD = new IncidenciasGarumConnectionEntities();
        
        // este ficherosgarum lo coge del proyecto serviciosweb.Datos la tabla ficherosgarum
        [HttpGet]
        public IEnumerable<EstudioAjustes> Get()
        {
            // creamo un objeto listado  que va a ser la directamente la tabla ficherosgarum transformada en una lista
            var listado = BD.EstudioAjustes.ToList();
            return listado;
        }

        [HttpGet]

        // en este metodo ya no nos devuelve un listado de ficheros si no un unico fichero
        public EstudioAjustes Get(int id)
        {
            // creamo un objeto listado  que va a devolver el resultado de la consulta por linqqiu
            var estudioajustes = BD.EstudioAjustes.FirstOrDefault(x => x.id_ajuste == id);
            return estudioajustes;
        }

        [HttpPost]

        // en el caso de un alta lo que queremos en la respuesta es un booleano para saber si se ha grabado o no y en los parametros
        // vamos a mandar un objeto ficherosgarum
        public bool Post(EstudioAjustes estudioajustes)
        {
            // lo que hacemos es en la tabla ficherosgarum añadir un registro del objeto ficheroalta que es del tipo ficherosgarum
            BD.EstudioAjustes.Add(estudioajustes);
            // BD.SaveChanges(); con esto ya se graba en base de datos pero vamos a modificar la linea para qeu retorne el valor que da y si es mas de cero es qeu se produjo y nos
            // nos vale como real
            return BD.SaveChanges() > 0;
        }

        [HttpPut]
        // en el caso del put y estando trabajando con emptyty debemos primero buscar el registro para luego grabarlo
        public bool Put(EstudioAjustes estudioAjustes)
        {
            // creamos un objeto fichero ficherogarumactualizar que va a tener la informacion del registro que vams a buscar en base de datos y que vamos a actualizar

            var estudioajustesactualizar = BD.EstudioAjustes.FirstOrDefault(x => x.id_ajuste == estudioAjustes.id_ajuste);

            // vamos modificando el registro con los datos que nos vienen para actualizar y grabamos los cambios en base de datos

            estudioajustesactualizar.surtidor = estudioAjustes.surtidor;
            estudioajustesactualizar.Manguera = estudioAjustes.Manguera;
            estudioajustesactualizar.LitrosLec = estudioAjustes.LitrosLec;
            estudioajustesactualizar.Litrosvta = estudioAjustes.Litrosvta;
            estudioajustesactualizar.Fecha_estudio = estudioAjustes.Fecha_estudio;
            estudioajustesactualizar.Fecha_Ajustes = estudioAjustes.Fecha_Ajustes;
            estudioajustesactualizar.Nombre_Estacion = estudioAjustes.Nombre_Estacion;
            estudioajustesactualizar.Diferencia = estudioAjustes.Diferencia;
            estudioajustesactualizar.Contador_inicial = estudioAjustes.Contador_inicial;
            estudioajustesactualizar.Contador_Final = estudioAjustes.Contador_Final;
            estudioajustesactualizar.Tipo_contador_inicial = estudioAjustes.Tipo_contador_inicial;
            estudioajustesactualizar.Tipo_contador_Final = estudioAjustes.Tipo_contador_Final;

            return BD.SaveChanges() > 0;

        }

        [HttpDelete] //borrar un registro que le llamemos,pero para nosotros necesitamos que se borren todos por lo qeu lo modificamos
        public bool Delete()

        {

            // buscamos el registro y lo guardamos en ficherogarumparaborrar y lo marcamos para borrar
            //var ficherogarumparaborrar = BD.ficherosgarum.FirstOrDefault(x => x.IDFichero == id);
            IEnumerable<EstudioAjustes> estudioajustesparaborrar = BD.EstudioAjustes.Where(x => x.id_ajuste > 1);
            // vamos a decirle que borre el registro del ficherogarumparaborrar
            BD.EstudioAjustes.RemoveRange(estudioajustesparaborrar);
            //BD.ficherosgarum.Remove(ficherogarumparaborrar);
            return BD.SaveChanges() > 0;
        }

       

    


    }
}
