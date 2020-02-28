using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServicioWeb.Datos;
namespace WebApplication3.Controllers
{
    public class ficherosgarumController : ApiController
    {
        LibreriaConnection db = new LibreriaConnection();
        [HttpGet]
        public IEnumerable<ficherosgarum> get()
        {
            var lista = db.ficherosgarum.ToList();
            return lista;
        }
        
    }
}
