namespace ApiBurguer.Infra.Repositories.Interfaces {
    public interface IBaseRepository {
        public void Put<T>(T objeto) where T : class ;

        public void Post<T>(T objeto) where T : class ;

        public void Delete<T>(T objeto) where T : class ;
    }
}