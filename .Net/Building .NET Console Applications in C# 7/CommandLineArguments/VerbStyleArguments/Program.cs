namespace VerbStyleArguments;

class Program
{
    static void Main(string[] args)
    {
        var options = new MyOptions();

        CommandLine.Parser.Default.ParseArguments(args, options,OnVerbCommand);
    }

    private static void OnVerbCommand(string verbName, object verbSubOptions)
    {
        //switch (verbName)
        //{
        //    case "mix":
        //        var mixSubOptions = (MixVerbSubOptions)verbSubOptions;
        //        break;

        //    case "cook":
        //        var cookSubOptions = (CookVerbSubOptions)verbSubOptions;
        //        break;
        //}

        if ( verbSubOptions is MixVerbSubOptions)
        {

        }
        //mix --mins 20 --speed 100

        if (verbSubOptions is CookVerbSubOptions)
        {

        }
        //cook --mins 60 --temp 200
    }
}