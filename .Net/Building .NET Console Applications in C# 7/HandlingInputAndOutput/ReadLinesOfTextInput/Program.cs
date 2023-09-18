namespace ReadLinesOfTextInput;

class ReadLinesOfTextInput
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Please enter your name.");

        //var name = Console.ReadLine();

        //Console.WriteLine("Hello " + name);

        //Console.ReadLine();

        string name;
        do
        {
            Console.WriteLine("Please enter your name.");

            name = Console.ReadLine();

            Console.WriteLine("Hello " + name);

        } while (name is not null);
    }
}