using SegmentOne.Contexts;
using SegmentOne.Controllers;
using SegmentOne.Repositories;
using SegmentOne.Views;
using SegmentOne.Models;

namespace SegmentOne.Commands;

public class TeacherCommand
{
    public void Run()
    {
        TeacherController teacherController = new TeacherController(new TeacherRepository(new MyContext()), new VTeacher());
        while (true)
        {
            Console.Clear();
            Console.WriteLine("======= Table Teacher ========");
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
                    teacherController.GetAll();

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("======= Get By ID ========");
                    Console.Write("ID: ");
                    var id = Convert.ToInt16(Console.ReadLine());
                    teacherController.GetById(id);

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("======= Insert Data ========");
                    Console.Write("NIP: ");
                    var nip = Console.ReadLine();

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

                    teacherController.Insert(new Teacher
                    {
                        NIP = nip,
                        FirstName = firstName,
                        LastName = lastName,
                        Email = email,
                        Phone = phone,
                        Status = bool.Parse(status)
                    });

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("======= Update Data ========");
                    Console.Write("ID: ");
                    var idUpdate = Convert.ToInt16(Console.ReadLine());

                    Console.Write("NIP: ");
                    var nipUpdate = Console.ReadLine();

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

                    teacherController.Update(new Teacher
                    {
                        Id = idUpdate,
                        NIP = nipUpdate,
                        FirstName = firstNameUpdate,
                        LastName = lastNameUpdate,
                        Email = emailUpdate,
                        Phone = phoneUpdate,
                        Status = bool.Parse(statusUpdate)
                    });

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("======= Delete Data ========");
                    Console.Write("ID yang ingin dihapus: ");
                    var idDelete = Convert.ToInt16(Console.ReadLine());
                    teacherController.Delete(idDelete);

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
