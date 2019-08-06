using IDE.BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDE.API.Controllers
{
    public abstract class AbstractController<T, U> : ControllerBase where T : BaseService<U>
    {
        T _service;
        public AbstractController(T service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<U>>> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<U>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] U entity)
        {
            await _service.Update(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}