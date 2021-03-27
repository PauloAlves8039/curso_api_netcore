using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using src.Api.Domain.Dtos.Uf;
using Xunit;

namespace src.Api.Integration.Test.Usuario.Uf
{
    public class QuandoRequisitarUf : BaseIntegration
    {
        [Fact]
        public async Task E_Possivel_Realizar_Crud_Usuario()
        {
            await AdicionarToken();

            response = await client.GetAsync($"{hostApi}ufs");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var listaFromJson = JsonConvert.DeserializeObject<IEnumerable<UfDto>>(jsonResult);
            Assert.NotNull(listaFromJson);
            Assert.True(listaFromJson.Count() == 27);
            Assert.True(listaFromJson.Where(r => r.Sigla == "SP").Count() == 1);

            var id = listaFromJson.Where(r => r.Sigla == "SP").FirstOrDefault().Id;
            response = await client.GetAsync($"{hostApi}ufs/{id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<UfDto>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal("São Paulo", registroSelecionado.Nome);
            Assert.Equal("SP", registroSelecionado.Sigla);
        }
    }
}
