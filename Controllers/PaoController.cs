using ApiBurguer.Data;
using ApiBurguer.Infra.Repositories.Interfaces;
using ApiBurguer.Infra.Services;
using ApiBurguer.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiBurguer.Controllers {
        [Route("api/pao")]
        public class PaoController : ControllerBase {

        private readonly PaoService _service;
        private readonly IUnitOfWork _unitofwork;

        public PaoController(PaoService service, IUnitOfWork unitofwork)
        {
            _service = service;
            _unitofwork = unitofwork;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Pao>>> GetAll(){
            
                try{
                  return Ok(await _service.GetAll());
                } catch (Exception e){
                    return BadRequest(e.Message);
                }
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Pao>> GetById(int id){
            try{
            return Ok( await _service.GetById(id));
            } catch (Exception e){
            return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<Pao>> Post([FromBody]Pao pao){
        try{
            if(ModelState.IsValid){
            _service.VerifyAndCreate(pao);
            await _unitofwork.SaveChangesAsync();
            return Ok($"{pao.nome} adicionado com sucesso!");
            } else {
                return BadRequest($"Dados inválidos...");
            }                  
        } catch (Exception e){
                return BadRequest(e.Message);
        }
        }

        [HttpDelete]
        [Route("")]
        public async Task<ActionResult> Delete([FromBody]Pao pao){
            try{
                _service.Delete(pao);
                await _unitofwork.SaveChangesAsync();
                return Ok($"{pao.nome} deletado com sucesso!");
            } catch(Exception e){
                return BadRequest(e.Message);
            }
        }   
    
        [HttpPut]
        [Route("")]
        public async Task<ActionResult> Put([FromBody]Pao pao){
            try{
             _service.Update(pao);
             await _unitofwork.SaveChangesAsync();
             return Ok($"{pao.nome} alterado com sucesso...");
            } catch (Exception e){
                return BadRequest(e.Message);
            }
        }
    }
    
}