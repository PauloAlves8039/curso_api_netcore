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
    public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public UsuarioCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Usuário")]
        [Trait("CRUD", "UserEntity")]
        public async Task E_Possivel_Realizar_CRUD_Usuario()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repositorio = new UserImplementation(context);
                UserEntity _entity = new UserEntity
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };

                var _registroCriado = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Email, _registroCriado.Email);
                Assert.Equal(_entity.Name, _registroCriado.Name);
                Assert.False(_registroCriado.Id == Guid.Empty);

                _entity.Name = Faker.Name.First();

                var registroAtualizado = await _repositorio.UpdateAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Email, registroAtualizado.Email);
                Assert.Equal(_entity.Name, registroAtualizado.Name);

                var _registroExiste = await _repositorio.ExistAsync(registroAtualizado.Id);
                Assert.True(_registroExiste);

                var _registroSelecionado = await _repositorio.SelectAsync(registroAtualizado.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(registroAtualizado.Email, _registroSelecionado.Email);
                Assert.Equal(registroAtualizado.Name, _registroSelecionado.Name);

                var _todosRegistros = await _repositorio.SelectAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() > 1);

                var _removeu = await _repositorio.DeleteAsync(_registroSelecionado.Id);
                Assert.True(_removeu);

                var _usuarioPadrao = await _repositorio.FindByLogin("mfrinfo@mail.com");
                Assert.NotNull(_usuarioPadrao);
                Assert.Equal("mfrinfo@mail.com", _usuarioPadrao.Email);
                Assert.Equal("Administrador", _usuarioPadrao.Name);
            }
        }
    }
}
