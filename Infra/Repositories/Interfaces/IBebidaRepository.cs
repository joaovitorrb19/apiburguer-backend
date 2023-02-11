using ApiBurguer.Model;

namespace ApiBurguer.Infra.Repositories.Interfaces {

    public interface IBebidaRepository : IBaseRepository {

        public Task<List<Bebida>> GetAll();

        public Task<Bebida> GetById(int id);

        public Boolean ValidarExistenciaPorNome(Bebida bebida);

    }
}