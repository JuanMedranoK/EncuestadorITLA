using Services.EntitiesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Services.EtitiesRepository
{
    public class AnswerService
    {
        Answer answer = new Answer();
        AnswerRepository answerRepository = new AnswerRepository();
        public bool AddAnswer(int question, User user, string name, string respuesta)
        {
            answer.ID_QUESTION = question;
            answer.ID_USER = user.ID_USER;
            answer.NAME_PERSON = name;
            answer.ANSWER = respuesta;
            return answerRepository.Add(answer);
            
        }
        public DataTable getSpecific(string query)
        {
            return answerRepository.GetSpecific(query);
        }
    }
}

