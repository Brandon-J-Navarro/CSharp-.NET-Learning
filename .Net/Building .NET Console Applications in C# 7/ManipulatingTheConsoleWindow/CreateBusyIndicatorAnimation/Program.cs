namespace CreateBusyIndicatorAnimation;

class Program
{
    static void Main(string[] args)
    {
        var busy = new ConsoleBusyIndicator();

        var files = Enumerable.Range(1, 100).Select(n => "File" + n + ".txt");

        Console.CursorVisible = false;

        foreach (var file in files)
        {
            Thread.Sleep(100); //Simulate some work
            busy.UpdateProgress();
        }

        Console.CursorVisible = true;
    }
}