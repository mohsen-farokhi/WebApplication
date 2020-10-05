using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Domain.Abstracts.DomainServices;
using WebApplication.Domain.Abstracts.Repositories;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Entities.Dtos;

namespace WebApplication.Domain.DomainServices
{
    public class CultureService : ICultureService
    {
        private readonly ICultureRepository _cultureRepository;
        public CultureService(ICultureRepository cultureRepository)
        {
            _cultureRepository = cultureRepository;
        }

        public async Task<int> InsertAsync(CultureDto dto, int userId)
        {
            var culture = new Culture
            {
                DisplayName = dto.DisplayName
            };
            culture.SetIsActive(dto.IsActive, userId);

            var id = await _cultureRepository.InsertAsync(culture);

            return id;
        }

        public async Task<IEnumerable<CultureDto>> GetAllAsync()
        {
            var cultures =
                (await _cultureRepository.GetAsync())
                .Select(c => new CultureDto
                {
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
            var culture = await _cultureRepository.FindAsync(id);
            culture.SetIsDeleted(true, userId);
            await _cultureRepository.UpdateAsync(culture);
        }

        public async Task UpdateAsync(CultureDto dto, int userId)
        {
            var culture = await _cultureRepository.FindAsync(dto.Id);
            culture.DisplayName = dto.DisplayName;
            culture.SetUpdateDateTime(userId);
            culture.SetIsActive(dto.IsActive, userId);
            await _cultureRepository.UpdateAsync(culture);
        }
    }
}
