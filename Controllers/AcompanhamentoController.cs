using ApiBurguer.Data;
using ApiBurguer.Infra.Repositories.Interfaces;
using ApiBurguer.Infra.Services;
using ApiBurguer.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiBurguer.Controllers {
        [Route("api/molho")]
        public class AcompanhamentoController : ControllerBase {

        private readonly AcompanhamentoService _service;
        private readonly IUnitOfWork _unitofwork;

        public AcompanhamentoController(AcompanhamentoService service, IUnitOfWork unitofwork)
        {
            _service = service;
            _unitofwork = unitofwork;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Acompanhamento>>> GetAll(){
            
                try{
                  return Ok(await _service.GetAll());
                } catch (Exception e){
                    return BadRequest(e.Message);
                }
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Acompanhamento>> GetById(int id){
            try{
            return Ok( await _service.GetById(id));
            } catch (Exception e){
            return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<Acompanhamento>> Post([FromBody]Acompanhamento acompanhamento){
        try{
            if(ModelState.IsValid){
            _service.VerifyAndCreate(acompanhamento);
            await _unitofwork.SaveChangesAsync();
            return Ok($"{acompanhamento.nome} adicionado com sucesso!");
            } else {
                return BadRequest($"Dados inválidos...");
            }                  
        } catch (Exception e){
                return BadRequest(e.Message);
        }
        }

        [HttpDelete]
        [Route("")]
        public async Task<ActionResult> Delete([FromBody]Acompanhamento acompanhamento){
            try{
                _service.Delete(acompanhamento);
                await _unitofwork.SaveChangesAsync();
                return Ok($"{acompanhamento.nome} deletado com sucesso!");
            } catch(Exception e){
                return BadRequest(e.Message);
            }
        }   
    
        [HttpPut]
        [Route("")]
        public async Task<ActionResult> Put([FromBody]Acompanhamento acompanhamento){
            try{
             _service.Update(acompanhamento);
             await _unitofwork.SaveChangesAsync();
             return Ok($"{acompanhamento.nome} alterado com sucesso...");
            } catch (Exception e){
                return BadRequest(e.Message);
            }
        }
    }
    
}