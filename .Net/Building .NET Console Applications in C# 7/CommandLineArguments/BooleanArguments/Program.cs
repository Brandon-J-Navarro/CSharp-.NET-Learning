namespace BooleanArguments;

class Program
{
    static void Main(string[] args)
    {
        var options = new MyOptions();

        CommandLine.Parser.Default.ParseArguments(args, options);

        if (options.IsVerbose)
        {
            Console.WriteLine("Running in Verbose Mode");
        }
        else
        {
            Console.WriteLine("Running in Short Mode");
        }
        Console.ReadLine();
    }
}