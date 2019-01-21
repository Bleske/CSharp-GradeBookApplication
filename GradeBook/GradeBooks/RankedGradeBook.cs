using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading reqiures a minimum of 5 students to work");
            }

            double over, under;
            over = under = 1;

            foreach (Student student in Students)
            {
                if (student.AverageGrade >= averageGrade)
                {
                    over += 1;
                } else
                {
                    under += 1;
                }
            }

            if (over == 0) {
                return 'A';
            }else if (under == 0){
                return 'F';
            }

            int percent = (int)Math.Ceiling(over / over + under + 1);
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
    }
}
