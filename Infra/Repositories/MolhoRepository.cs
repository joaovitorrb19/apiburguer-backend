using ApiBurguer.Data;
using ApiBurguer.Infra.Repositories.Interfaces;
using ApiBurguer.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiBurguer.Infra.Repositories {
    public class MolhoRepository : BaseRepository, IMolhoRepository
    {
        private readonly DataContext _context;
        public MolhoRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Molho>> GetAll()
        {
            return await _context.Molhos.ToListAsync();
        }

        public async Task<Molho> GetById(int id)
        {
            return await _context.Molhos.FirstOrDefaultAsync(x => x.id == id);
        }

        public Boolean ValidarExistenciaPorNome(Molho molho){
          return  _context.Molhos.FirstOrDefault(x => x.nome == molho.nome) == null ? false : true ;
        }

    }
}