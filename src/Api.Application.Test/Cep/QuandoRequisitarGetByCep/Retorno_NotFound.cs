using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using src.Api.Application.Controllers;
using src.Api.Domain.Dtos.Cep;
using src.Api.Domain.Interfaces.Services.Cep;
using Xunit;

namespace src.Api.Application.Test.Cep.QuandoRequisitarGetByCep
{
    public class Retorno_NotFound
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possível Realizar o Get.")]
        public async Task E_Possivel_Invocar_a_Controller_Get()
        {
            var serviceMock = new Mock<ICepService>();

            serviceMock.Setup(m => m.Get(It.IsAny<string>())).Returns(Task.FromResult((CepDto)null));

            _controller = new CepsController(serviceMock.Object);
            var result = await _controller.Get("13480000");
            Assert.True(result is NotFoundResult);

        }
    }
}
