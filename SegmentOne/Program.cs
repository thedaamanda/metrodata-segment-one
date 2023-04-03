using SegmentOne.Contexts;

namespace SegmentOne
{
    class Program
    {
        // membuat objek MyContext
        private static MyContext connection = new MyContext("localhost", "db_hr_dts", "sa", "Passw@rd");

        static void Main(string[] args)
        {

        }
    }
}
