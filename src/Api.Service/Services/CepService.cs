using System;
using System.Threading.Tasks;
using AutoMapper;
using src.Api.Domain.Dtos.Cep;
using src.Api.Domain.Entities;
using src.Api.Domain.Interfaces.Services.Cep;
using src.Api.Domain.Models;
using src.Api.Domain.Repository;

namespace src.Api.Service.Services
{
    public class CepService : ICepService
    {
        private ICepRepository _repository;
        private readonly IMapper _mapper;

        public CepService(ICepRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CepDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<CepDto>(entity);
        }

        public async Task<CepDto> Get(string cep)
        {
            var entity = await _repository.SelectAsync(cep);
            return _mapper.Map<CepDto>(entity);
        }

        public async Task<CepDtoCreateResult> Post(CepDtoCreate cep)
        {
            var model = _mapper.Map<CepModel>(cep);
            var entity = _mapper.Map<CepEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<CepDtoCreateResult>(result);
        }

        public async Task<CepDtoUpdateResult> Put(CepDtoCreate cep)
        {
            var model = _mapper.Map<CepModel>(cep);
            var entity = _mapper.Map<CepEntity>(model);

            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<CepDtoUpdateResult>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
