using ApiBurguer.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiBurguer.Data {

    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
            
        }
        public DbSet<Pao> Paes {get;set;}
    }

}