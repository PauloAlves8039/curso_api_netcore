using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using src.Api.Application.Controllers;
using src.Api.Domain.Dtos.Municipio;
using src.Api.Domain.Interfaces.Services.Municipio;
using Xunit;

namespace src.Api.Application.Test.Municipio.QuandoRequisitarCreate
{
    public class Retorno_BadRequest
    {
        private MunicipiosController _controller;

        [Fact(DisplayName = "É possível Realizar o Created.")]
        public async Task E_Possivel_Invocar_a_Controller_Create()
        {
            var serviceMock = new Mock<IMunicipioService>();
            serviceMock.Setup(m => m.Post(It.IsAny<MunicipioDtoCreate>())).ReturnsAsync(
                new MunicipioDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Nome = "São Paulo",
                    CreateAt = DateTime.UtcNow
                }
            );

            _controller = new MunicipiosController(serviceMock.Object);
            _controller.ModelState.AddModelError("Nome", "É um Campo Obrigatório");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var municipioDtoCreate = new MunicipioDtoCreate
            {
                Nome = "São Paulo",
                CodIBGE = 1
            };

            var result = await _controller.Post(municipioDtoCreate);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
