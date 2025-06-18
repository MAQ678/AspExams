using AutoMapper;
using InventoryManager.Converters;
using InventoryManager.Models.Entities;
using InventoryManager.Models.ViewModels;

namespace InventoryManager.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductEntity, ProductListViewModel>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => QuantityToStatusConverter.Convert(src.Quantity)));
        }
    }
}
