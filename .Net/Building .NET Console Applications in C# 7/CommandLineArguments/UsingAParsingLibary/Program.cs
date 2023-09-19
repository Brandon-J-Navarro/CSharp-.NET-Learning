namespace UsingAParsingLibary;

class Program
{
    static void Main(string[] args)
    {
        var options = new MyOptions();

        CommandLine.Parser.Default.ParseArguments(args, options);

        for (int i = 0; i < options.Times; i++)
        {
            Console.WriteLine(options.Message);
        }
        Console.ReadLine();

        //Command Line Arguements: -m "hello world" -t 10 OR -m"hello world" -t10 
        // Or
        //Command Line Arguements: --message "hello world" --times 10
        //hello world
        //hello world
        //hello world
        //hello world
        //hello world
        //hello world
        //hello world
        //hello world
        //hello world
        //hello world
    }
}