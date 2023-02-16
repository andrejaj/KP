using AutoMapper;

namespace KPService
{
    public interface IMapperConfigurator
    {
        //AutoMapper.MapperConfiguration GetMapperConfiguratio();
        Mapper GetMapper();
    }
}