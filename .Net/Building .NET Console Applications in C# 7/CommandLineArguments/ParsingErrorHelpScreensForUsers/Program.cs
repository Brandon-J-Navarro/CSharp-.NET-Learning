namespace ParsingErrorHelpScreensForUsers;

class Program
{
    static void Main(string[] args)
    {
        var options = new MyOptions();

        CommandLine.Parser.Default.ParseArgumentsStrict(args, options, OnFail);
    }

    private static void OnFail()
    {
        Console.ReadLine();

        Environment.Exit(-1);
    }

    //-n brandon -a thirty
    //ParsingErrorHelpScreensForUsers 1.0.0
    //Copyright(C) 2023 ParsingErrorHelpScreensForUsers

    //  -n, --name Required.The name of the person

    //  -a, --age The person's age
}