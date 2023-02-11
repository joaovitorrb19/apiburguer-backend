using ApiBurguer.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiBurguer.Data {

    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
            
        }
        public DbSet<Pao> Paes {get;set;}

        public DbSet<Molho> Molhos {get;set;}

        public DbSet<Carne> Carnes {get;set;}

        public DbSet<Bebida> Bebidas {get;set;}

        public DbSet<Acompanhamento> Acompanhamentos {get;set;}
        
    }

}