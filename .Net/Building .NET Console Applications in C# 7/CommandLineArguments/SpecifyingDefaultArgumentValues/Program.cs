namespace SpecifyingDefaultArgumentValues;
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

        //Hello All
        //Hello All
        //Hello All
        //Hello All
        //Hello All
    }
}