using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using task4ModelBase.Interfaces;
using task4Services.RepositoryService;

namespace task4WebApi.Controllers
{
    [Route("api/Books")]
    public class BaseController<T,TT> : Controller where T : class, IModel
                                                   where TT : class , IModel
    {
        protected RepositoryService<T,TT> repo;
        protected AbstractValidator<TT> validator;
        public BaseController(RepositoryService<T, TT> _repo, AbstractValidator<TT> _validator)
        {
            repo = _repo;
            validator = _validator;
        }

        [HttpPost("Add")]
        public virtual async Task<IActionResult> Add(TT data)
        {
            if (data == null)
                return BadRequest();

            var validationResult = await validator.ValidateAsync(data);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }
            
            return Ok(repo.Add(data));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = repo.GetById(id);
            if (data == null)
                return NotFound();
            else
                return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (repo.GetById(id) == null)
                return NotFound();

            if (!repo.Delete(id))
                return NotFound();

            return Ok();
        }

        [HttpPost("Update")]
        public virtual async Task<IActionResult> Update(TT data)
        {
            if (data == null)
                return BadRequest();

            if (repo.GetById(data.Id) == null)
                return NotFound();

            return Ok(repo.Update(data));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(repo.GetAll());
        }

    }
}