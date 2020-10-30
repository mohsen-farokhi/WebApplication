using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Domain.Abstracts.DomainServices;
using WebApplication.Domain.Abstracts.UnitOfWork;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Entities.Dtos;

namespace WebApplication.Domain.DomainServices
{
    public class CultureService : ICultureService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CultureService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CultureDto> GetByIdAsync(int id)
        {
            var culture =
                await _unitOfWork.CultureRepository.FindAsync(id);

            var result = new CultureDto
            {
                Id = culture.Id,
                DisplayName = culture.DisplayName,
                IsActive = culture.IsActive,
                Lcid = culture.Lcid,
                Name = culture.Name,
                NativeName = culture.NativeName,
            };

            return result;
        }

        public async Task<int> InsertAsync(CultureDto dto)
        {
            var culture = new Culture
            {
                IsActive = dto.IsActive,
                Name = dto.Name,
                DisplayName = dto.DisplayName,
                Lcid = dto.Lcid,
                NativeName = dto.NativeName,
            };

            var entity = 
                await _unitOfWork.CultureRepository.InsertAsync(culture);

            await _unitOfWork.SaveAsync();

            return entity.Id;
        }

        public async Task<IList<CultureDto>> GetAllAsync()
        {
            var cultures =
                (await _unitOfWork.CultureRepository.GetAllAsync())
                .Select(c => new CultureDto
                {
                    Id = c.Id,
                    DisplayName = c.DisplayName,
                    Lcid = c.Lcid,
                    Name = c.Name,
                    NativeName = c.NativeName,
                    IsActive = c.IsActive,
                }).ToList();

            return cultures;
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.CultureRepository.DeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(CultureDto dto)
        {
            var culture = 
                await _unitOfWork.CultureRepository.FindAsync(dto.Id);

            culture.IsActive = dto.IsActive;
            culture.Name = dto.Name;
            culture.DisplayName = dto.DisplayName;
            culture.NativeName = dto.NativeName;
            culture.Lcid = dto.Lcid;

            await _unitOfWork.CultureRepository.UpdateAsync(culture);
            await _unitOfWork.SaveAsync();
        }
    }
}
