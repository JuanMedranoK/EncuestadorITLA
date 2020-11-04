using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Answer
    {
        public int ID_ANSWER { get; set; }
        public int ID_QUESTION { get; set; }
        public int ID_USER { get; set; }
        public string NAME_PERSON { get; set; }
        public string ANSWER { get; set; }
    }
}
