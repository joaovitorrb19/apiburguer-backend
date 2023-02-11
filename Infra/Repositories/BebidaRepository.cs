using ApiBurguer.Data;
using ApiBurguer.Infra.Repositories.Interfaces;
using ApiBurguer.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiBurguer.Infra.Repositories {
    public class BebidaRepository : BaseRepository, IBebidaRepository
    {
        private readonly DataContext _context;
        public BebidaRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Bebida>> GetAll()
        {
            return await _context.Bebidas.ToListAsync();
        }

        public async Task<Bebida> GetById(int id)
        {
            return await _context.Bebidas.FirstOrDefaultAsync(x => x.id == id);
        }

        public Boolean ValidarExistenciaPorNome(Bebida bebida){
          return  _context.Bebidas.FirstOrDefault(x => x.nome == bebida.nome) == null ? false : true ;
        }

    }
}