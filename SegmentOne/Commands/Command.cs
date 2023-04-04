namespace SegmentOne.Commands;

public class Command
{
    public void Run()
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
                    new GradeCommand().Run();
                    break;
                case 2:
                    new ClassroomCommand().Run();
                    break;
                case 3:
                    new TeacherCommand().Run();
                    break;
                case 4:
                    new StudentCommand().Run();
                    break;
                case 5:
                    new CourseCommand().Run();
                    break;
                case 6:
                    new ClassroomCourseCommand().Run();
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
}
