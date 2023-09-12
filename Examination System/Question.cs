using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{

    public enum Question_Header
    {
        True_or_False,
        MCQ
    }
    public class Question
    {

        public Question_Header Header { get; set; }

        private string bodyOfQuestion;

        public  string GetBodyOfQuestion()
        {
            return bodyOfQuestion;
        }
        public void SetBodyOfQuestion(string questionBody)
        {

            string question_Body=questionBody??"coming with null";

            int questionLength= question_Body.Length;

            if (question_Body[questionLength-1] =='?') {
                bodyOfQuestion= question_Body;
            }
            else bodyOfQuestion = question_Body + " ?";

        }

        public int Mark { get; set; }

        Answers[] answerLis ;
        public Answers[] AnswerLis
        {
            get { return answerLis; }
            set { answerLis = value; }
        }
        public Question(Question_Header _Header, string _bodyOfQuestion, int _Mark)
        {
            Header = _Header;
            SetBodyOfQuestion(_bodyOfQuestion);
            Mark = _Mark;
        }


        public override string ToString()
        {
            return $"{Header} Question : {bodyOfQuestion}    ({Mark}) marks.";
        }
    }


    public class TF_Question:Question
    {

        //Answers[] AnswerLis = new Answers[1];


        public TF_Question(Question_Header _Header, string _bodyOfQuestion, int _Mark) : this(_Header, _bodyOfQuestion, _Mark, null)

        {
        }


        public TF_Question(Question_Header _Header, string _bodyOfQuestion, int _Mark, Answers[] _AnswerLis) : base(_Header, _bodyOfQuestion, _Mark)
        {
            AnswerLis = _AnswerLis;

        }

      
        public override string ToString()
        {
            return $"{base.ToString()} and the correct  {AnswerLis[2]} ";
        }

    }


    public class MCQ_Question : Question
    {
      
        public MCQ_Question(Question_Header _Header, string _bodyOfQuestion, int _Mark) : this(_Header,_bodyOfQuestion,_Mark,null)

        {
        }


        public MCQ_Question(Question_Header _Header, string _bodyOfQuestion, int _Mark, Answers[] _AnswerLis) : base(_Header, _bodyOfQuestion, _Mark)

        {
            AnswerLis = _AnswerLis;
        }

        public override string ToString()
        {
            return  $"{base.ToString()} and the correct  { AnswerLis[3]} ";
        }
    }
}
