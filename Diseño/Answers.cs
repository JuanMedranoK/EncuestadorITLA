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
    public partial class Answers : Form
    {
        public Answers()
        {
            InitializeComponent();
        }
        
        AnswerService answerService = new AnswerService();

        public DataTable preguntas { get; set; }
        public string Nombre { get; set; }
        private string[] respuestas { get; set; }
        private int index { get; set; } = 0;
        


        private void save()
        {
            int count = 0;
            for(int i = 0;i < preguntas.Rows.Count; i++)
            {
                if(!answerService.AddAnswer(Convert.ToInt32(preguntas.Rows[i][0]), UserLogged.Instance.user, Nombre, respuestas[i])){
                    MessageBox.Show("La respuesta '"+ respuestas[i] +"' no fue guardada");
                    break;
                }
                else
                {
                    count++;
                }
            }
            MessageBox.Show(count + " respuestas fueron añadidas correctamente");
            this.Hide();

        }

        private void Next()
        {
            respuestas[index] = txtRespuesta.Text;
            if (btnNext.Text == "Guardar")
            {
                save();
            }
            else if (index < preguntas.Rows.Count - 2)
            {
                txtRespuesta.Text = respuestas[index + 1];
                lblPregunta.Text = preguntas.Rows[index + 1][1].ToString();
            }
            else
            {
                btnNext.Text = "Guardar";
                txtRespuesta.Text = respuestas[index + 1];
                lblPregunta.Text = preguntas.Rows[index + 1][1].ToString();
            }
        }

        private void Back()
        {
            if (btnNext.Text == "Guardar")
            {
                btnNext.Text = "Siguiente";
            }
            txtRespuesta.Text = respuestas[index];
            
        }



        private void Answers_Load(object sender, EventArgs e)
        {
            lblPregunta.Text = preguntas.Rows[index][1].ToString();
            respuestas = new string[preguntas.Rows.Count];
            if(preguntas.Rows.Count == 1)
            {
                btnNext.Text = "Guardar";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            if (txtRespuesta.Text != "") 
            {
                Next();
                btnBack.Enabled = true;
                index++;
            }
            else
            {
                MessageBox.Show("Debe llenar el campo");
            }
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            index--;
            lblPregunta.Text = preguntas.Rows[index][1].ToString();
            Back();
            if (index == 0)
            {
                btnBack.Enabled = false;
            }
        }
    }
}
