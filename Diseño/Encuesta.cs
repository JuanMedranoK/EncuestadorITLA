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
using Services.EtitiesRepository;

namespace Diseño
{
    public partial class Encuesta : Form
    {
        QuizServices quizServices = new QuizServices();
        Quiz quiz = new Quiz();
        QuestionServices questionServices = new QuestionServices();
        AnswerService answerServices = new AnswerService();
        public Encuesta()
        {
            InitializeComponent();
        }

        private void Encuesta_Load(object sender, EventArgs e)
        {
            getQuiz();
        }

        #region Get
        private void getQuiz()
        {
            dgvQuiz.DataSource = quizServices.getSpecific("SELECT Q.ID_QUIZ AS CODIGO, Q.NAME AS ENCUESTA, Q.ID_USER AS 'CODIGO DE USUARIO', U.NAME + ' ' + U.LASTNAME AS CREADOR FROM QUIZ Q INNER JOIN USERS U ON Q.ID_USER = U.ID_USER");
        }
        private void getQuestion(int ID_Quiz)
        {
            dgvPrincipal.DataSource = questionServices.getSpecific("SELECT ID_QUESTION, QUESTION FROM QUESTIONS WHERE ID_QUIZ = " + ID_Quiz);
        }
        private DataTable getAnswer(int ID_Question)
        {
            return answerServices.getSpecific("SELECT ID_ANSWER, ANSWER, ID_USER, NAME_PERSON FROM ANSWERS WHERE ID_QUESTION = " + ID_Question);
        }

        #endregion


        private void dgvQuiz_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dgvQuiz.CurrentCell.RowIndex;
            getQuestion(Convert.ToInt32(dgvQuiz.Rows[row].Cells[0].Value.ToString()));
            button1.Enabled = true;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            ViewAnswer viewAnswer = new ViewAnswer();
            viewAnswer.Pregunta = dgvPrincipal.CurrentRow.Cells[1].Value.ToString();
            viewAnswer.fuente = getAnswer(Convert.ToInt32(dgvPrincipal.CurrentRow.Cells[0].Value.ToString()));
            viewAnswer.ShowDialog();
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Principal principal = new Principal();
            principal.Show();
        }
    }
}
