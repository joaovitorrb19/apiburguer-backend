using ApiBurguer.Model;

namespace ApiBurguer.Infra.Repositories.Interfaces {

    public interface ICarneRepository : IBaseRepository {

        public Task<List<Carne>> GetAll();

        public Task<Carne> GetById(int id);

        public Boolean ValidarExistenciaPorNome(Carne carne);

    }
}