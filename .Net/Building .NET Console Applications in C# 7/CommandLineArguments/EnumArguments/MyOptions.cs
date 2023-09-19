using CommandLine;

namespace EnumArguments;

class MyOptions
{
    [Option('o')]
    public SortOrder Order { get; set; }
}
