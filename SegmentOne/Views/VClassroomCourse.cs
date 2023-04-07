using SegmentOne.Models;

namespace SegmentOne.Views;

public class VClassroomCourse : VBase
{
    public void GetAll(List<ClassroomCourse> classroomCourses)
    {
        Console.WriteLine("===================================");
        Console.WriteLine("Data Classroom Course");
        Console.WriteLine("===================================");
        foreach (var classroomCourse in classroomCourses)
        {
            Console.WriteLine("Id: " + classroomCourse.Id);
            Console.WriteLine("Classroom ID: " + classroomCourse.Id);
            Console.WriteLine("Classroom Code: " + classroomCourse.Classroom.Code);
            Console.WriteLine("Course ID: " + classroomCourse.Id);
            Console.WriteLine("Course Name: " + classroomCourse.Course.Name);
            Console.WriteLine("===================================");
        }
    }
}
