using AutoMapper;

namespace KPService
{
    public interface IMapperConfiguration
    {
        AutoMapper.MapperConfiguration GetMapperConfiguration();
    }
}