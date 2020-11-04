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
    public partial class Questions : Form
    {
        public Questions()
        {
            InitializeComponent();
        }

        QuizServices quizServices = new QuizServices();
        QuestionServices questionServices = new QuestionServices();

        #region Propiedades
        int count;
        private int Quiz_ID { get; set; }
        public string Quiz_Name { get; set; }
        public int index { get; set; }
        private string[] Question { get; set; }
        
        #endregion

        #region AddQuestions
        private void SetQuestion(string question, bool next)
        {
            if (next)
            {
                btnBack.Enabled = true;
                Question[count] = question;
                count++;
                if (btnNext.Text == "Guardar")
                {
                    SaveQuestion();
                    this.Hide();
                    Principal principal = new Principal();
                    principal.Show();
                }
                else
                {
                    lblPregunta.Text = "Pregunta numero: " + (count + 1).ToString();
                }

                if (count == index - 1)
                {
                    btnNext.Text = "Guardar";
                }
                if (count == index)
                {
                    Console.WriteLine("Se acabo");
                }
                else if(Question[count] == "")
                {
                    txtRespuesta.Text = "";
                }
                else
                {
                    txtRespuesta.Text = Question[count];
                }
            }
            else
            {
                Question[count] = question;
                count--;
                if(count == 0)
                {
                    btnBack.Enabled = false;
                }
                if (btnNext.Text == "Guardar")
                {
                    btnNext.Text = "Siguiente";
                }
                lblPregunta.Text = "Pregunta numero: " + (count + 1).ToString();
                if (Question[count] == "")
                {
                    txtRespuesta.Text = "";
                }
                else
                {
                    txtRespuesta.Text = Question[count];
                }
                if (count == index - 1)
                {
                    btnNext.Text = "Guardar";
                }
            }
        }
        private void SaveQuestion()
        {
            AddQuiz();
            if(questionServices.Save(this.index, this.Question, Quiz_ID))
            {
                MessageBox.Show("Sus preguntas fueron guardadas correctamente");
            }
            else
            {
                MessageBox.Show("Sus preguntas no fueron guardadas");
            }
        }
        #endregion

        #region AddQuiz
        private void AddQuiz()
        {
            Quiz_ID = quizServices.AddQuiz(UserLogged.Instance.user, Quiz_Name);
            if(Quiz_ID == 0)
            {
                MessageBox.Show("No se pudo agregar la encuesta");
                this.Hide();
                Principal principal = new Principal();
                principal.Show();
            }

        }
        #endregion
        
        private void Questions_Load(object sender, EventArgs e)
        {
            Question = new string[index];
            count = 0;
            btnBack.Enabled = false;
            if(index == 1)
            {
                btnNext.Text = "Guardar";
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (txtRespuesta.Text == "")
            {
                MessageBox.Show("Debe ingresar la pregunta");
            }
            else
                SetQuestion(txtRespuesta.Text, true);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            SetQuestion(txtRespuesta.Text, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
            this.Hide();
        }
    }
}
