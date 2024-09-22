public class AMapperFactory : IAbstractMapperFactory
{
    public ITypeMapper CreateMapper()
    {
        return new AMapper();
    }
}