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
    public partial class Quiz : Form
    {
        public string Quiz_Name { get; set; }
        public int ID_Quiz { get; set; }
        private int ID_Question { get; set; }
        private bool Editar { get; set; }
        public Quiz()
        {
            InitializeComponent();
        }
        QuestionServices questionServices = new QuestionServices();
        private void save()
        {
            if(richTextBox1.Text != "")
            {
                if (questionServices.add(richTextBox1.Text, ID_Quiz))
                {
                    MessageBox.Show("Su pregunta fue agregada correctamente");
                    
                }
                else
                {
                    MessageBox.Show("Su pregunta no pudo ser agregada");
                }
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
        }
        private void update(string pregunta, int id)
        {
            if (richTextBox1.Text != "")
            {
                if (questionServices.edit(pregunta, id, ID_Quiz))
                {
                    MessageBox.Show("Su pregunta fue editada correctamente");

                }
                else
                {
                    MessageBox.Show("Su pregunta no pudo ser modificada");
                }
                richTextBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
        }
        private void delete(int id_pregunta)
        {
            
            if (questionServices.delete(id_pregunta))
            {
                MessageBox.Show("Su pregunta fue eliminada correctamente");

            }
            else
            {
                MessageBox.Show("Su pregunta no pudo ser eliminada");
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!Editar)
            {
                save();
                dgv.DataSource = questionServices.getQuestions(ID_Quiz);
            }
            else
            {
                update(richTextBox1.Text, ID_Question);
                label2.Text = "Añadir Pregunta";
                Editar = false;
                dgv.DataSource = questionServices.getQuestions(ID_Quiz);
            }
            
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                ID_Question = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value.ToString());
                richTextBox1.Text = dgv.CurrentRow.Cells[1].Value.ToString();
                label2.Text = "Editar Pregunta";
                Editar = true;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Esta seguro de que desea eliminar esta encuesta?", "Atencion", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    dr = MessageBox.Show("Si elimina esta encuesta las respuestas de la misma seran borradas, Desea continuar?", "Atencion", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        delete(Convert.ToInt32(dgv.CurrentRow.Cells[0].Value.ToString()));
                        dgv.DataSource = questionServices.getQuestions(ID_Quiz);
                    }

                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }

        private void Quiz_Load(object sender, EventArgs e)
        {
            label1.Text = Quiz_Name;
            dgv.DataSource = questionServices.getQuestions(ID_Quiz);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Principal principal = new Principal();
            principal.Show();
        }
    }
}
