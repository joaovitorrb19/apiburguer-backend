using ApiBurguer.Infra.Repositories.Interfaces;
using ApiBurguer.Model;

namespace ApiBurguer.Infra.Services {
    public class BebidaService {

        private readonly IBebidaRepository _repository;

        public BebidaService(IBebidaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Bebida>> GetAll(){
            return await  _repository.GetAll();
        }

        public async Task<Bebida> GetById(int id){
            return await _repository.GetById(id);
        }

        public void VerifyAndCreate(Bebida bebida){
            if(_repository.ValidarExistenciaPorNome(bebida) == false){
                _repository.Post(bebida);
            } else {
                throw new BadHttpRequestException($"{bebida.nome} já está cadastrado...",400);
            }
           
        }   
        
        public void Delete(Bebida bebida){
            _repository.Delete(bebida);
        }

        public void Update(Bebida bebida){
            _repository.Put(bebida);
        }

    }
}