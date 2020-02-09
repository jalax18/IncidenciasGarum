using Newtonsoft.Json;
using ServicioWeb.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ServicioWeb.ClienteWeb.Controllers
{
    public class FicherosGarumController : Controller
    {
        // GET: FicherosGarum
        public ActionResult Index()
        {
            // invocar api rest.

            HttpClient clientehttp = new HttpClient();
            clientehttp.BaseAddress = new Uri("http://localhost:35973/");
            var request = clientehttp.GetAsync("api/ficherosgarum").Result;

            if (request.IsSuccessStatusCode)

            {
                var Resultstring = request.Content.ReadAsStringAsync().Result;

                var listado = JsonConvert.DeserializeObject<List<ficherosgarum>>(Resultstring);

                return View(listado);
            }

            return View(new List<ficherosgarum>());
        }
    }
}