using SegmentOne.Contexts;
using SegmentOne.Controllers;
using SegmentOne.Repositories;
using SegmentOne.Views;
using SegmentOne.Models;

namespace SegmentOne;
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("======= FINAL EXAM SEGMENT 1 ========");
            Console.WriteLine("1. Manage Table Grade");
            Console.WriteLine("2. Manage Table Classroom");
            Console.WriteLine("3. Manage Table Teacher");
            Console.WriteLine("4. Manage Table Student");
            Console.WriteLine("5. Manage Table Course");
            Console.WriteLine("6. Manage Course - Classroom");
            Console.WriteLine("7. Exit");

            Console.Write("Input: ");
            var operation = Convert.ToInt16(Console.ReadLine());

            switch (operation)
            {
                case 1:
                    Grade();
                    break;
                case 2:
                    Classroom();
                    break;
                case 3:
                    Teacher();
                    break;
                case 4:
                    Student();
                    break;
                case 5:
                    Course();
                    break;
                case 6:
                    // COURSE - CLASSROOM
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again with another input.");
                    break;
            }
            Console.WriteLine();
        }
    }

    public static void Grade()
    {
        GradeController gradeController = new GradeController(new GradeRepository(new MyContext()), new VGrade());
        while (true)
        {
            Console.Clear();
            Console.WriteLine("======= Table Grade ========");
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
                    gradeController.GetAll();

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("======= Get By ID ========");
                    Console.Write("ID: ");
                    var id = Convert.ToInt16(Console.ReadLine());
                    gradeController.GetById(id);

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

                    gradeController.Insert(new Grade
                    {
                        Name = name,
                        Description = description
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

                    gradeController.Update(new Grade
                    {
                        Id = idUpdate,
                        Name = nameUpdate,
                        Description = descriptionUpdate
                    });

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("======= Delete Data ========");
                    Console.Write("ID yang ingin dihapus: ");
                    var idDelete = Convert.ToInt16(Console.ReadLine());
                    gradeController.Delete(idDelete);

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

    public static void Classroom()
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

    public static void Teacher()
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

    public static void Student()
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

    public static void Course()
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
