using ApiBurguer.Model;

namespace ApiBurguer.Infra.Repositories.Interfaces {

    public interface IAcompanhamentoRepository : IBaseRepository {

        public Task<List<Acompanhamento>> GetAll();

        public Task<Acompanhamento> GetById(int id);

        public Boolean ValidarExistenciaPorNome(Acompanhamento acompanhamento);

    }
}