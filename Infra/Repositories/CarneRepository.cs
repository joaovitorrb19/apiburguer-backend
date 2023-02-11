using ApiBurguer.Data;
using ApiBurguer.Infra.Repositories.Interfaces;
using ApiBurguer.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiBurguer.Infra.Repositories {
    public class CarneRepository : BaseRepository, ICarneRepository
    {
        private readonly DataContext _context;
        public CarneRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Carne>> GetAll()
        {
            return await _context.Carnes.ToListAsync();
        }

        public async Task<Carne> GetById(int id)
        {
            return await _context.Carnes.FirstOrDefaultAsync(x => x.id == id);
        }

        public Boolean ValidarExistenciaPorNome(Carne carne){
          return  _context.Carnes.FirstOrDefault(x => x.nome == carne.nome) == null ? false : true ;
        }

    }
}