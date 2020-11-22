using System.Linq;
using System.Threading.Tasks;
using WebApplication.Domain.Abstracts.DomainServices;
using WebApplication.Domain.Abstracts.UnitOfWork;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Entities.Dtos;
using WebApplication.Domain.Entities.Dtos.Data;

namespace WebApplication.Domain.DomainServices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DataResult<UserDto>> GetDataAsync
            (UserDataRequestDto userDataRequest)
        {
            var predicate = PredicateBuilder.True<User>();

            if (userDataRequest.IsActive.HasValue)
                predicate = predicate.And(c => c.IsActive == userDataRequest.IsActive.Value);

            if (!string.IsNullOrWhiteSpace(userDataRequest.FullName))
                predicate = predicate.And(c => c.FirstName.Contains(userDataRequest.FullName) ||
                                               c.LastName.Contains(userDataRequest.FullName));

            if (!string.IsNullOrWhiteSpace(userDataRequest.EmailAddress))
                predicate = predicate.And(c => c.EmailAddress.ToLower() == userDataRequest.EmailAddress.ToLower());

            if (!string.IsNullOrWhiteSpace(userDataRequest.NationalCode))
                predicate = predicate.And(c => c.NationalCode == userDataRequest.NationalCode);

            if (userDataRequest.UserType.HasValue)
                predicate = predicate.And(c => c.UserType == userDataRequest.UserType.Value);

            var data =
                await _unitOfWork.UserRepository.GetWithRequestAsync(userDataRequest, predicate);

            var result = new DataResult<UserDto>
            {
                Page = data.Page,
                PageSize = data.PageSize,
                TotalCount = data.TotalCount,
                Result = data.Result.Select(c => new UserDto
                {
                    Id = c.Id,
                    IsActive = c.IsActive,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    NationalCode = c.NationalCode,
                    //BirthDate = c.BirthDate,
                    CellPhoneNumber = c.CellPhoneNumber,
                    UserType = c.UserType,
                    EmailAddress = c.EmailAddress,
                }).ToList(),
            };

            return result;
        }

        public async Task<int> InsertAsync(UserDto userDto)
        {
            var user =
                await _unitOfWork.UserRepository.InsertAsync(new User
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    IsActive = userDto.IsActive,
                    BirthDate = userDto.BirthDate,
                    NationalCode = userDto.NationalCode,
                    Password = userDto.Password,
                    Username = userDto.Username,
                    EmailAddress = userDto.EmailAddress,
                    UserType = userDto.UserType,
                    CellPhoneNumber = userDto.CellPhoneNumber,
                });

            await _unitOfWork.SaveAsync();

            return user.Id;
        }

        public async Task DeleteAsync(int userId)
        {
            var user =
                await _unitOfWork.UserRepository.FindAsync(userId);

            user.IsDeleted = true;
            await _unitOfWork.UserRepository.UpdateAsync(user);
            await _unitOfWork.SaveAsync();
        }
    }
}
