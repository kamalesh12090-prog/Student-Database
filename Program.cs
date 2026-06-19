using System;

namespace Functional_Requirements
{
    class Program
    {
        static void Main(string[] args)
        {
            EnrollmentRepository repo = new EnrollmentRepository();

            while (true)
            {
                Console.WriteLine("\n===== Course Enrollment System =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View Students");
                Console.WriteLine("3. Add Course");
                Console.WriteLine("4. View Courses");
                Console.WriteLine("5. Enroll Student in Course");
                Console.WriteLine("6. View All Enrollments");
                Console.WriteLine("7. Search Student Enrollments");
                Console.WriteLine("8. Delete Enrollment");
                Console.WriteLine("9. Exit");

                Console.Write("Enter Choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Student Id: ");
                        int sid = int.Parse(Console.ReadLine());

                        Console.Write("Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Email: ");
                        string email = Console.ReadLine();

                        Console.Write("Department: ");
                        string dept = Console.ReadLine();

                        repo.AddStudent(
                            new Student(sid, name, email, dept));
                        break;

                    case 2:
                        repo.ViewStudents();
                        break;

                    case 3:
                        Console.Write("Course Id: ");
                        int cid = int.Parse(Console.ReadLine());

                        Console.Write("Course Title: ");
                        string title = Console.ReadLine();

                        repo.AddCourse(
                            new Course(cid, title));
                        break;

                    case 4:
                        repo.ViewCourses();
                        break;

                    case 5:
                        Console.Write("Student Id: ");
                        sid = int.Parse(Console.ReadLine());

                        Console.Write("Course Id: ");
                        cid = int.Parse(Console.ReadLine());

                        repo.EnrollStudent(sid, cid);
                        break;

                    case 6:
                        repo.ViewEnrollments();
                        break;

                    case 7:
                        Console.Write("Student Id: ");
                        sid = int.Parse(Console.ReadLine());

                        repo.SearchEnrollment(sid);
                        break;

                    case 8:
                        Console.Write("Student Id: ");
                        sid = int.Parse(Console.ReadLine());

                        Console.Write("Course Id: ");
                        cid = int.Parse(Console.ReadLine());

                        repo.DeleteEnrollment(sid, cid);
                        break;

                    case 9:
                        return;

                }
            }
        }
    }
}
