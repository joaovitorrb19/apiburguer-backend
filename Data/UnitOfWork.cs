namespace ApiBurguer.Data {
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context ;
        }
        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
          await  _context.SaveChangesAsync();
        }
    }
}