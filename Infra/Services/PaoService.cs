using ApiBurguer.Infra.Repositories.Interfaces;
using ApiBurguer.Model;

namespace ApiBurguer.Infra.Services {
    public class PaoService {

        private readonly IPaoRepository _repository;

        public PaoService(IPaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Pao>> GetAll(){
            return await  _repository.GetAll();
        }

        public async Task<Pao> GetById(int id){
            return await _repository.GetById(id);
        }

        public void VerifyAndCreate(Pao pao){
            if(_repository.ValidarExistenciaPorNome(pao) == false){
                _repository.Post(pao);
            } else {
                throw new BadHttpRequestException($"{pao.nome} já está cadastrado...",400);
            }
           
        }   
        
        public void Delete(Pao pao){
            _repository.Delete(pao);
        }

        public void Update(Pao pao){
            _repository.Put(pao);
        }

    }
}