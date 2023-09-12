using System;
using System.Diagnostics;

namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //define the subject that you want to make exam for it
            Subject subject1 = new Subject(1, "intro to CS");
            //exam creation
            subject1.CreateExam();
            Console.WriteLine("Exam is made successfully ");
            Console.Clear();



            Console.WriteLine("Do you want to start the exam ? (y|n)");

            if (char.Parse(Console.ReadLine())=='y'){
                Stopwatch sw= new Stopwatch();
                sw.Start();

                //doing the exam here
                subject1.ExamOfSubject.ShowExam();

                Console.WriteLine($"the elapsed time is {sw.Elapsed}");

            }

            //subject1.ExamOfSubject.ShowExamWithItsAnswers();

         


        }

    }
}
