using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesCS
{
    class GradeBook
    {
        public void AddGrade(float grade)
        {
            grades.Add(grade);                  //method
        }

        List<float> grades;                 //field
    }
}
