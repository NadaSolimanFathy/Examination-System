using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class Exam
    {
        public int TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }


        public List<Question> Exam_Questions { get; set; }
       

        public Exam(int _TimeOfExam, int _NumberOfQuestions)
        {
            TimeOfExam = _TimeOfExam;
            NumberOfQuestions = _NumberOfQuestions;
        }
        public virtual void ShowExamWithItsAnswers() => Console.WriteLine("will be implemented in child classes");
        public virtual  int[] ShowExam()
        {
            int[] UserAnswers=new int[Exam_Questions.Count];
            int TotalGrade = 0;
            int UserGrade = 0;
            int UserAnswer ;
            bool Is_UserAnswer_Entered;
            for (int i= 0; i < Exam_Questions.Count ; i++)
            {
                Console.WriteLine($"{Exam_Questions[i].Header} Question      Marks ({Exam_Questions[i].Mark})");
                TotalGrade += Exam_Questions[i].Mark;
                Console.WriteLine(Exam_Questions[i].GetBodyOfQuestion());
                for (int J = 0; J < Exam_Questions[i].AnswerLis.Length - 1; J++)
                {
                    Console.Write($"{Exam_Questions[i].AnswerLis[J].AnswerID}.  {Exam_Questions[i].AnswerLis[J].AnswerText}               ");
                    Console.WriteLine();
                }
                Console.WriteLine("-------------------------------------------------");

                do
                {
                    Console.WriteLine("enter the  answer number .");
                    Is_UserAnswer_Entered = int.TryParse(Console.ReadLine(),out UserAnswer);

                }
                while (!Is_UserAnswer_Entered);


                 UserAnswers[i]=UserAnswer;
                int RightAnswerIndex = Exam_Questions[i].AnswerLis.Length - 1;
                //                    thisExam

                if (UserAnswer == Exam_Questions[i].AnswerLis[RightAnswerIndex].AnswerID)
                {
                    UserGrade += Exam_Questions[i].Mark;
                }

                Console.WriteLine("================================================");

            }
         
            int[] UserFinalGrade ={ UserGrade,TotalGrade};

            Console.WriteLine("Your Answers .......");
            for (int q = 0; q < Exam_Questions.Count; q++)
            {

                for (int k = 0; k < Exam_Questions[q].AnswerLis.Length - 1; k++)//minus 1 as the correct res found  in the last index
                {

                    if (Exam_Questions[q].AnswerLis[k].AnswerID == UserAnswers[q])
                    {
                        Console.WriteLine($"Q{q + 1})  {Exam_Questions[q].GetBodyOfQuestion()}   :{Exam_Questions[q].AnswerLis[k].AnswerText} ");

                    }
                }
            }
            return UserFinalGrade;
        }


        public virtual void CreateExam(int _NumberOfQuestions) => Console.WriteLine("will be implemented in child classes");


 

        public Question Make_Same_Question(int Qnumber , Question_Header typeOfQuestion)
        {
            Question q;

            string QuestionBody;
            int QuestionMark;
            bool IsQuestion_Mark_Entered;


            do
            {
                Console.WriteLine($">>>Enter the Body Of Question Number {Qnumber}");
                QuestionBody = Console.ReadLine();


            } while (QuestionBody == "");

            do
            {
                Console.WriteLine($">>Enter the Mark Of Question Number {Qnumber}");
                IsQuestion_Mark_Entered = int.TryParse(Console.ReadLine(), out QuestionMark);


            } while (!IsQuestion_Mark_Entered);


            if (typeOfQuestion == Question_Header.MCQ)
            {

                q = new MCQ_Question(typeOfQuestion, QuestionBody, QuestionMark);
                return q;

            }
            else {
                q = new TF_Question(typeOfQuestion, QuestionBody, QuestionMark);
                return q;
            } 

        }





    }


    public class PracticalExam:Exam
    {
        public PracticalExam(int _TimeOfExam, int _NumberOfQuestions) : base(_TimeOfExam, _NumberOfQuestions)
        {
            Console.WriteLine();
            Console.WriteLine($"*** Practical Exam Choosen with {_TimeOfExam} min duration and {_NumberOfQuestions} Questions ***");
            Console.WriteLine();

            CreateExam(_NumberOfQuestions);

        }


        public override void CreateExam(int _NumberOfQuestions )
        {

            Exam_Questions = new List<Question>(_NumberOfQuestions);

            for (int i = 0; i < _NumberOfQuestions; i++)
            {
                //Console.WriteLine("please choose the type of question number "+(i+1));


                Answers[] answers = new Answers[4];
                int CorrectAnswer;
                string choice;
                bool IsCorrect_Answer_Entered;

                Question Mcq_Question=Make_Same_Question(i + 1,  Question_Header.MCQ);


                Console.WriteLine($"Enter the Choices For Question Number {i + 1}");
                for (int j = 0; j < 3; j++)
                {
                    do
                    {
                        Console.Write($"the  choice  number {j + 1} is : ");


                        choice = Console.ReadLine();
                        answers[j] = new Answers(j + 1, choice);
                    }
                    while (choice == "");

                }





                do
                {
                    Console.WriteLine($"Enter the Correct Answer For Question Number {i + 1}");
                    IsCorrect_Answer_Entered = int.TryParse(Console.ReadLine(), out CorrectAnswer);

                    for (int k = 0; k < 3; k++)
                    {

                        if (answers[k].AnswerID == CorrectAnswer)
                        {
                            answers[3] = new Answers(answers[k]);

                        }

                    }


                } while (!IsCorrect_Answer_Entered);


                Mcq_Question.AnswerLis=answers;
                // = new MCQ_Question(Question_Header.MCQ, QuestionBody, QuestionMark, answers);
                Exam_Questions.Add(Mcq_Question);
            }
        }


        //public override void ShowExamWithItsAnswers()
        //{
        //    foreach (Question q in Exam_Questions)
        //    {
        //        Console.WriteLine(q.ToString());
        //    }

        //}


        public override int[] ShowExam()
        {
            return base.ShowExam();
        }

    }



    public class FinalExam : Exam
    {
        public FinalExam(int _TimeOfExam, int _NumberOfQuestions) : base(_TimeOfExam, _NumberOfQuestions)
        {
            Console.WriteLine();
            Console.WriteLine($"*** Final Exam Choosen with {_TimeOfExam} min duration and {_NumberOfQuestions} Question ***");
            Console.WriteLine();

            CreateExam(_NumberOfQuestions);

        }




        public override void CreateExam(int _NumberOfQuestions)
        {

            Exam_Questions = new List<Question>(_NumberOfQuestions);
            int QuestionType;
            bool Is_QuestionType_Entered;
            for (int i = 0; i < _NumberOfQuestions; i++)
            {


                do
                {
                    Console.WriteLine($"please choose the type of question number  {i + 1}  [1: for T/F and 2: for MCQ]");
                    Is_QuestionType_Entered = int.TryParse(Console.ReadLine(), out QuestionType);
                }
                while (!Is_QuestionType_Entered);

                bool IsCorrect_Answer_Entered;


                if (QuestionType == 1) {
                    Answers[] answers = new Answers[3];
                    char CorrectAnswer;

                    Question TF_Question = Make_Same_Question(i + 1, Question_Header.True_or_False);



                    do
                    {
                        Console.WriteLine($"Enter the Correct Answer For Question Number {i + 1}");
                        IsCorrect_Answer_Entered = char.TryParse(Console.ReadLine(), out CorrectAnswer);

                        answers[0] = new Answers(1, 't'.ToString());
                        answers[1] = new Answers(2, 'f'.ToString());
                        for (int w = 0; w < 2; w++)
                        {
                            if (CorrectAnswer.ToString() == answers[w].AnswerText)
                            {
                                answers[2] = new Answers(answers[w].AnswerID, CorrectAnswer.ToString());

                            }
                        }


                    } while (!IsCorrect_Answer_Entered);


                    TF_Question.AnswerLis = answers;
                    Exam_Questions.Add(TF_Question);

                }
                else if(QuestionType == 2)
                {
                    Answers[] answers = new Answers[4];
                    int CorrectAnswer;

                    string choice;

                    Question Mcq_Question = Make_Same_Question(i + 1, Question_Header.MCQ);


                    Console.WriteLine($"Enter the Choices For Question Number {i + 1}");
                    for (int j = 0; j < 3; j++)
                    {
                        do
                        {
                            Console.Write($"the  choice  number {j + 1} is : ");


                            choice = Console.ReadLine();
                            answers[j] = new Answers(j + 1, choice);
                        }
                        while (choice == "");

                    }





                    do
                    {
                        Console.WriteLine($"Enter the Correct Answer For Question Number {i + 1}");
                        IsCorrect_Answer_Entered = int.TryParse(Console.ReadLine(), out CorrectAnswer);

                        for (int k = 0; k < 3; k++)
                        {

                            if (answers[k].AnswerID == CorrectAnswer)
                            {
                                answers[3] = new Answers(answers[k]);

                            }

                        }


                    } while (!IsCorrect_Answer_Entered);


                    Mcq_Question.AnswerLis = answers;
                    // = new MCQ_Question(Question_Header.MCQ, QuestionBody, QuestionMark, answers);
                    Exam_Questions.Add(Mcq_Question);
                }

           
            }
        }



        //public override void ShowExamWithItsAnswers()
        //{
           
        //    Console.WriteLine("hi in fimnal exam");
        //    foreach (Question q in Exam_Questions)
        //    {
        //        Console.WriteLine(q.ToString());
        //    }

        //}

        public override int[] ShowExam()
        {
            int[] UserFinalGrade = base.ShowExam();

            //Console.Clear();
        
            int UserGrade = UserFinalGrade[0];
            int TotalGrade = UserFinalGrade[1];

            Console.WriteLine($"Your Grade is {UserGrade} /{TotalGrade}");


            return UserFinalGrade;
        }


    }
}
