using SegmentOne.Models;

namespace SegmentOne.Views;

public class VClassroom
{
    public void GetAll(List<Classroom> classrooms)
    {
        Console.WriteLine("===================================");
        Console.WriteLine("Data Classroom");
        Console.WriteLine("===================================");
        foreach (var classroom in classrooms)
        {
            Console.WriteLine("Id: " + classroom.Id);
            Console.WriteLine("Code: " + classroom.Code);
            Console.WriteLine("Year: " + classroom.Year);
            Console.WriteLine("Grade ID: " + classroom.GradeId);
            Console.WriteLine("===================================");
        }
    }

    public void GetById(Classroom classroom)
    {
        Console.WriteLine("===================================");
        Console.WriteLine("Data Classroom");
        Console.WriteLine("===================================");

        Console.WriteLine("Id: " + classroom.Id);
        Console.WriteLine("Code: " + classroom.Code);
        Console.WriteLine("Year: " + classroom.Year);
        Console.WriteLine("Grade ID: " + classroom.GradeId);
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
