using inputType = Types.InnerDataModel;
using outputType = Types.OuterDataModel;

public class Parser : IParser
{
    private Dictionary<string, Type> TypeCollection = [];

    public Parser()
    {
        InitTypeCollection();
    }

    public Type ParseOutputType(string type)
    {
        return InternalParse(type) ?? typeof(outputType.DefaultType);
    }

    public Type ParseInputType(string type)
    {
        return InternalParse(type) ?? typeof(inputType.DefaultType);
    }

    private Type? InternalParse(string type)
    {
        return TypeCollection.TryGetValue(type, out var value) ? value : null;
    }

    private void InitTypeCollection()
    {
        TypeCollection = new Dictionary<string, Type>
        {
            { "Model.Reservation", typeof(inputType.Reservation) },
            { "Model.Room", typeof(inputType.Room) },
            { "Google.Reservation", typeof(outputType.Reservation) },
            { "Google.Room", typeof(outputType.Room) }
        };
    }
}