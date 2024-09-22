public class BMapperFactory : IAbstractMapperFactory
{
    public ITypeMapper CreateMapper()
    {
        return new BMapper();
    }
}
