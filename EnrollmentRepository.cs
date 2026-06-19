using System;
using MySql.Data.MySqlClient;

namespace Functional_Requirements
{
    public class EnrollmentRepository
    {
        public void AddStudent(Student s)
        {
            using MySqlConnection con =
                new MySqlConnection(DBHelper.ConnectionString);

            string query = "insert into Students values(@id,@name,@email,@dept)";

            MySqlCommand cmd = new MySqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", s.StudentId);
            cmd.Parameters.AddWithValue("@name", s.StudentName);
            cmd.Parameters.AddWithValue("@email", s.Email);
            cmd.Parameters.AddWithValue("@dept", s.Department);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Student Added Successfully");
        }

        public void ViewStudents()
        {
            using MySqlConnection con =
                new MySqlConnection(DBHelper.ConnectionString);

            string query = "select * from Students";

            MySqlCommand cmd = new MySqlCommand(query, con);

            con.Open();

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"{dr["StudentId"]} {dr["StudentName"]} {dr["Email"]} {dr["Department"]}");
            }
        }

        public void AddCourse(Course c)
        {
            using MySqlConnection con =
                new MySqlConnection(DBHelper.ConnectionString);

            string query = "insert into Courses values(@id,@title)";

            MySqlCommand cmd = new MySqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", c.CourseId);
            cmd.Parameters.AddWithValue("@title", c.CourseTitle);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Course Added Successfully");
        }

        public void ViewCourses()
        {
            using MySqlConnection con =
                new MySqlConnection(DBHelper.ConnectionString);

            string query = "select * from Courses";

            MySqlCommand cmd = new MySqlCommand(query, con);

            con.Open();

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"{dr["CourseId"]} {dr["CourseTitle"]}");
            }
        }

        public void EnrollStudent(int sid, int cid)
        {
            using MySqlConnection con =
                new MySqlConnection(DBHelper.ConnectionString);

            string query =
                "insert into Enrollments(StudentId,CourseId) values(@sid,@cid)";

            MySqlCommand cmd = new MySqlCommand(query, con);

            cmd.Parameters.AddWithValue("@sid", sid);
            cmd.Parameters.AddWithValue("@cid", cid);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Enrollment Added");
        }

        public void ViewEnrollments()
        {
            using MySqlConnection con =
                new MySqlConnection(DBHelper.ConnectionString);

            string query =
                @"select e.EnrollmentId,
                         s.StudentName,
                         c.CourseTitle
                  from Enrollments e
                  join Students s on e.StudentId=s.StudentId
                  join Courses c on e.CourseId=c.CourseId";

            MySqlCommand cmd = new MySqlCommand(query, con);

            con.Open();

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"{dr["EnrollmentId"]} {dr["StudentName"]} {dr["CourseTitle"]}");
            }
        }

        public void SearchEnrollment(int sid)
        {
            using MySqlConnection con =
                new MySqlConnection(DBHelper.ConnectionString);

            string query =
                @"select s.StudentName,c.CourseTitle
                  from Enrollments e
                  join Students s on e.StudentId=s.StudentId
                  join Courses c on e.CourseId=c.CourseId
                  where e.StudentId=@sid";

            MySqlCommand cmd = new MySqlCommand(query, con);

            cmd.Parameters.AddWithValue("@sid", sid);

            con.Open();

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"{dr["StudentName"]} {dr["CourseTitle"]}");
            }
        }

        public void DeleteEnrollment(int sid, int cid)
        {
            using MySqlConnection con =
                new MySqlConnection(DBHelper.ConnectionString);

            string query =
                "delete from Enrollments where StudentId=@sid and CourseId=@cid";

            MySqlCommand cmd = new MySqlCommand(query, con);

            cmd.Parameters.AddWithValue("@sid", sid);
            cmd.Parameters.AddWithValue("@cid", cid);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Enrollment Deleted");
        }
    }
}