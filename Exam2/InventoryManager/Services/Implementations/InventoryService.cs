﻿using AutoMapper;
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
        public async Task<List<ProductInfoViewModel>> GetFilteredProductListAsync(FilterProductModel filter)
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
            var productViewModels = _mapper.Map<List<ProductInfoViewModel>>(productEntities);
            return productViewModels;
        }
        public async Task AddAsync(ProductCreateViewModel product)
        {
            var productEntity = _mapper.Map<ProductEntity>(product);
            _unitOfWork.ProductRepository.Add(productEntity); 
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> UpdateAsync(ProductEditViewModel product)
        {
            var productEntity = _mapper.Map<ProductEntity>(product);
            if (productEntity == null)
            {
                //Invalid entity
                return false;
            }
            _unitOfWork.ProductRepository.Update(productEntity);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<ProductEditViewModel?> GetProductEditViewModelByIdAsync(int id)
        {
            var productEntity = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            var productEditViewModel = _mapper.Map<ProductEditViewModel>(productEntity);
            return productEditViewModel;
        }

        public async Task<ProductInfoViewModel?> GetProductInfoViewModelByIdAsync(int id)
        {
            var productEntity = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            var productInfoViewModel = _mapper.Map<ProductInfoViewModel>(productEntity);
            return productInfoViewModel;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var productEntity = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if(productEntity !=  null)
            {
                _unitOfWork.ProductRepository.Delete(productEntity);
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
