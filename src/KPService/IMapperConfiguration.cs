using AutoMapper;

namespace KPService
{
    public interface IMapperConfigurator
    {
        Mapper GetMapper();
    }
}