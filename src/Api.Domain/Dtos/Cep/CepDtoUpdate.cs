using System;
using System.ComponentModel.DataAnnotations;

namespace src.Api.Domain.Dtos.Cep
{
    public class CepDtoUpdate
    {

        [Required(ErrorMessage = "Id é um campo obrigatório!")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "CEP é um campo obrigatório!")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "logradouro é um campo obrigatório!")]
        public string Logradouro { get; set; }

        public string Numero { get; set; }

        [Required(ErrorMessage = "Município é um campo obrigatório!")]
        public Guid MunicipioId { get; set; }
    }
}
