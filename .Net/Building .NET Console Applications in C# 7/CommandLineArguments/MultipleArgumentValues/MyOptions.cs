using CommandLine;

namespace MultipleArgumentValues;

class MyOptions
{
    [OptionArray('n', "names", DefaultValue = new string[] { })]
    public string[] Names { get; set; }
}
