using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;
using System.Windows.Forms;


namespace ExcelToTxt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


    
        }
        // inicio es el numero de la busqueda
        // numero bytes 405 
        private string LeerBytes(int inicio, int numeroBytes)
        {
            string filename = "C:\\Data.txt";
            byte[] ret = new byte[numeroBytes];
            using (BinaryReader reader = new BinaryReader(new FileStream(filename, FileMode.Open)))
            {
                reader.BaseStream.Seek(inicio, SeekOrigin.Begin);
                reader.Read(ret, 0, numeroBytes);
            }

            //return System.Text.Encoding.Default.GetString(ret);
            return System.Text.Encoding.UTF8.GetString(ret);
        }


        private void button1_Click(object sender, EventArgs e)
        {

            // configurar explorador de archivos
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.OpenFile();

            // leer la ruta del archivo y pasar a texto
            String rutaArchivo = openFileDialog1.FileName.ToString();

            // leer texto de csv
            string csvContentStr = File.ReadAllText(rutaArchivo);

           
            MessageBox.Show("Excel convertido a texto");
            

       
            string[] content;

   
            string con = "";

            if (rutaArchivo.Length != 0)
            {
                content = File.ReadAllLines(rutaArchivo);

                for (int i = 0; i < content.Length; i++) 
                {

                        string[] st = content[i].Split(";");

                        Persona p1 = new Persona();
                        p1.Id = i.ToString();
                        p1.Nombre = st[1];
                        p1.Nombre2 = st[2];
                        p1.Apellido = st[3];
                        p1.Email = st[4];
                        con += p1.DatosConFormato();

                }


               
                File.WriteAllText("C:\\Data.txt", con);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            int inicio = (id) * 405;
            int numBytes = 405;
            string readByte = LeerBytes(inicio, numBytes);
            Persona p1 = new Persona();
            p1 = Persona.StringFromFile(readByte);
    
            richTextBox1.AppendText(p1.FormatDatos());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.ResetText();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
