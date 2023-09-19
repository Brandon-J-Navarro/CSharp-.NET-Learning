namespace EnumArguments;

class Program
{
    static void Main(string[] args)
    {
        var options = new MyOptions();

        CommandLine.Parser.Default.ParseArguments(args, options);

        Console.WriteLine(options.Order);

        // -o descending


        Console.ReadLine();
    }
}