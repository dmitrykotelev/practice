using Microsoft.AspNetCore.Mvc;
using task4Services.Mapper;
using task4Services.Mapper.DtoModdels;
using task4Services.RepositoryService;
using task4Services.Validator;

namespace task4WebApi.Controllers
{
    [Route("api/Author")]
    public class AuthorController : Controller
    {
        private AuthorService repo;
        private AuthorValidator validator;
        public AuthorController(AuthorService _repo, AuthorValidator _validator)
        {
            repo = _repo;
            validator = _validator;
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
            if (!repo.Delete(id))
                return NotFound();
            return Ok();
        }

        [HttpPost("Add")]
        public async  Task<IActionResult> Add(AuthorDto data)
        {
            var validationResult = await validator.ValidateAsync(data);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }
            repo.Add(data);
            return Ok(data);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(AuthorDto data)
        {
            var _data = repo.GetById(data.Id);
            if (_data == null)
                return NotFound();

            repo.Update(data);
            return Ok(data);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = repo.GetAll();
            return Ok(data);
        }
    }
}
