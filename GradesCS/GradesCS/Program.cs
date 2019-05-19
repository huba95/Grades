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
            Trowawaygb book = new Trowawaygb();
            book.NameChanged = new NameChangedDelegate(OnNameChanged);
            NameBook(book);
            AddingGrades(book);
            ShowingGrades(book);
            GradeStatistics(book);
            Console.ReadKey();
        }

        private static void GradeStatistics(Trowawaygb book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
        }

        private static void ShowingGrades(Trowawaygb book)
        {
            using (StreamWriter outputfile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputfile);
                //outputfile.Close();
            }
            book.WriteGrades(Console.Out);
        }

        private static void AddingGrades(Trowawaygb book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
            book.AddGrade(99);
        }

        private static void NameBook(GradeBook book)
        {
            book.Name = "HuBa`s Gradebook";
            // book.Name = "";
            try
            {
                Console.WriteLine("Enter name:");
                book.Name = Console.ReadLine();

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
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
