﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
            IsWeighted = isWeighted;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading reqiures a minimum of 5 students to work");
            }

            double under = 0;

            foreach (Student student in Students)
            {
                if (student.AverageGrade < averageGrade)
                {
                    under += 1;
                }
            }

            if (under == 0){
                return 'F';
            }

            int percent = (int)Math.Ceiling((under / (Students.Count-1))*100);
            if (percent > 80)
            {
                return 'A';
            }else if (percent > 60)
            {
                return 'B';
            }else if (percent > 40)
            {
                return 'C';
            }else if (percent > 20)
            {
                return 'D';
            } else
            {
                return 'F';
            }


        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
