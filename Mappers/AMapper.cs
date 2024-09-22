using AutoMapper;

public class AMapper : ITypeMapper
{
    private IMapper mapper;

    public object Map(object data, Type sourceType, Type targetType)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap(sourceType, targetType);
        });

        mapper = config.CreateMapper();

        return mapper.Map(data, sourceType, targetType);

    }
}
