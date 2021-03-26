using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using src.Api.Application.Controllers;
using src.Api.Domain.Dtos.Municipio;
using src.Api.Domain.Interfaces.Services.Municipio;
using Xunit;

namespace src.Api.Application.Test.Municipio.QuandoRequisitarGetCompleteById
{
    public class Retorno_NotFound
    {
        private MunicipiosController _controller;

        [Fact(DisplayName = "É possível Realizar o Get.")]
        public async Task E_Possivel_Invocar_a_Controller_Get()
        {
            var serviceMock = new Mock<IMunicipioService>();

            serviceMock.Setup(m => m.GetCompleteById(It.IsAny<Guid>())).Returns(Task.FromResult((MunicipioDtoCompleto)null));

            _controller = new MunicipiosController(serviceMock.Object);
            var result = await _controller.GetCompleteById(Guid.NewGuid());
            Assert.True(result is NotFoundResult);

        }
    }
}
