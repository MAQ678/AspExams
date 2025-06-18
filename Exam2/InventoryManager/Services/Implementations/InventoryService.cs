using AutoMapper;
using InventoryManager.Data.UnitOfWork;
using InventoryManager.Models;
using InventoryManager.Models.Entities;
using InventoryManager.Models.ViewModels;
using InventoryManager.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Services.Implementations
{
    public class InventoryService : IInventoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InventoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ProductListViewModel>> GetFilteredProductListAsync(FilterProductModel filter)
        {
            var query = _unitOfWork.ProductRepository.Query();

            if (filter.Category != null)
            {
                query = query.Where(p => p.Category == filter.Category);
            }

            if (!string.IsNullOrEmpty(filter.ProductName))
            {
                query = query.Where(p => p.Name.Contains(filter.ProductName));
            }

            var productEntities = await query.ToListAsync();
            var productViewModels = _mapper.Map<List<ProductListViewModel>>(productEntities);
            return productViewModels;
        }
        public async Task AddAsync(ProductCreateViewModel product)
        {
            var productEntity = _mapper.Map<ProductEntity>(product);
            _unitOfWork.ProductRepository.Add(productEntity); 
            await _unitOfWork.SaveAsync();
        }
    }
}
