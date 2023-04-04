using SegmentOne.Contexts;
using SegmentOne.Controllers;
using SegmentOne.Repositories;
using SegmentOne.Views;
using SegmentOne.Models;

namespace SegmentOne.Commands;

public class ClassroomCommand
{
    public void Run()
    {
        ClassroomController classroomController = new ClassroomController(new ClassroomRepository(new MyContext()), new VClassroom());
        while (true)
        {
            Console.Clear();
            Console.WriteLine("======= Table Classroom ========");
            Console.WriteLine("1. Get All");
            Console.WriteLine("2. Get By ID");
            Console.WriteLine("3. Insert");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("6. Exit");
            Console.Write("Input: ");

            var operation = Convert.ToInt16(Console.ReadLine());

            switch (operation)
            {
                case 1:
                    Console.Clear();
                    classroomController.GetAll();

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("======= Get By ID ========");
                    Console.Write("ID: ");
                    var id = Convert.ToInt16(Console.ReadLine());
                    classroomController.GetById(id);

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("======= Insert Data ========");
                    Console.Write("Code: ");
                    var code = Console.ReadLine();

                    Console.Write("Year: ");
                    var year = Console.ReadLine();

                    Console.Write("Grade ID: ");
                    var gradeId = Convert.ToInt16(Console.ReadLine());

                    classroomController.Insert(new Classroom
                    {
                        Code = code,
                        Year = year,
                        GradeId = gradeId
                    });

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("======= Update Data ========");
                    Console.Write("ID: ");
                    var idUpdate = Convert.ToInt16(Console.ReadLine());

                    Console.Write("Code: ");
                    var codeUpdate = Console.ReadLine();

                    Console.Write("Year: ");
                    var yearUpdate = Console.ReadLine();

                    Console.Write("Grade ID: ");
                    var gradeIdUpdate = Convert.ToInt16(Console.ReadLine());

                    classroomController.Update(new Classroom
                    {
                        Id = idUpdate,
                        Code = codeUpdate,
                        Year = yearUpdate,
                        GradeId = gradeIdUpdate
                    });

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("======= Delete Data ========");
                    Console.Write("ID yang ingin dihapus: ");
                    var idDelete = Convert.ToInt16(Console.ReadLine());
                    classroomController.Delete(idDelete);

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again with another input.");
                    break;
            }
            Console.WriteLine();
        }
    }
}
