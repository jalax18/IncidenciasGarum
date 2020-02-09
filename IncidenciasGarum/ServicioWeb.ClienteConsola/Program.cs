using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiciosWeb.Datos;

namespace ServicioWeb.ClienteConsola
{
    class Program
    {
        static void Main(string[] args)
        {

            // invocar servicio wcf
            ServiceFicherosGarumWCF.ServicioFicherosGarumClient clienteWCF = new ServiceFicherosGarumWCF.ServicioFicherosGarumClient();
            var listadoficherosgarum = clienteWCF.ObtenerFicheros();

            // invocar api rest.

            HttpClient clientehttp = new HttpClient();
            clientehttp.BaseAddress = new Uri("http://localhost:35973/");
            var request = clientehttp.GetAsync("api/ficherosgarum").Result;

            if (request.IsSuccessStatusCode)

            {
                var Resultstring = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<ficherosgarum>>(Resultstring);

                foreach (var item in listado)
                {
                    Console.WriteLine(item.Nombre_Fichero);
                }
            }
            Console.ReadLine(); // para que se quede la pantalla visible


        }
    }
}
