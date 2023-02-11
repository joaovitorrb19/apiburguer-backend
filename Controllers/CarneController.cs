using ApiBurguer.Data;
using ApiBurguer.Infra.Repositories.Interfaces;
using ApiBurguer.Infra.Services;
using ApiBurguer.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiBurguer.Controllers {
        [Route("api/molho")]
        public class CarneController : ControllerBase {

        private readonly CarneService _service;
        private readonly IUnitOfWork _unitofwork;

        public CarneController(CarneService service, IUnitOfWork unitofwork)
        {
            _service = service;
            _unitofwork = unitofwork;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Carne>>> GetAll(){
            
                try{
                  return Ok(await _service.GetAll());
                } catch (Exception e){
                    return BadRequest(e.Message);
                }
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Carne>> GetById(int id){
            try{
            return Ok( await _service.GetById(id));
            } catch (Exception e){
            return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<Molho>> Post([FromBody]Carne carne){
        try{
            if(ModelState.IsValid){
            _service.VerifyAndCreate(carne);
            await _unitofwork.SaveChangesAsync();
            return Ok($"{carne.nome} adicionado com sucesso!");
            } else {
                return BadRequest($"Dados inválidos...");
            }                  
        } catch (Exception e){
                return BadRequest(e.Message);
        }
        }

        [HttpDelete]
        [Route("")]
        public async Task<ActionResult> Delete([FromBody]Carne carne){
            try{
                _service.Delete(carne);
                await _unitofwork.SaveChangesAsync();
                return Ok($"{carne.nome} deletado com sucesso!");
            } catch(Exception e){
                return BadRequest(e.Message);
            }
        }   
    
        [HttpPut]
        [Route("")]
        public async Task<ActionResult> Put([FromBody]Carne carne){
            try{
             _service.Update(carne);
             await _unitofwork.SaveChangesAsync();
             return Ok($"{carne.nome} alterado com sucesso...");
            } catch (Exception e){
                return BadRequest(e.Message);
            }
        }
    }
    
}