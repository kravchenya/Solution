public class ParserFactory
{
    public IParser CreateParser()
    {
        return new Parser();
    }
}