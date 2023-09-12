using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class Subject
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Exam ExamOfSubject;
        public Subject(int _ID,string _Name)
        {
            ID= _ID;
            Name= _Name;
        }

        public void CreateExam()
        {
            Console.WriteLine("please enter the type of exam you want to create (1 for practical and 2 for final) :");
            bool IsExam_Type_Entered = int.TryParse(Console.ReadLine(), out int ExamType);

            if (IsExam_Type_Entered)
            {



                bool IsExam_Time_Entered;
                bool IsExam_QuestionNumber_Entered;
                int TimeOfExam;
                int NumOfQuestions;

                do
                {
                    Console.WriteLine("please enter the time of exam .");
                     IsExam_Time_Entered = int.TryParse(Console.ReadLine(), out  TimeOfExam);

                } while (!IsExam_Time_Entered);



                do
                {
                    Console.WriteLine("please enter the number of questions in the  exam .");
                    IsExam_QuestionNumber_Entered = int.TryParse(Console.ReadLine(), out  NumOfQuestions);

                } while (!IsExam_QuestionNumber_Entered);


                ExamOfSubject = ExamType == 1 ? new PracticalExam(TimeOfExam, NumOfQuestions) : new FinalExam(TimeOfExam, NumOfQuestions);



            }
        }
    }
}
