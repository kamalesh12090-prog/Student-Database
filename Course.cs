namespace Functional_Requirements
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }

        public Course(int courseId, string courseTitle)
        {
            CourseId = courseId;
            CourseTitle = courseTitle;
        }
    }
}