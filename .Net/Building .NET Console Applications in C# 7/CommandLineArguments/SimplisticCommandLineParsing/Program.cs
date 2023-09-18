namespace SimplisticCommandLineParsing;

class program
{
    static void Main(string[] args)
    {
        var message = args[0];
        var times = Convert.ToInt32(args[1]);

        for (int i = 0; i< times; i++)
        {
            Console.WriteLine(message);
        }
        Console.ReadLine();

        //Command Line Arguements: "hello world" 10
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