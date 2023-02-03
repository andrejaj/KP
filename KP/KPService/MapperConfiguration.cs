using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPService
{
    public class MapperConfiguration : IMapperConfiguration
    {
        public AutoMapper.MapperConfiguration GetMapperConfiguration()
        {
            var config = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<Model.Item, DBModel.Item>());
            return config;
        }
    }
}
