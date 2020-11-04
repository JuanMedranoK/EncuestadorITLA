using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diseño
{
    public partial class ViewAnswer : Form
    {
        public string Pregunta { get; set; }
        public DataTable fuente { get; set; }
        public ViewAnswer()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            label1.Text = Pregunta;
            dataGridView1.DataSource = fuente;
        }
    }
}
