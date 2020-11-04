using Services;
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
    public partial class Principal : Form
    {
        private string query = "SELECT QUIZ.ID_QUIZ AS 'CODIGO', QUIZ.NAME AS NOMBRE, USERS.NAME + ' ' + USERS.LASTNAME AS USUARIO FROM QUIZ"
                + " INNER JOIN USERS ON QUIZ.ID_USER = USERS.ID_USER WHERE QUIZ.ID_USER = " + UserLogged.Instance.user.ID_USER;

        QuizServices quizServices = new QuizServices();
        public Principal()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddQuiz add = new AddQuiz();
            DialogResult dr = add.ShowDialog();
            if(dr == DialogResult.Yes)
            {
                this.Hide();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgv.SelectedRows.Count > 0)
            {
                Quiz quiz = new Quiz();
                quiz.ID_Quiz = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value.ToString());
                quiz.Quiz_Name = dgv.CurrentRow.Cells[1].Value.ToString();
                quiz.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
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
                        QuizServices quizServices = new QuizServices();
                        quizServices.Delete(Convert.ToInt32(dgv.CurrentRow.Cells[0].Value.ToString()));
                        dgv.DataSource = quizServices.getSpecific(query);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserLogged.Instance.user = null;
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            
            dgv.DataSource = quizServices.getSpecific(query);
        }

        private void verEncuestasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Encuesta encuesta = new Encuesta();
            encuesta.Show();
            this.Hide();
        }

        private void participarEnEncuestaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAnswer addAnswer = new AddAnswer();
            addAnswer.quiz = quizServices.getSpecific("SELECT Q.ID_QUIZ AS CODIGO, Q.NAME AS ENCUESTA, Q.ID_USER AS 'CODIGO DE USUARIO', U.NAME + ' ' + U.LASTNAME AS CREADOR FROM QUIZ Q INNER JOIN USERS U ON Q.ID_USER = U.ID_USER");
            addAnswer.Show();
            this.Hide();
        }
    }
}
