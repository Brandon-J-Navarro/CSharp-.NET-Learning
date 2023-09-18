namespace HandlingCtrlC;

class program
{
    static void Main(string[] args)
    {
        //Console.TreatControlCAsInput = true;

        //Console.CancelKeyPress += (object sender, ConsoleCancelEventArgs e) =>
        //{
        //    e.Cancel = true;
        //};

        Console.CancelKeyPress += (object sender, ConsoleCancelEventArgs e) =>
        {
            var isCtrlC = e.SpecialKey == ConsoleSpecialKey.ControlC;
            var isCtrlbreak = e.SpecialKey == ConsoleSpecialKey.ControlBreak;

            // Prevent Ctrl-C from terminating
            if (isCtrlC)
            {
                e.Cancel = true;
            }

            //e.Cancel defaults to false to Ctrl-Break will still cause terminination
        };

        while(true) { }
    }
}