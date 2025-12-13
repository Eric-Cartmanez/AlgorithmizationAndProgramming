using System;

using Tasks.Common;

namespace Tasks.TheLargestClass
{
    public class TheLargestClass : ITheLargestClassSolution
    {
        public void Run()
        {
            int maxStudents = 0, temp = 0;
            int? prevSchool = null, prevClass = null;

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out int numClass))
                {
                    Console.WriteLine("incorrect class number");
                    return;
                }

                if (numClass == 0)
                {
                    Console.WriteLine(maxStudents);
                    return;
                }

                if (!int.TryParse(Console.ReadLine(), out int numSchool))
                {
                    Console.WriteLine("incorrect school number");
                    return;
                }

                if (numSchool == 0)
                {
                    Console.WriteLine(maxStudents);
                    return;
                }

                if (prevClass == null || (prevClass == numClass && prevSchool == numSchool))
                {
                    temp++;
                }
                else
                {
                    temp = 1;
                }

                maxStudents = Math.Max(maxStudents, temp);
                prevClass = numClass;
                prevSchool = numSchool;
            }
        }

        public int Calculate(int[] students)
        {
            int maxStudents = 0, temp = 0;
            int? prevSchool = null, prevClass = null;
            int i = 0;
            int numClass = students[0];
            int numSchool;

            while (true)
            {
                if (numClass == 0)
                    return maxStudents;

                i++;

                numSchool = students[i];

                if (numSchool == 0)
                    return maxStudents;

                if (prevClass == null || (prevClass == numClass && prevSchool == numSchool))
                {
                    temp++;
                }
                else
                {
                    temp = 1;
                }

                maxStudents = Math.Max(maxStudents, temp);
                prevClass = numClass;
                prevSchool = numSchool;
                i++;
                numClass = students[i];
            }
        }
    }
}
