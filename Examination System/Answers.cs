using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class Answers
    {
        public int AnswerID { get; set; }
        public string AnswerText { get; set; }

        public Answers(int _AnswerID, string _AnswerText)
        {
            AnswerID= _AnswerID;
            AnswerText= _AnswerText;
        }
        public Answers(Answers answer)
        {
             AnswerID = answer.AnswerID;
            AnswerText= answer.AnswerText;
        }

        public override string ToString()
        {
            return $" answer id {AnswerID} and the answer itself is  {AnswerText}";
        }
    }
}
