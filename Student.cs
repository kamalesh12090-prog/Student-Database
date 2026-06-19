namespace Functional_Requirements
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }

        public Student(int studentId, string studentName, string email, string department)
        {
            StudentId = studentId;
            StudentName = studentName;
            Email = email;
            Department = department;
        }
    }
}