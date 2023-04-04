using SegmentOne.Models;

namespace SegmentOne.Views;

public class VCourse
{
    public void GetAll(List<Course> courses)
    {
        Console.WriteLine("===================================");
        Console.WriteLine("Data Course");
        Console.WriteLine("===================================");
        foreach (var course in courses)
        {
            Console.WriteLine("Id: " + course.Id);
            Console.WriteLine("Name: " + course.Name);
            Console.WriteLine("Description: " + course.Description);
            Console.WriteLine("GradeId: " + course.GradeId);
            Console.WriteLine("TeacherId: " + course.TeacherId);
            Console.WriteLine("===================================");
        }
    }

    public void GetById(Course course)
    {
        Console.WriteLine("===================================");
        Console.WriteLine("Data Course");
        Console.WriteLine("===================================");
        Console.WriteLine("Id: " + course.Id);
        Console.WriteLine("Name: " + course.Name);
        Console.WriteLine("Description: " + course.Description);
        Console.WriteLine("GradeId: " + course.GradeId);
        Console.WriteLine("TeacherId: " + course.TeacherId);
    }

    public void Success(string message)
    {
        Console.WriteLine($"Data has been {message}");
    }

    public void Failure(string message)
    {
        Console.WriteLine($"Data has not been {message}");
    }

    public void DataNotFound()
    {
        Console.WriteLine("Data Not Found!");
    }
}
