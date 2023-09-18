using System.Xml.Linq;
using System;

namespace OutputtingParsingErrorsToTheUser;

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

    //Comand Line Aurguments: -n brandon -a thirty
    //OutputtingParsingErrorsToTheUser 1.0.0
    //Copyright(C) 2023 OutputtingParsingErrorsToTheUser

    //ERROR(S):
    //  -a/--age option violates format.


    //  -n, --name Required. The name of the person

    //  -a, --age The person's age
}