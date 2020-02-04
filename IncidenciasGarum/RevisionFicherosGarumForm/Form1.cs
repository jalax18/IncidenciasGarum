using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
using System.Web.Script.Serialization;
using System.Net;
using RevisionFicherosGarumForm.Models.Request;

namespace RevisionFicherosGarumForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Process all files in the directory passed in, recurse on any directories 
        // that are found, and process the files they contain.
        public void ProcessDirectory(string targetDirectory,string fecha_comparativa,string TPV)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName,fecha_comparativa,TPV);

            // Recurse into subdirectories of this directory.
           // string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
           // foreach (string subdirectory in subdirectoryEntries)
             //   ProcessDirectory(subdirectory,fecha_comparativa,TPV);
        }

        // Insert logic for processing found files here.
        public void ProcessFile(string path,string fecha_comparativa,string TPV)
        {
            string resultado = "";
            //    if (File.GetCreationTime(path) < Convert.ToDateTime("2019-10-01 00:00:00"))

            if (File.GetCreationTime(path) < Convert.ToDateTime(fecha_comparativa))
                {
               // MessageBox.Show(path+" "+ File.GetCreationTime(path).ToString());
                FicherosGarumclass nuevaincidencia = new FicherosGarumclass();
                nuevaincidencia.Fecha_Estudio = DateTime.Now;
                nuevaincidencia.Fecha_Fichero = File.GetCreationTime(path);
                nuevaincidencia.Nombre_Estacion = textBox14.Text;
                nuevaincidencia.Nombre_Fichero = path;
                nuevaincidencia.TPV = TPV;
                string url = textBox6.Text.Trim()+"api/ficherosgarum";
                resultado = Send<FicherosGarumclass>(url, nuevaincidencia, "POST");
                textBox7.Text = textBox7.Text + resultado + "\r\n";
                // MessageBox.Show(resultado);


                // aqui grabamos el post en base de datos
            }
                //Convert.ToDateTime(Convert.ToString(DateTime.Now).Substring(0, 10).Trim() + " 00:00:00");
            //MessageBox.Show();

            //MessageBox.Show(File.GetCreationTime(path).ToString());

            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox5.Text = Convert.ToString(DateTime.Now).Substring(0, 10).Trim() + " 00:00:00";
            textBox3.Text = DateTime.Now.ToString("hh:mm:ss");
            if (textBox3.Text == textBox4.Text)
            {
                if (checkBox1.Checked)
                {
                    ProcessDirectory(textBox1.Text, textBox5.Text, "TPV1");
                    ProcessDirectory(textBox2.Text, textBox5.Text, "TPV1");
                }
                if (checkBox2.Checked)
                {
                    ProcessDirectory(textBox8.Text, textBox5.Text, "TPV2");
                    ProcessDirectory(textBox9.Text, textBox5.Text, "TPV2");
                }
                if (checkBox3.Checked)
                {
                    ProcessDirectory(textBox10.Text, textBox5.Text, "TPV3");
                    ProcessDirectory(textBox11.Text, textBox5.Text, "TPV3");
                }
                if (checkBox4.Checked)
                {
                    ProcessDirectory(textBox12.Text, textBox5.Text, "TPV4");
                    ProcessDirectory(textBox13.Text, textBox5.Text, "TPV4");
                }
            }
        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            try
            {
                config.AppSettings.Settings.Remove("xadinput1");
                config.AppSettings.Settings.Add("xadinput1", textBox1.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch {
                config.AppSettings.Settings.Add("xadinput1", textBox1.Text);
                config.Save(ConfigurationSaveMode.Modified);
                   }

            try
            {
                config.AppSettings.Settings.Remove("4glexport1");
                config.AppSettings.Settings.Add("4glexport1", textBox2.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch
            {
                config.AppSettings.Settings.Add("4glexport1", textBox2.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }

            //// tpv 2
            ///

            try
            {
                config.AppSettings.Settings.Remove("xadinput2");
                config.AppSettings.Settings.Add("xadinput2", textBox8.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch
            {
                config.AppSettings.Settings.Add("xadinput2", textBox8.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }

            try
            {
                config.AppSettings.Settings.Remove("4glexport2");
                config.AppSettings.Settings.Add("4glexport2", textBox9.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch
            {
                config.AppSettings.Settings.Add("4glexport2", textBox9.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }

            /// tpv3
            /// 
            try
            {
                config.AppSettings.Settings.Remove("xadinput3");
                config.AppSettings.Settings.Add("xadinput3", textBox10.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch
            {
                config.AppSettings.Settings.Add("xadinput3", textBox10.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }

            try
            {
                config.AppSettings.Settings.Remove("4glexport3");
                config.AppSettings.Settings.Add("4glexport3", textBox11.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch
            {
                config.AppSettings.Settings.Add("4glexport3", textBox11.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }

            /// tpv4
            /// 
            try
            {
                config.AppSettings.Settings.Remove("xadinput4");
                config.AppSettings.Settings.Add("xadinput4", textBox12.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch
            {
                config.AppSettings.Settings.Add("xadinput4", textBox12.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }

            try
            {
                config.AppSettings.Settings.Remove("4glexport4");
                config.AppSettings.Settings.Add("4glexport4", textBox13.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch
            {
                config.AppSettings.Settings.Add("4glexport4", textBox13.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            /// nombre de la estacion
            /// 
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
            /// hora estudio
            /// 
            try
            {
                config.AppSettings.Settings.Remove("horaestudio");
                config.AppSettings.Settings.Add("horaestudio", textBox4.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch
            {
                config.AppSettings.Settings.Add("horaestudio", textBox4.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }

            // urlws

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

            /// vamos ahora a los check de estudio 
            /// tpv1
            try
            {
                config.AppSettings.Settings.Remove("paramactivo1");
                if (checkBox1.Checked)
                {
                    config.AppSettings.Settings.Add("paramactivo1", "S");
                    config.Save(ConfigurationSaveMode.Modified);
                }
                else
                {
                    config.AppSettings.Settings.Add("paramactivo1", "N");
                    config.Save(ConfigurationSaveMode.Modified);
                }
            }
            catch
            {
                if (checkBox1.Checked)
                {
                    config.AppSettings.Settings.Add("paramactivo1", "S");
                    config.Save(ConfigurationSaveMode.Modified);
                }
                else
                {
                    config.AppSettings.Settings.Add("paramactivo1", "N");
                    config.Save(ConfigurationSaveMode.Modified);
                }
            }

            /// vamos ahora a los check de estudio 
            /// tpv2
            try
            {
                config.AppSettings.Settings.Remove("paramactivo2");
                if (checkBox2.Checked)
                {
                    config.AppSettings.Settings.Add("paramactivo2", "S");
                    config.Save(ConfigurationSaveMode.Modified);
                }
                else
                {
                    config.AppSettings.Settings.Add("paramactivo2", "N");
                    config.Save(ConfigurationSaveMode.Modified);
                }
            }
            catch
            {
                if (checkBox2.Checked)
                {
                    config.AppSettings.Settings.Add("paramactivo2", "S");
                    config.Save(ConfigurationSaveMode.Modified);
                }
                else
                {
                    config.AppSettings.Settings.Add("paramactivo2", "N");
                    config.Save(ConfigurationSaveMode.Modified);
                }
            }

            /// vamos ahora a los check de estudio 
            /// tpv3
            try
            {
                config.AppSettings.Settings.Remove("paramactivo3");
                if (checkBox3.Checked)
                {
                    config.AppSettings.Settings.Add("paramactivo3", "S");
                    config.Save(ConfigurationSaveMode.Modified);
                }
                else
                {
                    config.AppSettings.Settings.Add("paramactivo3", "N");
                    config.Save(ConfigurationSaveMode.Modified);
                }
            }
            catch
            {
                if (checkBox3.Checked)
                {
                    config.AppSettings.Settings.Add("paramactivo3", "S");
                    config.Save(ConfigurationSaveMode.Modified);
                }
                else
                {
                    config.AppSettings.Settings.Add("paramactivo3", "N");
                    config.Save(ConfigurationSaveMode.Modified);
                }
            }

            /// vamos ahora a los check de estudio 
            /// tpv4
            try
            {
                config.AppSettings.Settings.Remove("paramactivo4");
                if (checkBox4.Checked)
                {
                    config.AppSettings.Settings.Add("paramactivo4", "S");
                    config.Save(ConfigurationSaveMode.Modified);
                }
                else
                {
                    config.AppSettings.Settings.Add("paramactivo4", "N");
                    config.Save(ConfigurationSaveMode.Modified);
                }
            }
            catch
            {
                if (checkBox4.Checked)
                {
                    config.AppSettings.Settings.Add("paramactivo4", "S");
                    config.Save(ConfigurationSaveMode.Modified);
                }
                else
                {
                    config.AppSettings.Settings.Add("paramactivo1", "N");
                    config.Save(ConfigurationSaveMode.Modified);
                }
            }

            revisadirectorios();
            
            // comprobar directorios

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string parames = ConfigurationManager.AppSettings["es"];
            string paramurl = ConfigurationManager.AppSettings["urlws"];
            string paramhoraestudio = ConfigurationManager.AppSettings["horaestudio"];

            string paramxadinput1 = ConfigurationManager.AppSettings["xadinput1"];
            string param4glexport1 = ConfigurationManager.AppSettings["4glexport1"];
            string paramactivo1= ConfigurationManager.AppSettings["paramactivo1"];

            string paramxadinput2 = ConfigurationManager.AppSettings["xadinput2"];
            string param4glexport2 = ConfigurationManager.AppSettings["4glexport2"];
            string paramactivo2 = ConfigurationManager.AppSettings["paramactivo2"];

            string paramxadinput3 = ConfigurationManager.AppSettings["xadinput3"];
            string param4glexport3 = ConfigurationManager.AppSettings["4glexport3"];
            string paramactivo3 = ConfigurationManager.AppSettings["paramactivo3"];

            string paramxadinput4 = ConfigurationManager.AppSettings["xadinput4"];
            string param4glexport4 = ConfigurationManager.AppSettings["4glexport4"];
            string paramactivo4 = ConfigurationManager.AppSettings["paramactivo4"];

            //string miValor = ConfigurationManager.AppSettings["xadinput"];
            textBox3.Text = DateTime.Now.ToString("hh:mm:ss");
            textBox1.Text = paramxadinput1;
            textBox2.Text = param4glexport1;
            textBox8.Text = paramxadinput2;
            textBox9.Text = param4glexport2;
            textBox10.Text = paramxadinput3;
            textBox11.Text = param4glexport3;
            textBox12.Text = paramxadinput4;
            textBox13.Text = param4glexport4;
            textBox4.Text = paramhoraestudio;
            textBox6.Text = paramurl;
            textBox14.Text = parames;

            // rellenamos los check

            if (paramactivo1 == "S") { checkBox1.Checked = true;  } else { checkBox1.Checked = false;  }
            if (paramactivo2 == "S") { checkBox2.Checked = true;  } else { checkBox2.Checked = false;  }
            if (paramactivo3 == "S") { checkBox3.Checked = true;  } else { checkBox3.Checked = false;  }
            if (paramactivo4 == "S") { checkBox4.Checked = true;  } else { checkBox4.Checked = false;  }

            // rellenamos por defecto los textos de input y export si estan vacios
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                textBox1.Text = "\\\\10.0.0.101\\c\\integracion\\xadinput\\";
            }
            if (string.IsNullOrEmpty(textBox2.Text.Trim().Trim()))
            {
                textBox2.Text = "\\\\10.0.0.101\\c\\integracion\\4glexport\\";
            }
            if (string.IsNullOrEmpty(textBox8.Text.Trim()))
            {
                textBox8.Text = "\\\\10.0.0.102\\c\\integracion\\xadinput\\";
            }
            if (string.IsNullOrEmpty(textBox9.Text.Trim().Trim()))
            {
                textBox9.Text = "\\\\10.0.0.102\\c\\integracion\\4glexport\\";
            }
            if (string.IsNullOrEmpty(textBox10.Text.Trim()))
            {
                textBox10.Text = "\\\\10.0.0.103\\c\\integracion\\xadinput\\";
            }
            if (string.IsNullOrEmpty(textBox11.Text.Trim().Trim()))
            {
                textBox11.Text = "\\\\10.0.0.103\\c\\integracion\\4glexport\\";
            }
            if (string.IsNullOrEmpty(textBox12.Text.Trim()))
            {
                textBox12.Text = "\\\\10.0.0.104\\c\\integracion\\xadinput\\";
            }
            if (string.IsNullOrEmpty(textBox13.Text.Trim().Trim()))
            {
                textBox13.Text = "\\\\10.0.0.104\\c\\integracion\\4glexport\\";
            }

            if (string.IsNullOrEmpty(textBox4.Text.Trim().Trim()))
            {
                textBox4.Text = "06:30:00";

            }
            if (string.IsNullOrEmpty(textBox6.Text.Trim().Trim()))
            {
                textBox6.Text = "http://localhost:18804/";

            }
            if (string.IsNullOrEmpty(textBox14.Text.Trim().Trim()))
            {
                textBox14.Text = "Estacion sin configurar";

            }
            revisadirectorios();

            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                ProcessDirectory(textBox1.Text, textBox5.Text, "TPV1");
                ProcessDirectory(textBox2.Text, textBox5.Text, "TPV1");
            }
            if (checkBox2.Checked)
            {
                ProcessDirectory(textBox8.Text, textBox5.Text, "TPV2");
                ProcessDirectory(textBox9.Text, textBox5.Text, "TPV2");
            }
            if (checkBox3.Checked)
            {
                ProcessDirectory(textBox10.Text, textBox5.Text, "TPV3");
                ProcessDirectory(textBox11.Text, textBox5.Text, "TPV3");
            }
            if (checkBox4.Checked)
            {
                ProcessDirectory(textBox12.Text, textBox5.Text, "TPV4");
                ProcessDirectory(textBox13.Text, textBox5.Text, "TPV4");
            }
        }

        public string Send<T>(string url, T objectRequest, string method = "POST")
        {
            string result = "";
            try
            {
                 

                JavaScriptSerializer js = new JavaScriptSerializer();

                //serializamos el objeto
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(objectRequest);

                //peticion
                WebRequest request = WebRequest.Create(url);
                //headers
                request.Method = method;
                request.PreAuthenticate = true;
                request.ContentType = "application/json;charset=utf-8'";
                request.Timeout = 10000; //esto es opcional

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                
            }
            catch (Exception e)
            {

               
                //en caso de error lo manejamos en el mensaje
                result = e.Message;

            }

            return result;
        }

        public void revisadirectorios()
        {
            if (checkBox1.Checked)
            {
                if (Directory.Exists(textBox1.Text)) { label5.Text = "OK"; label5.BackColor = Color.Green; label5.Visible = true; }
                else { label5.Text = "KO"; label5.BackColor = Color.Red; label5.Visible = true; }

                if (Directory.Exists(textBox2.Text)) { label6.Text = "OK"; label6.BackColor = Color.Green; label6.Visible = true; }
                else { label6.Text = "KO"; label6.BackColor = Color.Red; label6.Visible = true; }
            }
            else { label5.Visible = false; label6.Visible = false; }

            if (checkBox2.Checked)
            {
                if (Directory.Exists(textBox8.Text)) { label10.Text = "OK"; label10.BackColor = Color.Green; label10.Visible = true; }
                else { label10.Text = "KO"; label10.BackColor = Color.Red; label10.Visible = true; }

                if (Directory.Exists(textBox9.Text)) { label11.Text = "OK"; label11.BackColor = Color.Green; label11.Visible = true; }
                else { label11.Text = "KO"; label11.BackColor = Color.Red; label11.Visible = true; }
            }
            else { label10.Visible = false; label11.Visible = false; }

            if (checkBox3.Checked)
            {
                if (Directory.Exists(textBox10.Text)) { label14.Text = "OK"; label14.BackColor = Color.Green; label14.Visible = true; }
                else { label14.Text = "KO"; label14.BackColor = Color.Red; label14.Visible = true; }

                if (Directory.Exists(textBox11.Text)) { label15.Text = "OK"; label15.BackColor = Color.Green; label15.Visible = true; }
                else { label15.Text = "KO"; label15.BackColor = Color.Red; label15.Visible = true; }
            }
            else { label14.Visible = false; label15.Visible = false; }

            if (checkBox4.Checked)
            {
                if (Directory.Exists(textBox12.Text)) { label18.Text = "OK"; label18.BackColor = Color.Green; label18.Visible = true; }
                else { label18.Text = "KO"; label18.BackColor = Color.Red; label18.Visible = true; }

                if (Directory.Exists(textBox13.Text)) { label19.Text = "OK"; label19.BackColor = Color.Green; label19.Visible = true; }
                else { label19.Text = "KO"; label19.BackColor = Color.Red; label19.Visible = true; }
            }
            else { label18.Visible = false; label19.Visible = false; }
            try
            {
                var myRequest = (HttpWebRequest)WebRequest.Create(textBox6.Text);

                var response = (HttpWebResponse)myRequest.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    label9.Text = "OK";
                    label9.BackColor = Color.Green;
                    label9.Visible = true;
                }
                else
                {
                    label9.Text = "KO";
                    label9.BackColor = Color.Red;
                    label9.Visible = true;
                }
            }
            catch (Exception ex)
            {
                label9.Text = "KO";
                label9.BackColor = Color.Red;
                label9.Visible = true;
            }


        }


    }

}

