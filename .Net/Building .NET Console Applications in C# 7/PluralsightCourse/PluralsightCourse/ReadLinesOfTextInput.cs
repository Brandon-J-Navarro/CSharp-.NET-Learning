namespace ReadLinesOfTextInput;

class ReadLinesOfTextInput
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter your name.");
        
        var name = Console.ReadLine();

        Console.WriteLine("Hello "+ name);

        Console.ReadLine();
    }
}