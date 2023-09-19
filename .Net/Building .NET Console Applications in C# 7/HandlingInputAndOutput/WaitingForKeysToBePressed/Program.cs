namespace WaitingForKeysToBePressed;

class program
{
    static void Main(string[] args)
    {
        do
        {
            while (!Console.KeyAvailable)
            {

            }
            // Prevents an echo of key pressed "aa" > "a"
            var key = Console.ReadKey(true);

            Console.WriteLine(key.KeyChar);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    Console.WriteLine("Up arrow was pressed");
                    break;
                case ConsoleKey.DownArrow:
                    Console.WriteLine("Down arrow was pressed");
                    break;
                case ConsoleKey.LeftArrow:
                    Console.WriteLine("Left arrow was pressed");
                    break;
                case ConsoleKey.RightArrow:
                    Console.WriteLine("Right arrow was pressed");
                    break;
            }
        } while (true);
    }
}