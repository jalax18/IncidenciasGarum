using Newtonsoft.Json;
using ServiciosWeb.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlIncidenciasGarumForm.Models;
using Newtonsoft.Json;

namespace ControlIncidenciasGarumForm
{
    
    public partial class Form1 : Form
    {
        public Incidencias incidencias= new Incidencias();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string paramurl = ConfigurationManager.AppSettings["urlws"];
            textBox3.Text = paramurl;
            if (string.IsNullOrEmpty(textBox3.Text.Trim().Trim()))
            {
                textBox3.Text = "http://2.139.147.209:1602/";

            }
            if (string.IsNullOrEmpty(textBox1.Text.Trim().Trim()))
            {
              
                textBox1.Text = DateTime.Today.AddMinutes(-60 * 24).ToString();


            }
            if (string.IsNullOrEmpty(textBox2.Text.Trim().Trim()))
            {

                textBox2.Text = DateTime.Today.ToString();


            }
            if (string.IsNullOrEmpty(comboBox1.Text.Trim().Trim()))
            {

                comboBox1.Text = "Todas";


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            try
            {
                config.AppSettings.Settings.Remove("urlws");
                config.AppSettings.Settings.Add("urlws", textBox3.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch
            {
                config.AppSettings.Settings.Add("urlws", textBox3.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }

        }

        
        
        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient clientehttp = new HttpClient();
            clientehttp.BaseAddress=new Uri(textBox3.Text);
            var request = clientehttp.GetAsync("api/ficherosgarum").Result;
            if (request.IsSuccessStatusCode)

            {
                var Resultstring = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<ficherosgarum>>(Resultstring);

                dataGridView1.DataSource = listado;
                //dataGridView1.ColumnCount =6;
                //dataGridView1.columns(0).Width = 100;
                //dataGridView1.columns(1).Width = 150;
                foreach (var item in listado)
                {
                 //   Console.WriteLine(item.Nombre_Fichero);
                }


            }


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogo = MessageBox.Show("¿ Desea Salir de la Aplicacion ?",
                       "Salir de Aplicacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogo == DialogResult.Yes) { }
            else { e.Cancel = true; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
