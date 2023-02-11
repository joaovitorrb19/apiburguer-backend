namespace ApiBurguer.Data {
    public interface IUnitOfWork {
        public Task SaveChangesAsync();

        public void Rollback();

    }
}