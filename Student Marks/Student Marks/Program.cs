using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Grade Calculator");

            List<Student> students = new List<Student>();

            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"Enter mark for student {i}: ");
                int mark = -1;

                // Prompt the user to enter a valid mark (between 0 and 100)
                while (mark < 0 || mark > 100)
                {
                    if (!int.TryParse(Console.ReadLine(), out mark))
                    {
                        Console.Write("Please enter a valid integer between 0 and 100: ");
                    }
                    else if (mark < 0 || mark > 100)
                    {
                        Console.Write("Please enter a mark between 0 and 100: ");
                    }
                }

                Student student = new Student(i, mark);
                students.Add(student);
            }

            Console.WriteLine("\nStudent\tMark\tGrade");

            foreach (Student student in students)
            {
                Console.WriteLine($"{student.Id}\t{student.Mark}\t{student.Grade}");
            }

            int mean = (int)students.Average(s => s.Mark);
            int min = students.Min(s => s.Mark);
            int max = students.Max(s => s.Mark);

            Console.WriteLine($"\nMean Mark: {mean}");
            Console.WriteLine($"Minimum Mark: {min}");
            Console.WriteLine($"Maximum Mark: {max}");

            Console.WriteLine("\nGrade Profile:");
            Console.WriteLine($"A: {CalculateGradePercentage(students, "A")}%");
            Console.WriteLine($"B: {CalculateGradePercentage(students, "B")}%");
            Console.WriteLine($"C: {CalculateGradePercentage(students, "C")}%");
            Console.WriteLine($"D: {CalculateGradePercentage(students, "D")}%");
            Console.WriteLine($"F: {CalculateGradePercentage(students, "F")}%");
        }

        static int CalculateGradePercentage(List<Student> students, string grade)
        {
            int totalStudents = students.Count();
            int gradeCount = students.Count(s => s.Grade == grade);

            return (int)((double)gradeCount / totalStudents * 100);
        }

        class Student
        {
            public int Id { get; set; }
            public int Mark { get; set; }
            public string Grade { get; set; }

            public Student(int id, int mark)
            {
                Id = id;
                Mark = mark;

                if (mark >= 70 && mark <= 100)
                {
                    Grade = "A";
                }
                else if (mark >= 60 && mark <= 69)
                {
                    Grade = "B";
                }
                else if (mark >= 50 && mark <= 59)
                {
                    Grade = "C";
                }
                else if (mark >= 40 && mark <= 49)
                {
                    Grade = "D";
                }
                else
                {
                    Grade = "F";
                }
            }
        }
    }
}
