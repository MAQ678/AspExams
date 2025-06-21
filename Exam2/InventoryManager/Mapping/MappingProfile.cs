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
            CreateMap<ProductEntity, ProductInfoViewModel>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => QuantityToStatusConverter.Convert(src.Quantity)));
            CreateMap<ProductCreateViewModel, ProductEntity>();
            CreateMap<ProductEntity, ProductEditViewModel>();
            CreateMap<ProductEditViewModel, ProductEntity>();
        }
    }
}
