namespace CheckingNumlockAndCapslockStatus;

class program
{
    static void Main(string[] args)
    {
        do
        {
            while (!Console.KeyAvailable)
            {

            }

            var key = Console.ReadKey(true);

            if(Console.CapsLock && Console.NumberLock)
            {
                Console.WriteLine(key.KeyChar);
            }

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