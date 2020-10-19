using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            this.Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            List<double> grades = new List<double>();
            int division = (int)(Math.Ceiling(Students.Count * 0.2d));

            if (Students.Count < 5) throw new InvalidOperationException();

            foreach (Student item in Students)
            {
                grades.Add(item.AverageGrade);
            }

            grades.Sort();
            grades.Reverse();

            if (grades[division - 1] <= averageGrade) return 'A';
            else if (grades[division * 2 - 1] <= averageGrade) return 'B';
            else if (grades[division * 3 - 1] <= averageGrade) return 'C';
            else if (grades[division * 4 - 1] <= averageGrade) return 'D';
            else return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5) 
                Console.WriteLine("Ranked grading requires at least 5 students.");
            else
                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students.");
            else
                base.CalculateStudentStatistics(name);
        }
    }
}
