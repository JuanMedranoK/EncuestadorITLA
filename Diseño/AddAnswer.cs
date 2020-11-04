using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;

namespace Diseño
{
    public partial class AddAnswer : Form
    {
        QuestionServices questionServices = new QuestionServices();
        public DataTable quiz { get; set; }
        public AddAnswer()
        {
            InitializeComponent();
        }

        private void AddAnswer_Load(object sender, EventArgs e)
        {
            dgvQuiz.DataSource = quiz;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
                {
                    if (dgvQuiz.SelectedRows.Count > 0)
                    {
                        Answers answers = new Answers();
                        answers.Nombre = txtNombre.Text;
                        answers.preguntas = questionServices.getSpecific("SELECT ID_QUESTION, QUESTION FROM QUESTIONS WHERE ID_QUIZ = " + dgvQuiz.CurrentRow.Cells[0].Value.ToString());
                        answers.ShowDialog();
                    }
                    else
                    {
                    MessageBox.Show("Seleccione una fila");
                    }
                }
            else
            {
                MessageBox.Show("Ingrese un nombre");

            }
                
        }

        private void dgvQuiz_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            button1.Enabled = true;
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
            this.Hide();
        }
    }
}
