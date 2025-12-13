using System;

using Tasks.Common;

namespace Tasks.TheLargestClass
{
    public class TheLargestClassAlt : ITheLargestClassSolution
    {
    public void Run()
    {
        int prevClass = -1;
        int prevSchool = -1;

        int currentCount = 0;
        int maxCount = 0;

        while (true)
        {
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int classNum)) break; 

            if (classNum == 0) break;

            int schoolNum = int.Parse(Console.ReadLine());

            if (classNum == prevClass && schoolNum == prevSchool)
            {
                currentCount++;
            }
            else
            {
                maxCount = Math.Max(currentCount, maxCount);
                currentCount = 1;
                prevClass = classNum;
                prevSchool = schoolNum;
            }
        }

        maxCount = Math.Max(currentCount, maxCount);

        Console.WriteLine(maxCount);
    }


        public int Calculate(int[] students)
        {
        int prevClass = -1;
        int prevSchool = -1;

        int currentCount = 0;
        int maxCount = 0;

        int i = 0;

        while (true)
        {
            int classNum = students[i];

            if (classNum == 0) break;

            i++;

            int schoolNum = students[i];

            if (classNum == prevClass && schoolNum == prevSchool)
            {
                currentCount++;
            }
            else
            {
                maxCount = Math.Max(currentCount, maxCount);
                currentCount = 1;
                prevClass = classNum;
                prevSchool = schoolNum;
            }
            i++;
        }

         return Math.Max(currentCount, maxCount);
        }
    }
}