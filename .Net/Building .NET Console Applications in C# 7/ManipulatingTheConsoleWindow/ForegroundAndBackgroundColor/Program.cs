namespace ForegroundAndBackgroundColor;

class Program
{
    static void Main(string[] args)
    {
        var originalForegroundColor = Console.ForegroundColor;
        var originalBackgroundColor = Console.BackgroundColor;
        
        //Console.BackgroundColor = ConsoleColor.Magenta;
        //Console.Clear();
        //Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine("Pluralsight");
        Console.WriteLine("Rocks");

        WriteWarning("This is a Warning...");
        WriteError("This is an Error!");

        Console.ReadLine();

        Console.ForegroundColor = originalForegroundColor;
        Console.BackgroundColor = originalBackgroundColor;
    }

    static void WriteWarning(string s)
    {
        var originalColor = Console.ForegroundColor;

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(s);

        Console.ForegroundColor = originalColor;
    }

    static void WriteError(string s)
    {
        var originalColor = Console.ForegroundColor;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(s);

        Console.ForegroundColor = originalColor;
    }
}