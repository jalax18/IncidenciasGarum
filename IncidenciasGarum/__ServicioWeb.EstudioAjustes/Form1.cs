using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace ServicioWeb.EstudioAjustes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public NpgsqlConnection conexionabbdd(string ip, string usuario, string password, string puerto, string database)
        {
            NpgsqlConnection conexion = new NpgsqlConnection();
            var cadena_conexion = "Server=" + ip + ";port=" + puerto + ";user Id=" + usuario + ";password=" + password + ";Database=" + database;

            if (!string.IsNullOrEmpty(cadena_conexion))
            {
                try
                {
                    conexion = new NpgsqlConnection(cadena_conexion);
                    conexion.Open();
                }
                catch
                {
                    conexion.Close();
                }

            }
            return conexion;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string parames = ConfigurationManager.AppSettings["es"];
            string paramurl = ConfigurationManager.AppSettings["urlws"];
            string paramhoraestudio1 = ConfigurationManager.AppSettings["horaestudio1"];
            string paramhoraestudio2 = ConfigurationManager.AppSettings["horaestudio2"];
            string paramhoraestudio3 = ConfigurationManager.AppSettings["horaestudio3"];
            
            string paramipbbdd = ConfigurationManager.AppSettings["ipbbdd"];
            string paramusuario = ConfigurationManager.AppSettings["usuario"];
            string parampassword = ConfigurationManager.AppSettings["password"];

            string parampuerto = ConfigurationManager.AppSettings["puerto"];
            string parambasededatos = ConfigurationManager.AppSettings["basededatos"];
            
            //string miValor = ConfigurationManager.AppSettings["xadinput"];
            textBox3.Text = DateTime.Now.ToString("hh:mm:ss");
            textBox4.Text = paramhoraestudio1;
            textBox10.Text = paramhoraestudio2;
            textBox12.Text = paramhoraestudio3;
            textBox6.Text = paramurl;
            textBox14.Text = parames;
            textBox1.Text = paramipbbdd;
            textBox2.Text = paramusuario;
            textBox6.Text = paramurl;
            textBox8.Text = parampassword;
            textBox9.Text = parampuerto;
            textBox5.Text = parambasededatos;


            
            // rellenamos por defecto los textos de input y export si estan vacios
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                textBox1.Text = "10.0.0.101";
            }
            if (string.IsNullOrEmpty(textBox2.Text.Trim().Trim()))
            {
                textBox2.Text = "postgres";
            }
            if (string.IsNullOrEmpty(textBox8.Text.Trim()))
            {
                textBox8.Text = "postgres";
            }
            if (string.IsNullOrEmpty(textBox5.Text.Trim().Trim()))
            {
                textBox5.Text = "tpv";
            }
            if (string.IsNullOrEmpty(textBox6.Text.Trim().Trim()))
            {
                textBox6.Text = "http://2.139.147.209:1602/";
            }
            if (string.IsNullOrEmpty(textBox14.Text.Trim().Trim()))
            {
                textBox14.Text = "Estacion de servicio PRUEBAS";
            }
            if (string.IsNullOrEmpty(textBox9.Text.Trim().Trim()))
            {
                textBox9.Text = "5432";
            }

            if (string.IsNullOrEmpty(textBox4.Text.Trim().Trim()))
            {
                textBox4.Text = "07:30:00";
            }
            if (string.IsNullOrEmpty(textBox10.Text.Trim().Trim()))
            {
                textBox10.Text = "15:30:00";
            }
            if (string.IsNullOrEmpty(textBox12.Text.Trim().Trim()))
            {
                textBox12.Text = "23:30:00";
            }
        }
        
     //   NpgsqlConnection conn = new NpgsqlConnection("Server=192.168.1.77;");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var conexionbbdd = conexionabbdd(textBox1.Text, textBox2.Text, textBox8.Text, textBox9.Text, textBox5.Text);
                var estadoconexionbbdd = conexionbbdd.State.ToString();
                //MessageBox.Show(estadoconexion);
                if (estadoconexionbbdd == "Open")
                {
                    textBox7.Text = "OK";
                    textBox7.BackColor = Color.Green;
                    conexionbbdd.Close();
                    
                }
                else
                {
                    textBox7.Text = "kO";
                    textBox7.BackColor = Color.Red;
                }
            }
            catch {
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        
            
            try
            {
                config.AppSettings.Settings.Remove("es");
                config.AppSettings.Settings.Add("es", textBox14.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch
            {
                config.AppSettings.Settings.Add("es", textBox14.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }

            try
            {
                config.AppSettings.Settings.Remove("urlws");
                config.AppSettings.Settings.Add("urlws", textBox6.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch
            {
                config.AppSettings.Settings.Add("urlws", textBox6.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            try
            {
                config.AppSettings.Settings.Remove("horaestudio1");
                config.AppSettings.Settings.Add("horaestudio1", textBox4.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch
            {
                config.AppSettings.Settings.Add("horaestudio1", textBox4.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            try
            {
                config.AppSettings.Settings.Remove("horaestudio2");
                config.AppSettings.Settings.Add("horaestudio2", textBox10.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch
            {
                config.AppSettings.Settings.Add("horaestudio2", textBox10.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            try
            {
                config.AppSettings.Settings.Remove("horaestudio3");
                config.AppSettings.Settings.Add("horaestudio3", textBox12.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch
            {
                config.AppSettings.Settings.Add("horaestudio3", textBox12.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }

            
            try
            {
                config.AppSettings.Settings.Remove("ipbbdd");
                config.AppSettings.Settings.Add("ipbbdd", textBox1.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch
            {
                config.AppSettings.Settings.Add("ipbbdd", textBox1.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }

            try
            {
                config.AppSettings.Settings.Remove("usuario");
                config.AppSettings.Settings.Add("usuario", textBox2.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch
            {
                config.AppSettings.Settings.Add("usuario", textBox2.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }

            try
            {
                config.AppSettings.Settings.Remove("password");
                config.AppSettings.Settings.Add("password", textBox8.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch
            {
                config.AppSettings.Settings.Add("password", textBox8.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            try
            {
                config.AppSettings.Settings.Remove("puerto");
                config.AppSettings.Settings.Add("puerto", textBox9.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch
            {
                config.AppSettings.Settings.Add("puerto", textBox9.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            try
            {
                config.AppSettings.Settings.Remove("basededatos");
                config.AppSettings.Settings.Add("basededatos", textBox5.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch
            {
                config.AppSettings.Settings.Add("basededatos", textBox5.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
          //  dataGridView1.DataSource = consultarinforme();
            textBox12.Text = consultarinforme();

        }
        public int consultarinforme()
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=" + textBox1.Text + ";port=" + textBox9.Text + ";user Id=" + textBox2.Text + ";password=" + textBox8.Text + ";Database=" + textBox5.Text);
            string consulta = "select max(id_informe) as id_informe from \"informe\" order by id_informe asc";
            NpgsqlCommand conector = new NpgsqlCommand(consulta, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable informes = new DataTable();
            datos.Fill(informes);
            return informes.id_informe;
        }
       
    }
}
