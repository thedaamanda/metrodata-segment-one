using SegmentOne.Models;

namespace SegmentOne.Views;

public class VTeacher
{
    public void GetAll(List<Teacher> teachers)
    {
        Console.WriteLine("===================================");
        Console.WriteLine("Data Teacher");
        Console.WriteLine("===================================");
        foreach (var teacher in teachers)
        {
            Console.WriteLine("Id: " + teacher.Id);
            Console.WriteLine("NIP: " + teacher.NIP);
            Console.WriteLine("First Name: " + teacher.FirstName);
            Console.WriteLine("Last Name: " + teacher.LastName);
            Console.WriteLine("Email: " + teacher.Email);
            Console.WriteLine("Phone: " + teacher.Phone);
            Console.WriteLine("Status: " + teacher.Status);
            Console.WriteLine("===================================");
        }
    }

    public void GetById(Teacher teacher)
    {
        Console.WriteLine("===================================");
        Console.WriteLine("Data Teacher");
        Console.WriteLine("===================================");
        Console.WriteLine("Id: " + teacher.Id);
        Console.WriteLine("NIP: " + teacher.NIP);
        Console.WriteLine("First Name: " + teacher.FirstName);
        Console.WriteLine("Last Name: " + teacher.LastName);
        Console.WriteLine("Email: " + teacher.Email);
        Console.WriteLine("Phone: " + teacher.Phone);
        Console.WriteLine("Status: " + teacher.Status);
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
