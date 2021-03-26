using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using src.Api.Application.Controllers;
using src.Api.Domain.Dtos.Municipio;
using src.Api.Domain.Interfaces.Services.Municipio;
using Xunit;

namespace src.Api.Application.Test.Municipio.QuandoRequisitarGetCompleteByIBGE
{
    public class Retorno_OK
    {
        private MunicipiosController _controller;

        [Fact(DisplayName = "É possível Realizar o Get.")]
        public async Task E_Possivel_Invocar_a_Controller_Get()
        {
            var serviceMock = new Mock<IMunicipioService>();

            serviceMock.Setup(m => m.GetCompleteByIBGE(It.IsAny<int>())).ReturnsAsync(
                 new MunicipioDtoCompleto
                 {
                     Id = Guid.NewGuid(),
                     Nome = "São Paulo",
                 }
            );

            _controller = new MunicipiosController(serviceMock.Object);

            var result = await _controller.GetCompleteByIBGE(1);
            Assert.True(result is OkObjectResult);
        }
    }
}
