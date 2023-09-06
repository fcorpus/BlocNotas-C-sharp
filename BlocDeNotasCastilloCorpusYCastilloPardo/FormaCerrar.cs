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
    public partial class FormaCerrar : Form
    {
        Form1 FormaPrincipal;
        public FormaCerrar(Form1 f)
        {
            InitializeComponent();

            FormaPrincipal = f;
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            FormaPrincipal.bandera = 1;
            this.Close();

        }

        private void No_Click(object sender, EventArgs e)
        {
            FormaPrincipal.bandera = -1;
            this.Close();
        }
    }
}
