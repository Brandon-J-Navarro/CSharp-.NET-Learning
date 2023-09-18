using System.Net.NetworkInformation;

namespace Piping;

// Open Piping.exe in Debug directory
//      >echo hello | piping
//      olleh

//      >time /t | piping
//      MP 13:21

//      >dir | piping | piping

class program
{
    static void Main(string[] args)
    {
        string s;

        s = Console.ReadLine();
        while (s is not null)
        {
            Console.WriteLine(Reverse(s));

            s = Console.ReadLine();
        }
    }

    private static string Reverse(string s)
    {
        var a = s.ToCharArray();
        Array.Reverse(a);
        return new string(a);
    }
}