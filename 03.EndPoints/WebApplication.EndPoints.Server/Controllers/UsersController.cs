using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.User;
using WebApplication.Domain.Abstracts.DomainServices;
using WebApplication.Domain.Entities.Dtos;
using WebApplication.Domain.Entities.Enums;

namespace WebApplication.EndPoints.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost]
        [Route("GetData")]
        public async Task<ActionResult<ViewPagingDataResult<UserDataViewModel>>> GetData
            (UserDataRequestDto userDataRequest)
        {
            var data =
                await _userService.GetDataAsync(userDataRequest);

            var result = new ViewPagingDataResult<UserDataViewModel>
            {
                Page = data.Page,
                PageSize = data.PageSize,
                TotalCount = data.TotalCount,
                Result = data.Result.Select(c => new UserDataViewModel
                {
                    Id = c.Id,
                    IsActive = c.IsActive,
                    BirthDate = c.BirthDate,
                    EmailAddress = c.EmailAddress,
                    FullName = c.FullName,
                    NationalCode = c.NationalCode,
                    CellPhoneNumber = c.CellPhoneNumber,
                    UserType = (ViewModels.Enums.UserType)c.UserType,
                }).ToList(),
            };

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var operationId =
                    await _userService.InsertAsync(new UserDto
                    {
                        BirthDate = viewModel.BirthDate,
                        CellPhoneNumber = viewModel.CellPhoneNumber,
                        EmailAddress = viewModel.EmailAddress,
                        FirstName = viewModel.FirstName,
                        IsActive = viewModel.IsActive,
                        LastName = viewModel.LastName,
                        NationalCode = viewModel.NationalCode,
                        Password = viewModel.Password,
                        Username = viewModel.Username,
                        UserType = (UserType)viewModel.UserType,
                    });

                return operationId;
            }

            throw new ArgumentException();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int userId)
        {
            await _userService.DeleteAsync(userId);
            return Ok();
        }
    }
}
