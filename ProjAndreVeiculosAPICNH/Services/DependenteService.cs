using Models;
using ProjAndreVeiculosAPIDependente.Repositories;
using System.Reflection.Metadata;

namespace ProjAndreVeiculosAPIDependente.Services
{
    public class DependenteService
    {
        private readonly DependenteRepository _dependenteRepository;

        public DependenteService(DependenteRepository dependenteRepository)
        {
            _dependenteRepository = dependenteRepository;
        }

        public Task<IEnumerable<Dependente>> GetAll()
        {
            return _dependenteRepository.GetAll();
        }

        public Task<Dependente> GetById(string documento)
        {
            return _dependenteRepository.GetById(documento);
        }

        public Task Add(Dependente dependente)
        {
            return _dependenteRepository.Add(dependente);
        }

        public Task Update(Dependente dependente)
        {
            return _dependenteRepository.Update(dependente);
        }

        public Task Delete(string documento)
        {
            return _dependenteRepository.DeleteAsync(documento);
        }
    }
}
