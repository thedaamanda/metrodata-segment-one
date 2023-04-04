using SegmentOne.Models;

namespace SegmentOne.Views;

public class VGrade
{
    public void GetAll(List<Grade> grades)
    {
        Console.WriteLine("===================================");
        Console.WriteLine("Data Grade");
        Console.WriteLine("===================================");
        foreach (var grade in grades)
        {
            Console.WriteLine("Id: " + grade.Id);
            Console.WriteLine("Name: " + grade.Name);
            Console.WriteLine("Description: " + grade.Description);
            Console.WriteLine("===================================");
        }
    }

    public void GetById(Grade grade)
    {
        Console.WriteLine("===================================");
        Console.WriteLine("Data Grade");
        Console.WriteLine("===================================");

        Console.WriteLine("Id: " + grade.Id);
        Console.WriteLine("Name: " + grade.Name);
        Console.WriteLine("Description: " + grade.Description);
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
