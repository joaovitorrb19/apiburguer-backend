using ApiBurguer.Data;
using ApiBurguer.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiBurguer.Infra.Repositories {
    public class BaseRepository : IBaseRepository
    {
        private readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }
        public void Put<T>(T objeto) where T : class
        {
           _context.Set<T>().Entry(objeto).State = EntityState.Modified;
        }

        public void Post<T>(T objeto) where T : class
        {
           _context.Set<T>().AddAsync(objeto);
        }

        public void Delete<T>(T objeto) where T : class
        {
            _context.Set<T>().Remove(objeto);
        }
    }
}