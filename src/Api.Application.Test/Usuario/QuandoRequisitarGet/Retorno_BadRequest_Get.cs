using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using src.Api.Application.Controllers;
using src.Api.Domain.Dtos.User;
using src.Api.Domain.Interfaces.Services.User;
using Xunit;

namespace src.Api.Application.Test.Usuario.QuandoRequisitarGet
{
    public class Retorno_BadRequest_Get
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possível Realizar o Updated.")]
        public async Task E_Possivel_Invocar_a_Controller_Get()
        {
            var serviceMok = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMok.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new UserDto
                {
                    Id = Guid.NewGuid(),
                    Name = nome,
                    Email = email,
                    CreateAt = DateTime.UtcNow
                }
            );

            _controller = new UsersController(serviceMok.Object);
            _controller.ModelState.AddModelError("Id", "Formato inválido!");

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
