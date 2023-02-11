using ApiBurguer.Data;
using ApiBurguer.Infra.Repositories.Interfaces;
using ApiBurguer.Infra.Services;
using ApiBurguer.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiBurguer.Controllers {
        [Route("api/molho")]
        public class MolhoController : ControllerBase {

        private readonly MolhoService _service;
        private readonly IUnitOfWork _unitofwork;

        public MolhoController(MolhoService service, IUnitOfWork unitofwork)
        {
            _service = service;
            _unitofwork = unitofwork;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Molho>>> GetAll(){
            
                try{
                  return Ok(await _service.GetAll());
                } catch (Exception e){
                    return BadRequest(e.Message);
                }
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Molho>> GetById(int id){
            try{
            return Ok( await _service.GetById(id));
            } catch (Exception e){
            return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<Molho>> Post([FromBody]Molho molho){
        try{
            if(ModelState.IsValid){
            _service.VerifyAndCreate(molho);
            await _unitofwork.SaveChangesAsync();
            return Ok($"{molho.nome} adicionado com sucesso!");
            } else {
                return BadRequest($"Dados inválidos...");
            }                  
        } catch (Exception e){
                return BadRequest(e.Message);
        }
        }

        [HttpDelete]
        [Route("")]
        public async Task<ActionResult> Delete([FromBody]Molho molho){
            try{
                _service.Delete(molho);
                await _unitofwork.SaveChangesAsync();
                return Ok($"{molho.nome} deletado com sucesso!");
            } catch(Exception e){
                return BadRequest(e.Message);
            }
        }   
    
        [HttpPut]
        [Route("")]
        public async Task<ActionResult> Put([FromBody]Molho molho){
            try{
             _service.Update(molho);
             await _unitofwork.SaveChangesAsync();
             return Ok($"{molho.nome} alterado com sucesso...");
            } catch (Exception e){
                return BadRequest(e.Message);
            }
        }
    }
    
}