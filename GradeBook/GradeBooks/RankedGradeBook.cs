﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranking-grading requries a minimum of 5 students to work");

            var threshold = (int)Math.Ceiling(Students.Count * 0.2);

            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (grades[threshold-1] <= averageGrade)
            {
                return 'A';
            }
            else if(grades[(threshold *2)-1] <= averageGrade)
            {
                return 'B';
            }
            else if(grades[(threshold*3)-1] <= averageGrade)
            {
                return 'C';
            }
            else if (grades[(threshold*4)-1] <= averageGrade)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("'Ranked grading requires at least 5 students.");
                return;
            }

            if (Students.Count > 5)
            {
                base.CalculateStatistics();
            }

            
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
                

            if (Students.Count > 5)
            {
                base.CalculateStudentStatistics(name);
            }
            
        }

    }
}
