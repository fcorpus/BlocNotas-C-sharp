using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography;

namespace BlocDeNotasCastilloCorpusYCastilloPardo
{

    public partial class Form1 : Form
    {
        FormaCerrar nueva_form;
        string NameFile;
        bool isColosing = false;

        public string search;

        public int bandera = 0;
        public String PalBuscar;

        public int cont = 0;

        //List<int> Palabras;
        public Form1()
        {
            InitializeComponent();

            nueva_form = new FormaCerrar(this);

        }    

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void abrir()
        {
            toolStripStatusLabel2.Text = "Abriendo";
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Archivos de texto|*.txt";



            if (ofd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(ofd.FileName);
                NameFile = ofd.FileName;
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrir();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuardarComo();
        }

        private void BotonGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void GuardarComo()
        {
            SaveFileDialog safeFileDailog = new SaveFileDialog();

            safeFileDailog.Filter = "Archivos de texto |*.txt";
            safeFileDailog.AddExtension = true;

            if (safeFileDailog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(safeFileDailog.FileName, richTextBox1.Text);
                NameFile = safeFileDailog.FileName;
            }
        }

        private void Guardar()
        {
            if (NameFile == null)
            {
                /*NameFile = richTextBox1.Lines.FirstOrDefault();
                string ArchNom = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + NameFile + ".txt";
                File.WriteAllText(ArchNom, richTextBox1.Text);*/
                GuardarComo();
            }
            else
            {
                File.WriteAllText(NameFile, richTextBox1.Text);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            GuardarComo();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!isColosing)
                Cerrar();
        }

        private void Cerrar ()
        {
            toolStripStatusLabel2.Text = "Cerrando";
            if (string.IsNullOrEmpty(NameFile))
            {
                if (richTextBox1.Text != "")
                {
                    nueva_form.ShowDialog();

                    if (bandera > 0)
                        GuardarComo();
                    else
                        if(bandera != 0)
                    {
                        isColosing = true;
                        this.Close();
                    }
                    
                }
            }
            else
            {
                if(richTextBox1.Text != File.ReadAllText(NameFile))
                {
                    nueva_form.ShowDialog();
                    nueva_form.Close();

                    if (bandera > 0)
                        Guardar();
                    else
                        if (bandera != 0)
                    {
                        isColosing = true;
                        this.Close();
                    }
                }
            }
            


        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Cerrar();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void bucarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            buscar();
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            nuevo();
        }
        private void buscar()
        {
            Form2 form2 = new Form2(this);
            form2.Show();


            /*if(PalBuscar != null)
                richTextBox1.Find(PalBuscar, 0, 0);*/

        }
        public int AAA(string palabra, int length)
        {
            int index;
            toolStripStatusLabel2.Text = "Buscando";

            //richTextBox1.Find(palabra);

            if (cont < richTextBox1.TextLength)
            {
                index = richTextBox1.Text.IndexOf(palabra, cont);
            }
            else
            {
                cont = 0;
                index = richTextBox1.Text.IndexOf(palabra, cont);
            }
                
            
            //Palabras.Add(index);

            richTextBox1.Select(index, length);

            return index;
            
        }
        private void nuevo()
        {
            toolStripStatusLabel2.Text = "Abriendo Nuevo Archivo";
            if (string.IsNullOrEmpty(NameFile))
            {
                if (richTextBox1.Text != "")
                {
                    nueva_form.ShowDialog();

                    if (bandera > 0)
                        GuardarComo();
                    else
                        if (bandera != 0)
                    {
                        richTextBox1.Clear();
                        NameFile = "";
                    }

                }
            }
            else
            {
                if (richTextBox1.Text != File.ReadAllText(NameFile))
                {
                    nueva_form.ShowDialog();
                    nueva_form.Close();

                    if (bandera > 0)
                        Guardar();
                    else
                        if (bandera != 0)
                    {
                        richTextBox1.Clear();
                        NameFile = "";
                    }
                }
            }
            richTextBox1.Clear();
            NameFile = "";

        }

        private void nuevoButon_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void AbrirButon_Click(object sender, EventArgs e)
        {
            abrir();
        }

        private void BotonBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = " Numero de Caracteres: "+richTextBox1.TextLength.ToString();
            //statusStrip1.Text = "Hola";

            //statusStrip1.Text = richTextBox1.TextLength.ToString();
        }
    }
}
