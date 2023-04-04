using SegmentOne.Contexts;
using SegmentOne.Controllers;
using SegmentOne.Repositories;
using SegmentOne.Views;
using SegmentOne.Models;

namespace SegmentOne.Commands;

public class CourseCommand
{
    public void Run()
    {
        CourseController courseController = new CourseController(new CourseRepository(new MyContext()), new VCourse());
        while (true)
        {
            Console.Clear();
            Console.WriteLine("======= Table Course ========");
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
                    courseController.GetAll();

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("======= Get By ID ========");
                    Console.Write("ID: ");
                    var id = Convert.ToInt16(Console.ReadLine());
                    courseController.GetById(id);

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("======= Insert Data ========");
                    Console.Write("Name: ");
                    var name = Console.ReadLine();

                    Console.Write("Description: ");
                    var description = Console.ReadLine();

                    Console.Write("Grade ID: ");
                    var gradeId = Convert.ToInt16(Console.ReadLine());

                    Console.Write("Teacher ID: ");
                    var teacherId = Convert.ToInt16(Console.ReadLine());

                    courseController.Insert(new Course
                    {
                        Name = name,
                        Description = description,
                        GradeId = gradeId,
                        TeacherId = teacherId
                    });

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("======= Update Data ========");
                    Console.Write("ID: ");
                    var idUpdate = Convert.ToInt16(Console.ReadLine());

                    Console.Write("Name: ");
                    var nameUpdate = Console.ReadLine();

                    Console.Write("Description: ");
                    var descriptionUpdate = Console.ReadLine();

                    Console.Write("Grade ID: ");
                    var gradeIdUpdate = Convert.ToInt16(Console.ReadLine());

                    Console.Write("Teacher ID: ");
                    var teacherIdUpdate = Convert.ToInt16(Console.ReadLine());

                    courseController.Update(new Course
                    {
                        Id = idUpdate,
                        Name = nameUpdate,
                        Description = descriptionUpdate,
                        GradeId = gradeIdUpdate,
                        TeacherId = teacherIdUpdate
                    });

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("======= Delete Data ========");
                    Console.Write("ID yang ingin dihapus: ");
                    var idDelete = Convert.ToInt16(Console.ReadLine());
                    courseController.Delete(idDelete);

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
