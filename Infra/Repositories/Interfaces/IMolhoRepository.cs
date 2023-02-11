using ApiBurguer.Model;

namespace ApiBurguer.Infra.Repositories.Interfaces {

    public interface IMolhoRepository : IBaseRepository {

        public Task<List<Molho>> GetAll();

        public Task<Molho> GetById(int id);

        public Boolean ValidarExistenciaPorNome(Molho pao);

    }
}