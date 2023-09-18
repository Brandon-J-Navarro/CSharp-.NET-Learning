namespace QuotationMarksAndBackslashes;

class program
{
    static void Main(string[] args)
    {
        var fullCommandLineString = Environment.CommandLine;

        Console.WriteLine();
        Console.WriteLine("args:");
        foreach (var arg in args)
        {
            Console.WriteLine(arg);
        }

        //>ReadingCommandLineArguments.exe "brandon jeffery" navarro

        //args:
        //brandon jeffery
        //navarro

        //>ReadingCommandLineArguments.exe \"brandon jeffery\" navarro

        //args:
        //"brandon
        //jeffery"
        //navarro

        //>ReadingCommandLineArguments.exe "\"brandon jeffery\"" navarro

        //args:
        //"brandon jeffery"
        //navarro
    }
}