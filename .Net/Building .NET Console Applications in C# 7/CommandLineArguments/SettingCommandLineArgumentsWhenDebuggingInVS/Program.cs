using System;

namespace SettingCommandLineArgumentsWhenDebuggingInVS;

class program
{
    static void Main(string[] args)
    {
        Console.WriteLine();
        Console.WriteLine("args:");
        foreach (var arg in args)
        {
            Console.WriteLine(arg);
        }

        Console.ReadLine();

        //Adding Command line arguments in the project properties debug section
        //args:
        //brandon
        //jeffery
        //navarro
    }
}