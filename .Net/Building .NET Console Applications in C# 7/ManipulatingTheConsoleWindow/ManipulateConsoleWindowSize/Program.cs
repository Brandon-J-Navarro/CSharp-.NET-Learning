namespace ManipulateConsoleWindowSize;

class Program
{
    static void Main(string[] args)
    {
        Console.ReadLine();

        Console.SetWindowSize(20, 20);
        Console.SetBufferSize(20, 20);

        Console.ReadLine();
    }
}