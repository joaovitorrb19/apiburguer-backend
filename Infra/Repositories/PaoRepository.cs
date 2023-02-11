using ApiBurguer.Data;
using ApiBurguer.Infra.Repositories.Interfaces;
using ApiBurguer.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiBurguer.Infra.Repositories {
    public class PaoRepository : BaseRepository, IPaoRepository
    {
        private readonly DataContext _context;
        public PaoRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Pao>> GetAll()
        {
            return await _context.Paes.ToListAsync();
        }

        public async Task<Pao> GetById(int id)
        {
            return await _context.Paes.FirstOrDefaultAsync(x => x.id == id);
        }

        public Boolean ValidarExistenciaPorNome(Pao pao){
          return  _context.Paes.FirstOrDefault(x => x.nome == pao.nome) == null ? false : true ;
        }

    }
}