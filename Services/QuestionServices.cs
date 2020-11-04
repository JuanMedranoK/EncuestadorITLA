using Services.EntitiesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Services
{
    public class QuestionServices
    {
        QuestionRepository questionRepository = new QuestionRepository();
        Question question = new Question();
        bool correcto;
        public bool Save(int index, string[] question, int id_quiz)
        {
            for (int i = 0; i < index; i++)
            {
                this.question.ID_QUIZ = id_quiz;
                this.question.QUESTION = question[i];
                if (questionRepository.Add(this.question))
                {
                    correcto = true;
                }
                else
                {
                    correcto = false;
                }
            }
            return correcto;
        }
        public bool add(string pregunta, int id_quiz)
        {
            this.question.ID_QUIZ = id_quiz;
            this.question.QUESTION = pregunta;
            return questionRepository.Add(question);
        }
        public bool edit(string pregunta, int id_pregunta, int id_quiz)
        {
            this.question.ID_QUESTION = id_pregunta;
            this.question.QUESTION = pregunta;
            this.question.ID_QUIZ = id_quiz;
            return questionRepository.Edit(question);
        }
        public bool delete(int id)
        {
            return questionRepository.Delete(id);
        }
        public DataTable getQuestions(int id)
        {
            return questionRepository.GetSpecific("SELECT ID_QUESTION, QUESTION FROM QUESTIONS WHERE ID_QUIZ = " + id.ToString());
        }
        public DataTable getSpecific(string query)
        {
            return questionRepository.GetSpecific(query);
        }
    }
}
