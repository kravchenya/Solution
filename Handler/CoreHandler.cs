class CoreHandler : IHandler
{
    private ITypeMapper customHandler;
    private IParser parser;

    public CoreHandler(ITypeMapper typeHandler, IParser typeParser)
    {
        customHandler = typeHandler;
        parser = typeParser;
    }

    public void Map(object data, string sourceType, string targetType)
    {
        try
        {
            // Performs pre-processing initialization: parses strings to types for simplicity
            var inputType = parser.ParseInputType(sourceType);
            var outputType = parser.ParseOutputType(targetType);

            // Does mapping
            var temp = customHandler.Map(data, inputType, outputType);

            Console.WriteLine("");
            Console.WriteLine($"Mapping of {inputType} to {outputType} completed successfully");
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine($"Argument can not be null: {e.Message} ");
        }
        catch (ArgumentException)
        {
            Console.WriteLine($"The provided data ({nameof(data)}) is of unknown type {sourceType}");
        }
        catch (InvalidCastException e)
        {
            Console.WriteLine($"Invalid cast operation: {e.Message}");
        }
        catch (FormatException e)
        {
            Console.WriteLine($"Data format issue: {e.Message}");
        }
        catch (OverflowException e)
        {
            Console.WriteLine($"Overflow error: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
        }
    }
}
