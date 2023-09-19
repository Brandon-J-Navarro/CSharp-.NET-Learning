using System.Runtime.InteropServices;

namespace RequiredArgumentsAndStrictParameters;
class Program
{
    static void Main(string[] args)
    {
        var options = new MyOptions();

        //CommandLine.Parser.Default.ParseArguments(args, options);
        //5 Blank Lines

        //CommandLine.Parser.Default.ParseArgumentsStrict(args, options);
        //Errors and quits

        CommandLine.Parser.Default.ParseArgumentsStrict(args, options, OnFail);

        for (int i = 0; i < options.Times; i++)
        {
            Console.WriteLine(options.Message);
        }
        Console.ReadLine();
    }

    private static void OnFail()
    {
        Console.WriteLine("Sorry something went wrong...");

        Console.ReadLine();

        Environment.Exit(-1);
    }

    //RequiredArgumentsAndStrictParameters 1.0.0
    //Copyright(C) 2023 RequiredArgumentsAndStrictParameters

    //  -m, --message Required.

    //  -t, --times

    //Sorry something went wrong...
}