using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using src.Api.Domain.Entities;
using Api.Domain.Dtos.User;

namespace src.Api.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserDto> Get(Guid id);
        Task<IEnumerable<UserEntity>> GetAll();
        Task<UserDtoCreateResult> Post(UserDto user);
        Task<UserDtoUpdateResult> Put(UserDto user);
        Task<bool> Delete(Guid id);
    }
}
