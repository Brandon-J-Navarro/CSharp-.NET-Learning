using System;
using System.Globalization;

namespace MultipleArgumentValues;

class Program
{
    static void Main(string[] args)
    {
        var options = new MyOptions();

        CommandLine.Parser.Default.ParseArguments(args, options);

        foreach(var n in options.Names)
        {
            Console.WriteLine(n);
        }

        //-n brandon jeffery navarro
        //brandon
        //jeffery
        //navarro

        Console.ReadLine();
    }
}