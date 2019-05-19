using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;


namespace GradesCS
{
    class Program
    {
        static void Main(string[] args)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("Hello! This is the Grade book program by HuBa 95 ");
            GradeBook book = new GradeBook();
            book.NameChanged = new NameChangedDelegate(OnNameChanged);
            book.Name = "HuBa`s Gradebook";
            // book.Name = "";
            try
            {
                Console.WriteLine("Enter name:");
                book.Name = Console.ReadLine();

            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
            book.AddGrade(99);

            using (StreamWriter outputfile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputfile);
                //outputfile.Close();
            }
            book.WriteGrades(Console.Out);

            /*  GradeBook book2 = book;
              book2.AddGrade(95);*/
            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            Console.ReadKey();
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}: {result:F2}");
        }
        static void OnNameChanged(string exName, string newName)
        {
            Console.WriteLine($"GradeBook changing name from {exName} to {newName}");
        }
    }
}
