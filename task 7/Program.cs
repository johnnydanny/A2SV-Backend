namespace StudentInformation{
    class Program
{
    static void Main(string[] args)
    {
        var studentList = new StudentList<Student>();

        // Add some students
        studentList.AddStudent(new Student(1, "Alice", 18, "A"));
        studentList.AddStudent(new Student(2, "Bob", 19, "B"));
        studentList.AddStudent(new Student(3, "Charlie", 20, "C"));

        // Serialize 
        studentList.SerializeToJson("students.json");

        // Deserialize
        studentList.DeserializeFromJson("students.json");

        // Search by Name
        var student = studentList.GetStudentByName("Bob");
        if (student != null)
        {
            Console.WriteLine($"Found student: Roll Number: {student.RollNumber}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }

        // Search by Id
        student = studentList.GetStudentById(3);
        if (student != null)
        {
            Console.WriteLine($"Found student: Roll Number: {student.RollNumber}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }

        // Display 
        studentList.DisplayAllStudents();
    }
}
}