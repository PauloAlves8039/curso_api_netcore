using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using src.Api.Domain.Dtos.Uf;
using src.Api.Domain.Interfaces.Services.Uf;
using src.Api.Domain.Repository;

namespace src.Api.Service.Services
{
    public class UfService : IUfService
    {
        private IUfRepository _repository;
        private readonly IMapper _mapper;

        public UfService(IUfRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UfDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<UfDto>(entity);
        }

        public async Task<IEnumerable<UfDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<UfDto>>(listEntity);
        }
    }
}
