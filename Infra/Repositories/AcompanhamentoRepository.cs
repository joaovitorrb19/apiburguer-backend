using ApiBurguer.Data;
using ApiBurguer.Infra.Repositories.Interfaces;
using ApiBurguer.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiBurguer.Infra.Repositories {
    public class AcompanhamentoRepository : BaseRepository, IAcompanhamentoRepository
    {
        private readonly DataContext _context;
        public AcompanhamentoRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Acompanhamento>> GetAll()
        {
            return await _context.Acompanhamentos.ToListAsync();
        }

        public async Task<Acompanhamento> GetById(int id)
        {
            return await _context.Acompanhamentos.FirstOrDefaultAsync(x => x.id == id);
        }

        public Boolean ValidarExistenciaPorNome(Acompanhamento acompanhamento){
          return  _context.Acompanhamentos.FirstOrDefault(x => x.nome == acompanhamento.nome) == null ? false : true ;
        }

    }
}