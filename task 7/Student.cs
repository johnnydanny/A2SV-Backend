using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StudentInformation
{
    public class Student
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public readonly int RollNumber;
        public string Grade { get; set; } = string.Empty;

        public Student(int rollNumber, string name, int age, string grade)
        {
            RollNumber = rollNumber;
            Name = name;
            Age = age;
            Grade = grade;
        }
    }

    public class StudentList<T> where T : Student
    {
        private List<T> students = new List<T>();

        public void AddStudent(T student)
        {
            students.Add(student);
        }

        public T? GetStudentByName(string name)
        {
            return students.FirstOrDefault(s => s.Name == name);
        }

        public T? GetStudentById(int rollNumber)
        {
            return students.FirstOrDefault(s => s.RollNumber == rollNumber);
        }

        public void SerializeToJson(string filePath)
        {
            try
            {
                string json = JsonConvert.SerializeObject(students, Formatting.Indented);
                File.WriteAllText(filePath, json);
                Console.WriteLine("Serialization completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during serialization: {ex.Message}");
            }
        }

        public void DeserializeFromJson(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    List<T>? deserializedStudents = JsonConvert.DeserializeObject<List<T>>(json);
                    students = deserializedStudents ?? throw new Exception("Deserialization returned null.");
                    Console.WriteLine("Deserialization completed successfully.");
                }
                else
                {
                    Console.WriteLine("File does not exist for deserialization.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }
        }

        public void DisplayAllStudents()
        {
            foreach (var student in students)
            {
                Console.WriteLine($"Roll Number: {student.RollNumber}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
            }
        }
    }
}
