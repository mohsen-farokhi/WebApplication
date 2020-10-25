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

        public async Task<CultureDto> GetById(int id)
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

        public async Task<int> InsertAsync(CultureDto dto, int userId)
        {
            var culture = new Culture
            {
                DisplayName = dto.DisplayName
            };

            culture.SetIsActive(dto.IsActive, userId);
            var entity = _unitOfWork.CultureRepository.Insert(culture);
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

        public async Task DeleteAsync(int id, int userId)
        {
            var culture = await _unitOfWork.CultureRepository.FindAsync(id);
            culture.SetIsDeleted(true, userId);
            _unitOfWork.CultureRepository.Update(culture);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(CultureDto dto, int userId)
        {
            var culture = await _unitOfWork.CultureRepository.FindAsync(dto.Id);
            culture.DisplayName = dto.DisplayName;
            culture.SetUpdateDateTime(userId);
            culture.SetIsActive(dto.IsActive, userId);
            _unitOfWork.CultureRepository.Update(culture);
            await _unitOfWork.SaveAsync();
        }
    }
}
