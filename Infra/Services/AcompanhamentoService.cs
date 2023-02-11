using ApiBurguer.Infra.Repositories.Interfaces;
using ApiBurguer.Model;

namespace ApiBurguer.Infra.Services {
    public class AcompanhamentoService {

        private readonly IAcompanhamentoRepository _repository;

        public AcompanhamentoService(IAcompanhamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Acompanhamento>> GetAll(){
            return await  _repository.GetAll();
        }

        public async Task<Acompanhamento> GetById(int id){
            return await _repository.GetById(id);
        }

        public void VerifyAndCreate(Acompanhamento acompanhamento){
            if(_repository.ValidarExistenciaPorNome(acompanhamento) == false){
                _repository.Post(acompanhamento);
            } else {
                throw new BadHttpRequestException($"{acompanhamento.nome} já está cadastrado...",400);
            }
           
        }   
        
        public void Delete(Acompanhamento acompanhamento){
            _repository.Delete(acompanhamento);
        }

        public void Update(Acompanhamento acompanhamento){
            _repository.Put(acompanhamento);
        }

    }
}