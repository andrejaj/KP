using AutoMapper;
using KPService.Enum;
using KPService.Filter;
using KPService.Helper;
using System.Text.RegularExpressions;

namespace KPService
{
    public class MapperConfigurator : IMapperConfigurator
    {
        private readonly Regex regex = new Regex(@"(^!?https:\/\/schema.org\/)(.*$)"); //Item Condition
        private readonly ICompositeFilter _compositeFilter;

        public MapperConfigurator(ICompositeFilter compositeFilter)
        {
            _compositeFilter = compositeFilter ?? throw new ArgumentNullException(nameof(compositeFilter));
        }

        public Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Model.Item, DBModel.Seller>().ForMember(dest => dest.Name, act => act.MapFrom(src => src.ItemOffer.Seller.Name));
                cfg.CreateMap<Model.Item, DBModel.Item>()
                    .ForMember(dest => dest.Description, act => act.MapFrom(src => src.Description))
                    .ForMember(dest => dest.Title, act => act.MapFrom(src => src.Title))
                    .ForMember(dest => dest.AuthorId, act => act.MapFrom(src => _compositeFilter.FullNameFilterOn(src.Title).Id));
                cfg.CreateMap<Model.Item, DBModel.ItemImages>()
                    .ForMember(dest => dest.Images, act => act.MapFrom(src => src.Images));
                cfg.CreateMap<Model.Item, DBModel.ItemOffer>()
                    .ForMember(dest => dest.Sku, act => act.MapFrom(src => src.Sku))
                    .ForMember(dest => dest.Price, act => act.MapFrom(src => src.ItemOffer.Price.ToDouble()))
                    .ForMember(dest => dest.ValidUntil, act => act.MapFrom(src => src.ItemOffer.ValidUntil))
                    .ForMember(dest => dest.StatusId, act => act.MapFrom(src => (int)Status.Active))
                    .ForMember(dest => dest.ConditionId, act => act.MapFrom(src => (int)ConvertEnum<ItemCondition>.ToConvert(regex.Match(src.ItemOffer.Condition).Groups[2].Value)))
                    .ForMember(dest => dest.CurrencyId, act => act.MapFrom(src => (int)ConvertEnum<Currency>.ToConvert(src.ItemOffer.Currency)))
                    .ForMember(dest => dest.PriceTypeId, act => act.MapFrom(src => src.ItemOffer.Price.IsDouble() ? (int)PriceType.Cena : (int)ConvertEnum<PriceType>.ToConvert(src.ItemOffer.Price)))
                    .ForMember(dest => dest.Url, act => act.MapFrom(src => src.ItemOffer.Url));
            });
            return new Mapper(config);
        }
    }
}
