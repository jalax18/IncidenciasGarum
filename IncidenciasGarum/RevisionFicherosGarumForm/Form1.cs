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
        public static void ProcessDirectory(string targetDirectory,string fecha_comparativa)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName,fecha_comparativa);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory,fecha_comparativa);
        }

        // Insert logic for processing found files here.
        public static void ProcessFile(string path,string fecha_comparativa)
        {
            //    if (File.GetCreationTime(path) < Convert.ToDateTime("2019-10-01 00:00:00"))

            if (File.GetCreationTime(path) < Convert.ToDateTime(fecha_comparativa))
                {
                    MessageBox.Show(path+" "+ File.GetCreationTime(path).ToString());
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
                MessageBox.Show("Voy a revisar los ficheros Pendientes", "Aviso");
            }
        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            try
            {
                config.AppSettings.Settings["xadinput"].Value = textBox1.Text;
                config.AppSettings.Settings["4glexport"].Value = textBox2.Text;
                config.AppSettings.Settings["horaestudio"].Value = textBox4.Text;
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch
            {

                config.AppSettings.Settings.Add("xadinput",textBox1.Text);
                config.AppSettings.Settings.Add("4glexport",textBox2.Text);
                config.AppSettings.Settings.Add("horaestudio",textBox4.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
          

            if (Directory.Exists(textBox1.Text))
            {
                label5.Text = "OK";
                label5.BackColor = Color.Green;
                label5.Visible = true;
            }
            else
            {
                label5.Text = "KO";
                label5.BackColor = Color.Red;
                label5.Visible = true;
            }
            if (Directory.Exists(textBox2.Text))
            {
                label6.Text = "OK";
                label6.BackColor = Color.Green;
                label6.Visible = true;
            }
            else
            {
                label6.Text = "KO";
                label6.BackColor = Color.Red;
                label6.Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox3.Text = DateTime.Now.ToString("hh:mm:ss");
            string paramxadinput = ConfigurationManager.AppSettings["xadinput"];
            string param4glexport = ConfigurationManager.AppSettings["4glexport"];
            string paramhoraestudio = ConfigurationManager.AppSettings["horaestudio"];
            //string miValor = ConfigurationManager.AppSettings["xadinput"];
            textBox1.Text = paramxadinput;
            textBox2.Text = param4glexport;
            textBox4.Text = paramhoraestudio;
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                textBox1.Text = "\\\\127.0.0.1\\c\\integracion\\xadinput\\";
               

            }
            if (string.IsNullOrEmpty(textBox2.Text.Trim().Trim()))
            {
                textBox2.Text = "\\\\127.0.0.1\\c\\integracion\\4glexport\\";

            }
            if (string.IsNullOrEmpty(textBox3.Text.Trim().Trim()))
            {
                textBox4.Text = "06:30:00";

            }
            if (Directory.Exists(textBox1.Text))
            {
                label5.Text = "OK";
                label5.BackColor = Color.Green;
                label5.Visible = true;
            }
            else
            {
                label5.Text = "KO";
                label5.BackColor = Color.Red;
                label5.Visible = true;
            }
            if (Directory.Exists(textBox2.Text))
            {
                label6.Text = "OK";
                label6.BackColor = Color.Green;
                label6.Visible = true;
            }
            else
            {
                label6.Text = "KO";
                label6.BackColor = Color.Red;
                label6.Visible = true;
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcessDirectory(textBox1.Text, textBox5.Text);
            ProcessDirectory(textBox2.Text, textBox5.Text);
        }

       
    }
}
