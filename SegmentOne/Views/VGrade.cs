using SegmentOne.Models;

namespace SegmentOne.Views;

public class VGrade : VBase
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
}
