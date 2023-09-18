using CommandLine;

namespace ImplicitArgumentNames;

class MyOptions
{

    //Implicit
    [Option]
    public string Name { get; set; }

    //Explicit
    //[Option("name")]
    //public string Name { get; set; }
}
