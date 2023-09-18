using CommandLine;

namespace SpecifyingDefaultArgumentValues;

class MyOptions
{
    [Option('m', "message", DefaultValue = "Hello All")]
    public string Message { get; set; }

    [Option('t', "times", DefaultValue = 5)]
    public int Times { get; set; }
}