using ApiBurguer.Model;

namespace ApiBurguer.Infra.Repositories.Interfaces {

    public interface IPaoRepository : IBaseRepository {

        public Task<List<Pao>> GetAll();

        public Task<Pao> GetById(int id);

        public Boolean ValidarExistenciaPorNome(Pao pao);

    }
}