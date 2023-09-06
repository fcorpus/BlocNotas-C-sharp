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

        public int bandera = 0;
        public Form1()
        {
            InitializeComponent();

            nueva_form = new FormaCerrar(this);

        }    

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Archivos de texto|*.txt";



            if (ofd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(ofd.FileName);
                NameFile = ofd.FileName;
            }
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

            safeFileDailog.Filter = "Archivos de texto|*.txt";
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
                NameFile = richTextBox1.Lines.FirstOrDefault();
                string ArchNom = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + NameFile + ".txt";
                File.WriteAllText(ArchNom, richTextBox1.Text);
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
            if(string.IsNullOrEmpty(NameFile))
            {
                if (richTextBox1.Text != "")
                {
                    nueva_form.ShowDialog();

                    if (bandera > 0)
                        GuardarComo();
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
                    
                }
            }
            isColosing = true;
            this.Close();


        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Cerrar();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show( richTextBox1.Text.s);
        }
    }
}
