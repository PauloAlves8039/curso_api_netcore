using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using src.Api.Application.Controllers;
using src.Api.Domain.Interfaces.Services.User;
using Xunit;

namespace src.Api.Application.Test.Usuario.QuandoRequisitarDelete
{
    public class Retorno_BadRequest_Deleted
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possível Realizar o Deleted.")]
        public async Task E_Possivel_Invocar_a_Controller_Deleted()
        {
            var serviceMok = new Mock<IUserService>();

            serviceMok.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);

            _controller = new UsersController(serviceMok.Object);
            _controller.ModelState.AddModelError("Id", "Formato inválido!");

            var result = await _controller.Delete(default(Guid));
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }

    }
}
