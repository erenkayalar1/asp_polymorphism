using System;
using System.IO;

namespace PolymorphismDemo
{
    public interface IQuittable
    {
        void Quit();
    }

    public class Staff : IQuittable
    {
        public int StaffId { get; }
        public string FullName { get; }
        public DateTime StartedOn { get; }

        public Staff(int id, string name)
        {
            StaffId = id;
            FullName = name;
            StartedOn = DateTime.Now;
        }

        public void Quit()
        {
            var duration = DateTime.Now - StartedOn;
            string log = $"[{DateTime.Now:T}] Staff {FullName} (ID: {StaffId}) resigned after {duration.TotalSeconds:F1} seconds.\n";
            File.AppendAllText("staff_quit_log.txt", log);
            Console.WriteLine("Resignation logged.");
        }
    }

    class Program
    {
        static void Main()
        {
            IQuittable staff = new Staff(202, "Bob Miller");
            Console.WriteLine("Staff quitting in progress...\n");
            System.Threading.Thread.Sleep(1500);
            staff.Quit();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
