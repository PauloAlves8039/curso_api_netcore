using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Test;
using Microsoft.Extensions.DependencyInjection;
using src.Api.Data.Context;
using src.Api.Data.Implementations;
using src.Api.Domain.Entities;
using Xunit;

namespace src.Api.Data.Test
{
    public class UfGets : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public UfGets(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "Gets de UF")]
        [Trait("GETs", "UfEntity")]
        public async Task E_Possivel_Realizar_Gets_UF()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UfImplementation _repositorio = new UfImplementation(context);
                UfEntity _entity = new UfEntity
                {
                    Id = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                    Sigla = "SP",
                    Nome = "São Paulo"
                };

                var _registroExiste = await _repositorio.ExistAsync(_entity.Id);
                Assert.True(_registroExiste);

                var _registroSelecionado = await _repositorio.SelectAsync(_entity.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_entity.Sigla, _registroSelecionado.Sigla);
                Assert.Equal(_entity.Nome, _registroSelecionado.Nome);
                Assert.Equal(_entity.Id, _registroSelecionado.Id);

                var _todosRegistros = await _repositorio.SelectAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() == 27);
            }
        }
    }
}
