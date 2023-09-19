namespace StudentInformation{
    class Program
{
    static void Main(string[] args)
    {
        var studentList = new StudentList<Student>();

        // Add some students
        studentList.AddStudent(new Student(1, "JohnDman", 23, "A"));
        studentList.AddStudent(new Student(2, "Jude", 12, "A"));
        studentList.AddStudent(new Student(3, "Danny", 22, "A"));

        // Serialize 
        studentList.SerializeToJson("students.json");

        // Deserialize
        studentList.DeserializeFromJson("students.json");

        // Search by Name
        var student = studentList.GetStudentByName("JohnDman");
        if (student != null)
        {
            Console.WriteLine($"Found student: Roll Number: {student.RollNumber}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }

        // Search by Id
        student = studentList.GetStudentById(12);
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