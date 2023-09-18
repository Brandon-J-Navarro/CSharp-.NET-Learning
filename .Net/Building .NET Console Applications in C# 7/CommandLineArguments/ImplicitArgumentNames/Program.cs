namespace ImplicitArgumentNames;

class Program 
{
    static void Main(string[] args)
    {
        var options = new MyOptions();

        CommandLine.Parser.Default.ParseArgumentsStrict(args, options);
    }

    //--name brandon

    //-n brandon (does not match)
}