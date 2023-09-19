using System.Reflection;

namespace ChangeTheConsoleWindowTitle;

class Program
{
    static void Main(string[] args)
    {
        //Console.Title = "Hello World";
        //Console.Title = Assembly.GetExecutingAssembly().GetName().FullName;

        for(var percentComplete = 0; percentComplete <= 100; percentComplete++)
        {
            var title = string.Format("{0}% Complete", percentComplete);

            Console.Title = title;

            //Simulate some work being done
            Thread.Sleep(100);
        }

        Console.ReadLine();
    }
}