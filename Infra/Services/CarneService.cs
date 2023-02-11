using ApiBurguer.Infra.Repositories.Interfaces;
using ApiBurguer.Model;

namespace ApiBurguer.Infra.Services {
    public class CarneService {

        private readonly ICarneRepository _repository;

        public CarneService(ICarneRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Carne>> GetAll(){
            return await  _repository.GetAll();
        }

        public async Task<Carne> GetById(int id){
            return await _repository.GetById(id);
        }

        public void VerifyAndCreate(Carne carne){
            if(_repository.ValidarExistenciaPorNome(carne) == false){
                _repository.Post(carne);
            } else {
                throw new BadHttpRequestException($"{carne.nome} já está cadastrado...",400);
            }
           
        }   
        
        public void Delete(Carne carne){
            _repository.Delete(carne);
        }

        public void Update(Carne carne){
            _repository.Put(carne);
        }

    }
}