using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesCS
{
    public class GradeBook
    {
        public GradeBook()
        {
            name = "Empty";
            grades = new List<float>();
        }

        public void AddGrade(float grade)
        {
            grades.Add(grade);                  //method
        }

        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();
            
            float sum = 0;
            foreach(float grade in grades)
            {
                /*if(grade>stats.HighestGrade)
                {
                    stats.HighestGrade = grade;
                }*/
                stats.HighestGrade = Math.Max(stats.HighestGrade, grade);
                stats.LowestGrade = Math.Min(stats.LowestGrade, grade);
                sum = sum + grade;
            }
            stats.AverageGrade = sum / grades.Count;

            return stats;
        }

        private List<float> grades;                 //field
        private string name;
        public string Name                        //property
        {
            get
            {
                return name;
            }
            set
            {
                if(!String.IsNullOrEmpty(value))
                {
                    if (name != value)
                    {
                        NameChanged(name, value);
                    }


                    name = value;
                }

            }
        }
        public NameChangedDelegate NameChanged;
    }
}
