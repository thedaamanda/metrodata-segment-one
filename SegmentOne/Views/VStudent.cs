using SegmentOne.Models;

namespace SegmentOne.Views;

public class VStudent : VBase
{
    public void GetAll(List<Student> students)
    {
        Console.WriteLine("===================================");
        Console.WriteLine("Data Student");
        Console.WriteLine("===================================");
        foreach (var student in students)
        {
            Console.WriteLine("Id: " + student.Id);
            Console.WriteLine("NISN: " + student.NISN);
            Console.WriteLine("First Name: " + student.FirstName);
            Console.WriteLine("Last Name: " + student.LastName);
            Console.WriteLine("Email: " + student.Email);
            Console.WriteLine("Phone: " + student.Phone);
            Console.WriteLine("Status: " + student.Status);
            Console.WriteLine("Classroom Id: " + student.ClassroomId);
            Console.WriteLine("===================================");
        }
    }

    public void GetById(Student student)
    {
        Console.WriteLine("===================================");
        Console.WriteLine("Data Student");
        Console.WriteLine("===================================");
        Console.WriteLine("Id: " + student.Id);
        Console.WriteLine("NISN: " + student.NISN);
        Console.WriteLine("First Name: " + student.FirstName);
        Console.WriteLine("Last Name: " + student.LastName);
        Console.WriteLine("Email: " + student.Email);
        Console.WriteLine("Phone: " + student.Phone);
        Console.WriteLine("Status: " + student.Status);
        Console.WriteLine("Classroom Id: " + student.ClassroomId);
    }
}
