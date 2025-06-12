using System;
using System.Collections.Generic;

namespace StudentGradeManager
{
    class Student
    {
        public string Name { get; set; }
        public double Score { get; set; }

        public string GetGrade()
        {
            if (Score >= 90) return "A";
            else if (Score >= 80) return "B";
            else if (Score >= 70) return "C";
            else if (Score >= 60) return "D";
            else return "F";
        }
    }

    class Program
    {
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n--- Student Grade Manager ---");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View Students & Grades");
                Console.WriteLine("3. Exit");
                Console.Write("Enter choice: ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        ViewStudents();
                        break;
                    case "3":
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void AddStudent()
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            Console.Write("Enter student score (0-100): ");
            if (double.TryParse(Console.ReadLine(), out double score) && score >= 0 && score <= 100)
            {
                students.Add(new Student { Name = name, Score = score });
                Console.WriteLine("Student added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid score input.");
            }
        }

        static void ViewStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students available.");
                return;
            }

            Console.WriteLine("\nStudent List:");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name} - Score: {student.Score} - Grade: {student.GetGrade()}");
            }
        }
    }
}
