using apiVacinados.Exceptions;
using apiVacinados.Models;
using apiVacinados.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace apiVacinados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacinadosController : ControllerBase
    {
        MongoDbRepository _mongoRepository;
        IMongoCollection<VacinadoInputModel> _vacinadosCollection;

        public VacinadosController(MongoDbRepository mongoRepository)
        {
            _mongoRepository = mongoRepository;
            _vacinadosCollection = _mongoRepository.DB.GetCollection<VacinadoInputModel>(typeof(VacinadoInputModel).Name.ToLower());
        }

        /// <summary>
        /// Realiza o cadastro de uma pessoa e suas informações sobre a vacinação
        /// </summary>
        /// <param name="model">Modelo de cadastro com todas as informações do vacinado</param>
        /// <response code="201">Cadastro realizado com sucesso</response>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GravarVacinado([FromBody] VacinadoViewModel model)
        {
            try
            {
                var vacinado = new VacinadoInputModel(model.Id, model.DataNascimento, model.Sexo, model.Vacina, model.StatusPrimeiraDose, model.DataPrimeiraDose, model.StatusSegundaDose, model.DataSegundaDose, model.Situacao, model.Latitude, model.Longitude);
                _vacinadosCollection.InsertOne(vacinado);
                return StatusCode(201, "Cadastro realizado com sucesso");
            }
            catch (VacinadoJaCadastradoException ex)
            {
                return UnprocessableEntity(ex);
            }
            
        }
        
        /// <summary>
        /// Mostra todos os registros cadastrados
        /// </summary>
        /// <response code="200">Lista de vacinados retornada com sucesso</response>
        /// <response code="204">Não há cadastros a serem consultados</response>
        [HttpGet]
        public ActionResult ObterVacinados()
        {
            var vacinados = _vacinadosCollection.Find(Builders<VacinadoInputModel>.Filter.Empty).ToList();
            if (vacinados.Count() == 0)
                return NoContent();
            return Ok(vacinados);
        }

        /// <summary>
        /// Remove um cadastro do sistema
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Remoção realizada com sucesso</response>
        [HttpDelete]
        public ActionResult DeletarCadastro([FromBody] Guid id)
        {
            try
            {
                _vacinadosCollection.DeleteOne(Builders<VacinadoInputModel>.Filter.Where(_ => _.Id == id));
                return Ok("Delete realizado");
            }
            catch (CadastroInexistenteException ex)
            {
                return NotFound(ex);
            }
        }

        /// <summary>
        /// Atualiza por completo um cadastro já existente
        /// </summary>
        /// <param name="model"></param>
        /// <response code="201">Cadastro realizado com sucesso</response>
        [HttpPut]
        public ActionResult AtualizarCadastro([FromBody] VacinadoViewModel model)
        {
            try
            {
                var vacinado = new VacinadoInputModel(model.Id, model.DataNascimento, model.Sexo, model.Vacina, model.StatusPrimeiraDose, model.DataPrimeiraDose, model.StatusSegundaDose, model.DataSegundaDose, model.Situacao, model.Latitude, model.Longitude);
                //_vacinadosCollection.UpdateOne(Builders<VacinadoInputModel>.Filter.Where(w => w.Id == model.Id),Builders<VacinadoInputModel>.Update.Set();
                _vacinadosCollection.ReplaceOne(Builders<VacinadoInputModel>.Filter.Where(w => w.Id == model.Id), vacinado);
                return StatusCode(201, "Atualização realizada com sucesso");
            }
            catch (CadastroInexistenteException ex)
            {
                return NotFound(ex);
            }
        }
    }
}
