using ApiBurguer.Data;
using ApiBurguer.Infra.Repositories.Interfaces;
using ApiBurguer.Infra.Services;
using ApiBurguer.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiBurguer.Controllers {
        [Route("api/bebida")]
        public class BebidaController : ControllerBase {

        private readonly BebidaService _service;
        private readonly IUnitOfWork _unitofwork;

        public BebidaController(BebidaService service, IUnitOfWork unitofwork)
        {
            _service = service;
            _unitofwork = unitofwork;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Bebida>>> GetAll(){
            
                try{
                  return Ok(await _service.GetAll());
                } catch (Exception e){
                    return BadRequest(e.Message);
                }
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Bebida>> GetById(int id){
            try{
            return Ok( await _service.GetById(id));
            } catch (Exception e){
            return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<Bebida>> Post([FromBody]Bebida bebida){
        try{
            if(ModelState.IsValid){
            _service.VerifyAndCreate(bebida);
            await _unitofwork.SaveChangesAsync();
            return Ok($"{bebida.nome} adicionado com sucesso!");
            } else {
                return BadRequest($"Dados inválidos...");
            }                  
        } catch (Exception e){
                return BadRequest(e.Message);
        }
        }

        [HttpDelete]
        [Route("")]
        public async Task<ActionResult> Delete([FromBody]Bebida bebida){
            try{
                _service.Delete(bebida);
                await _unitofwork.SaveChangesAsync();
                return Ok($"{bebida.nome} deletado com sucesso!");
            } catch(Exception e){
                return BadRequest(e.Message);
            }
        }   
    
        [HttpPut]
        [Route("")]
        public async Task<ActionResult> Put([FromBody]Bebida bebida){
            try{
             _service.Update(bebida);
             await _unitofwork.SaveChangesAsync();
             return Ok($"{bebida.nome} alterado com sucesso...");
            } catch (Exception e){
                return BadRequest(e.Message);
            }
        }
    }
    
}