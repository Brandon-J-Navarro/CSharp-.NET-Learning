using System;

namespace ReadingCommandLineArguments;

class program
{
    static void Main(string[] args)
    {
        var fullCommandLineString = Environment.CommandLine;

        //Console.WriteLine("Full command line string:");
        //Console.WriteLine(fullCommandLineString);

        //>ReadingCommandLineArguments.exe brandon jeffery navarro
        //Full command line string:
        //"C:\...\ReadingCommandLineArguments.dll" brandon jeffery navarro


        Console.WriteLine();
        Console.WriteLine("args:");
        foreach (var arg in args)
        {
            Console.WriteLine(arg);
        }

        //>ReadingCommandLineArguments.exe brandon jeffery navarro

        //args:
        //brandon
        //jeffery
        //navarro
    }
}