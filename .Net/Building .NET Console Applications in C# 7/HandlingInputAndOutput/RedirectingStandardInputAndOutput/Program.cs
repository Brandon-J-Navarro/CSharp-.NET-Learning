namespace RedirectingStandardInputAndOutput;

class program
{
    static void Main(string[] args)
    {
        var inputFileName = Path.Combine(Environment.CurrentDirectory, "Name.txt");

        var inputName = new StreamReader(inputFileName);

        Console.SetIn(inputName);

        string currentName = Console.ReadLine();
        while(currentName is not null)
        {
            Console.WriteLine("Read from file: " + currentName);

            currentName = Console.ReadLine();
        }

        Console.WriteLine("Press enter to continue");

        // Resets Console from reading file
        Console.SetIn(new StreamReader(Console.OpenStandardInput()));

        Console.ReadLine();
    }
}