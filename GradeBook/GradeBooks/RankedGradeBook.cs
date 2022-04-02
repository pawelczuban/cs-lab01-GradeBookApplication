using System;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5) throw new InvalidOperationException();

            int betterStudentsCount = 0;
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].AverageGrade > averageGrade) betterStudentsCount++;
            }
            double rank = (double)(betterStudentsCount+1) / Students.Count;
            Console.WriteLine(rank);
            System.Diagnostics.Debug.WriteLine("Matrix has you...");
            if (rank <= .2) return 'A';
            else if (rank <= .4) return 'B';
            else if (rank <= .6) return 'C';
            else if (rank <= .8) return 'D';
            else return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5) Console.WriteLine("Ranked grading requires at least 5 students.");
            else base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5) Console.WriteLine("Ranked grading requires at least 5 students.");
            else base.CalculateStudentStatistics(name);
        }
    }
}
