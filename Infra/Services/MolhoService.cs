using ApiBurguer.Infra.Repositories.Interfaces;
using ApiBurguer.Model;

namespace ApiBurguer.Infra.Services {
    public class MolhoService {

        private readonly IMolhoRepository _repository;

        public MolhoService(IMolhoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Molho>> GetAll(){
            return await  _repository.GetAll();
        }

        public async Task<Molho> GetById(int id){
            return await _repository.GetById(id);
        }

        public void VerifyAndCreate(Molho molho){
            if(_repository.ValidarExistenciaPorNome(molho) == false){
                _repository.Post(molho);
            } else {
                throw new BadHttpRequestException($"{molho.nome} já está cadastrado...",400);
            }
           
        }   
        
        public void Delete(Molho molho){
            _repository.Delete(molho);
        }

        public void Update(Molho molho){
            _repository.Put(molho);
        }

    }
}