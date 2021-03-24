using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using src.Api.Application.Controllers;
using src.Api.Domain.Dtos.Uf;
using src.Api.Domain.Interfaces.Services.Uf;
using Xunit;

namespace src.Api.Application.Test.Uf.QuandoRequisitarGet
{
    public class Retorno_NotFound
    {
        private UfsController _controller;

        [Fact(DisplayName = "É possível Realizar o Get.")]
        public async Task E_Possivel_Invocar_a_Controller_Get()
        {
            var serviceMock = new Mock<IUfService>();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UfDto)null));

            _controller = new UfsController(serviceMock.Object);
            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is NotFoundResult);

        }
    }
}
