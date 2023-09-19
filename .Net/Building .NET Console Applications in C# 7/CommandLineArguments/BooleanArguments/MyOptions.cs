using CommandLine;

namespace BooleanArguments;

class MyOptions
{
    [Option('v', "verbose")]
    public bool IsVerbose { get; set; }
}