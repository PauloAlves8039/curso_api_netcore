using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using src.Api.Application.Controllers;
using src.Api.Domain.Dtos.Cep;
using src.Api.Domain.Interfaces.Services.Cep;
using Xunit;

namespace src.Api.Application.Test.Cep.QuandoRequisitarUpdate
{
    public class Retorno_Ok
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possível Realizar o Updated.")]
        public async Task E_Possivel_Invocar_a_Controller_Create()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Put(It.IsAny<CepDtoUpdate>())).ReturnsAsync(
                value: new CepDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Logradouro = "Teste de Rua",
                    Cep = "10333444",
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new CepsController(serviceMock.Object);

            var cepDtoUpdate = new CepDtoUpdate
            {
                Logradouro = "Teste de Rua",
                Cep = "10333444"
            };

            var result = await _controller.Put(cepDtoUpdate);
            Assert.True(result is OkObjectResult);
        }
    }
}
