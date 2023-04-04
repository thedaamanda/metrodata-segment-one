using SegmentOne.Contexts;
using SegmentOne.Controllers;
using SegmentOne.Repositories;
using SegmentOne.Views;
using SegmentOne.Models;

namespace SegmentOne.Commands;

public class StudentCommand
{
    public void Run()
    {
        StudentController studentController = new StudentController(new StudentRepository(new MyContext()), new VStudent());
        while (true)
        {
            Console.Clear();
            Console.WriteLine("======= Table Student ========");
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
                    studentController.GetAll();

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("======= Get By ID ========");
                    Console.Write("ID: ");
                    var id = Convert.ToInt16(Console.ReadLine());
                    studentController.GetById(id);

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("======= Insert Data ========");
                    Console.Write("NISN: ");
                    var nisn = Console.ReadLine();

                    Console.Write("First Name: ");
                    var firstName = Console.ReadLine();

                    Console.Write("Last Name: ");
                    var lastName = Console.ReadLine();

                    Console.Write("Email: ");
                    var email = Console.ReadLine();

                    Console.Write("Phone: ");
                    var phone = Console.ReadLine();

                    Console.Write("Status: ");
                    var status = Console.ReadLine();

                    Console.Write("Classroom ID: ");
                    var classroomId = Convert.ToInt16(Console.ReadLine());

                    studentController.Insert(new Student
                    {
                        NISN = nisn,
                        FirstName = firstName,
                        LastName = lastName,
                        Email = email,
                        Phone = phone,
                        Status = bool.Parse(status),
                        ClassroomId = classroomId
                    });

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("======= Update Data ========");
                    Console.Write("ID: ");
                    var idUpdate = Convert.ToInt16(Console.ReadLine());

                    Console.Write("NISN: ");
                    var nisnUpdate = Console.ReadLine();

                    Console.Write("First Name: ");
                    var firstNameUpdate = Console.ReadLine();

                    Console.Write("Last Name: ");
                    var lastNameUpdate = Console.ReadLine();

                    Console.Write("Email: ");
                    var emailUpdate = Console.ReadLine();

                    Console.Write("Phone: ");
                    var phoneUpdate = Console.ReadLine();

                    Console.Write("Status: ");
                    var statusUpdate = Console.ReadLine();

                    Console.Write("Classroom ID: ");
                    var classroomIdUpdate = Convert.ToInt16(Console.ReadLine());

                    studentController.Update(new Student
                    {
                        Id = idUpdate,
                        NISN = nisnUpdate,
                        FirstName = firstNameUpdate,
                        LastName = lastNameUpdate,
                        Email = emailUpdate,
                        Phone = phoneUpdate,
                        Status = bool.Parse(statusUpdate),
                        ClassroomId = classroomIdUpdate
                    });

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("======= Delete Data ========");
                    Console.Write("ID yang ingin dihapus: ");
                    var idDelete = Convert.ToInt16(Console.ReadLine());
                    studentController.Delete(idDelete);

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
