using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using src.Api.Domain.Entities;
using src.Api.Domain.Dtos.User;

namespace src.Api.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserDto> Get(Guid id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDtoCreateResult> Post(UserDtoCreate user);
        Task<UserDtoUpdateResult> Put(UserDtoUpdate user);
        Task<bool> Delete(Guid id);
    }
}
