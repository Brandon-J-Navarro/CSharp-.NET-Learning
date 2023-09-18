using CommandLine;
using CommandLine.Text;

namespace ParsingErrorHelpScreensForUsers;

class MyOptions
{
    [Option('n', "name", Required = true, HelpText = "The name of the person")]
    public string Name { get; set; }

    [Option('a', "age", HelpText = "The person's age")]
    public int Age { get; set; }

    [HelpOption]
    public string GetUsage()
    {
        //var h = new HelpText
        //{
        //    Copyright = new CopyrightInfo("Plurasight", 2014),
        //    Heading = "Pluralsight Demo",
        //    AddDashesToOption = true,
        //};

        //h.AddOptions(this);

        //return h;

        return HelpText.AutoBuild(this);
    }
}
