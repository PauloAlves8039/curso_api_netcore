using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace src.Api.Domain.Entities
{
    public class MunicioEntity : BaseEntity
    {
        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }

        public int CodIBGE { get; set; }

        [Required]
        public Guid UfId { get; set; }

        public UfEntity Uf { get; set; }

        public IEnumerable<CepEntity> Ceps { get; set; }
    }
}
