using System.Collections.Generic;
using Backend.Models;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private readonly ICrudRepository<CrudModels> _crudRepository;

        public CrudController(ICrudRepository<CrudModels> crudRepository)
        {
            _crudRepository = crudRepository;
        }

        // GET: api/Crud
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<CrudModels> dataList = _crudRepository.GetAll();
            return Ok(dataList);
        }

        // GET: api/Crud/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            CrudModels entity = _crudRepository.Get(id);
            if (entity == null)
                return NotFound("Can't get this record!");
            return Ok(entity);
        }

        // POST: api/Crud
        [HttpPost]
        public IActionResult Post(CrudModels entity)
        {
            if (entity == null)
                return BadRequest("The record isn't found!");
            _crudRepository.Add(entity);
            return CreatedAtRoute("Get", new { id = entity.ID }, entity);
        }

        // PUT: api/Crud/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, CrudModels entity)
        {
            if (entity == null)
                return BadRequest("The record isn't found!");
            CrudModels entityUpdate = _crudRepository.Get(id);
            if (entityUpdate == null)
                return NotFound("Can't get this record");
            _crudRepository.Update(entityUpdate, entity);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            CrudModels entity = _crudRepository.Get(id);
            if (entity == null)
                return NotFound("Can't get this record");
            _crudRepository.Delete(entity);
            return NoContent();
        }
    }
}
