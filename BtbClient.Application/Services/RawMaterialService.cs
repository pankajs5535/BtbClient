using AutoMapper;
using BtbClient.Application.DTOs.RawMaterialDtos;
using BtbClient.Application.Interfaces.IServices;
using BtbClient.Application.Interfaces.IUnitOfWork;
using BtbClient.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BtbClient.Application.Services
{
    public class RawMaterialService : IRawMaterialService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public RawMaterialService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateRawMaterialDto dto)
        {
            var rawMaterial = _mapper.Map<RawMaterial>(dto);

            await _unitOfWork.RawMaterials.AddAsync(rawMaterial);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var rawMaterial = await _unitOfWork.RawMaterials.GetByIdAsync(id);

            if (rawMaterial == null)
                throw new KeyNotFoundException($"Raw material with ID {id} not found.");

            _unitOfWork.RawMaterials.Delete(rawMaterial);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<RawMaterialDto>> GetActiveAsync()
        {
            var rawMaterials = await _unitOfWork.RawMaterials.GetActiveAsync();

            return _mapper.Map<IEnumerable<RawMaterialDto>>(rawMaterials);
        }

        public async Task<IEnumerable<RawMaterialDto>> GetAllAsync()
        {
            var rawMaterials = await _unitOfWork.RawMaterials.GetAllAsync();

            return _mapper.Map<IEnumerable<RawMaterialDto>>(rawMaterials);
        }

        public async Task<RawMaterialDto?> GetByCodeAsync(string code)
        {
            var rawMaterial = await _unitOfWork.RawMaterials.GetByCodeAsync(code);

            return _mapper.Map<RawMaterialDto?>(rawMaterial);
        }

        public async Task<IEnumerable<RawMaterialDto>> GetByDateRangeAsync(
            DateTime fromDate,
            DateTime toDate)
        {
            var rawMaterials =
                await _unitOfWork.RawMaterials.GetByDateRangeAsync(fromDate, toDate);

            return _mapper.Map<IEnumerable<RawMaterialDto>>(rawMaterials);
        }

        public async Task<RawMaterialDto?> GetByIdAsync(int id)
        {
            var rawMaterial = await _unitOfWork.RawMaterials.GetByIdAsync(id);

            return _mapper.Map<RawMaterialDto?>(rawMaterial);
        }

        public async Task<IEnumerable<RawMaterialDto>> GetBySupplierAsync(int supplierId)
        {
            var rawMaterials =
                await _unitOfWork.RawMaterials.GetBySupplierAsync(supplierId);

            return _mapper.Map<IEnumerable<RawMaterialDto>>(rawMaterials);
        }

        public async Task<IEnumerable<RawMaterialDto>> GetByTypeAsync(string type)
        {
            var rawMaterials =
                await _unitOfWork.RawMaterials.GetByTypeAsync(type);

            return _mapper.Map<IEnumerable<RawMaterialDto>>(rawMaterials);
        }

        public async Task<IEnumerable<RawMaterialDto>> GetControlledSubstancesAsync()
        {
            var rawMaterials =
                await _unitOfWork.RawMaterials.GetControlledSubstancesAsync();

            return _mapper.Map<IEnumerable<RawMaterialDto>>(rawMaterials);
        }

        public async Task<IEnumerable<RawMaterialDto>> GetInactiveAsync()
        {
            var rawMaterials =
                await _unitOfWork.RawMaterials.GetInactiveAsync();

            return _mapper.Map<IEnumerable<RawMaterialDto>>(rawMaterials);
        }

        public async Task<IEnumerable<RawMaterialDto>> GetLowStockAsync()
        {
            var rawMaterials =
                await _unitOfWork.RawMaterials.GetLowStockAsync();

            return _mapper.Map<IEnumerable<RawMaterialDto>>(rawMaterials);
        }

        public async Task<bool> IsMaterialCodeExistsAsync(string materialCode)
        {
            return await _unitOfWork.RawMaterials
                .IsMaterialCodeExistsAsync(materialCode);
        }

        public async Task<IEnumerable<RawMaterialDto>> SearchAsync(string keyword)
        {
            var rawMaterials =
                await _unitOfWork.RawMaterials.SearchAsync(keyword);

            return _mapper.Map<IEnumerable<RawMaterialDto>>(rawMaterials);
        }

        public async Task UpdateAsync(UpdateRawMaterialDto dto)
        {
            var rawMaterial =
                await _unitOfWork.RawMaterials.GetByIdAsync(dto.RawMaterialId);

            if (rawMaterial == null)
                throw new KeyNotFoundException(
                    $"Raw material with ID {dto.RawMaterialId} not found.");

            _mapper.Map(dto, rawMaterial);

            _unitOfWork.RawMaterials.Update(rawMaterial);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
