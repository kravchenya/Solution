

Console.WriteLine("Enter handler type to be executed: ");
Console.WriteLine("1 for AMapper");
Console.WriteLine("2 for BMapper");
Console.WriteLine("");
var handlerType = Console.ReadLine();
Console.WriteLine("You entered: " + handlerType);


ITypeMapper mapper = null;
switch (handlerType)
{
    case "1":
        mapper = new AMapperFactory().CreateMapper();
        break;
    case "2":
        mapper = new BMapperFactory().CreateMapper();
        break;
    default:
        Console.WriteLine("As you entered neither 1 nor 2, therefore 2 BMapper will be used initialized");
        mapper = new BMapperFactory().CreateMapper();
        break;
}

var parser = new ParserFactory().CreateParser();

Console.WriteLine("");
string sourceType = initializeType("Enter Source type: ");
Console.WriteLine("");
string targetType = initializeType("Enter Target type: ");

while (sourceType == targetType)
{
    Console.WriteLine("");
    Console.WriteLine("You entered for the Source and the Target types with the Same Values, please try again");
    Console.WriteLine("");
    sourceType = initializeType("Enter Source type: ");
    Console.WriteLine("");
}

var dataObject = createDataObject(sourceType);


var coreHandler = new CoreHandler(mapper, parser);
coreHandler.Map(dataObject, sourceType, targetType);


static string initializeType(string invitation)
{
    Console.WriteLine(invitation);
    Console.WriteLine("Possible correct values are");
    Console.WriteLine("1 for Model.Reservation");
    Console.WriteLine("2 for Model.Room");
    Console.WriteLine("3 for Google.Reservation");
    Console.WriteLine("4 for Google.Room");
    Console.WriteLine("5 for default value");
    Console.WriteLine("In case of any other values, the default value will be used");
    Console.WriteLine("");
    var enteredType = Console.ReadLine();
    Console.WriteLine("You entered: " + enteredType);

    switch (enteredType)
    {
        case "1":
            return "Model.Reservation";
        case "2":
            return "Model.Room";
        case "3":
            return "Google.Reservation";
        case "4":
            return "Google.Room";
        case "5":
            return "DefaultType";
        default:
            return "DefaultType";
    }
}

static object createDataObject(string sourceType)
{
    switch (sourceType)
    {
        case "Model.Reservation":
            return new Types.InnerDataModel.Reservation();
        case "Model.Room":
            return new Types.InnerDataModel.Room();
        case "Google.Reservation":
            return new Types.OuterDataModel.Reservation();
        case "Google.Room":
            return new Types.OuterDataModel.Room();
        case "Default":
            return new Types.InnerDataModel.DefaultType();
        default:
            return new Types.OuterDataModel.DefaultType();
    }
}