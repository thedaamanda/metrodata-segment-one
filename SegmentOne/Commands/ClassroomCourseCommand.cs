using SegmentOne.Contexts;
using SegmentOne.Controllers;
using SegmentOne.Repositories;
using SegmentOne.Views;
using SegmentOne.Models;

namespace SegmentOne.Commands;

public class ClassroomCourseCommand
{
    public void Run()
    {
        ClassroomCourseController classroomCourseController = new ClassroomCourseController(new ClassroomCourseRepository(new MyContext()), new VClassroomCourse());
        while (true)
        {
            Console.Clear();
            Console.WriteLine("======= Table Classroom Course ========");
            Console.WriteLine("1. Insert Course to Classroom");
            Console.WriteLine("2. Show Classroom Course");
            Console.WriteLine("3. Exit");
            Console.Write("Input: ");

            var operation = Convert.ToInt16(Console.ReadLine());

            switch (operation)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("======= Insert Data ========");
                    Console.Write("ID Classroom: ");
                    var id = Convert.ToInt16(Console.ReadLine());

                    Console.Write("Courses: ");
                    var courses = Console.ReadLine();

                    // pisahkan courses dengan koma
                    var course = courses.Split(',');

                    // masukkan ke dalam list
                    var listCourse = new List<ClassroomCourse>();

                    foreach (var item in course)
                    {
                        listCourse.Add(new ClassroomCourse
                        {
                            ClassroomId = id,
                            CourseId = Convert.ToInt16(item)
                        });
                    }

                    classroomCourseController.Insert(listCourse);

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    classroomCourseController.GetAll();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 3:
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
