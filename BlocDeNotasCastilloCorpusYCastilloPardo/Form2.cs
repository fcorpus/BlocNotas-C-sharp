using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlocDeNotasCastilloCorpusYCastilloPardo
{
    public partial class Form2 : Form
    {
        Form1 FormaPrincipal;
        //int cont = 0;
        public Form2(Form1 f)
        {
            InitializeComponent();
            FormaPrincipal = f;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //FormaPrincipal.PalBuscar = textBox1.Text;
            
            
            //this.Focus();
            //FormaPrincipal.Focus();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormaPrincipal.AAA(textBox1.Text, textBox1.TextLength);
            FormaPrincipal.Focus();
            //this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormaPrincipal.cont += textBox1.TextLength;
            FormaPrincipal.cont = FormaPrincipal.AAA(textBox1.Text, textBox1.TextLength);
            FormaPrincipal.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormaPrincipal.cont += textBox1.TextLength;
            FormaPrincipal.cont = FormaPrincipal.AAA(textBox1.Text, textBox1.TextLength);
            FormaPrincipal.Focus();
        }
    }
}
