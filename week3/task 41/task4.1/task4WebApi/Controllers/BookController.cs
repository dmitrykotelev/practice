using Microsoft.AspNetCore.Mvc;
using task4Services.Mapper.DtoModdels;
using task4Services.RepositoryService;
using task4Services.Validator;

namespace task4WebApi.Controllers
{
    [Route("api/Books")]
    public class BookController : Controller
    {
        private BookService repo;
        private BookValidator validator;
        private AuthorService authorRepo;
        public BookController(BookService _repo, AuthorService _authorRepo, BookValidator _validator)
        {
            repo = _repo;
            authorRepo = _authorRepo;
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
        public async Task<IActionResult> Add(BookDto data)
        {
            var authorCheck = authorRepo.GetById(data.AuthorId);
            if (authorCheck == null)
                return NotFound();

            var validationResult = await validator.ValidateAsync(data);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }
            repo.Add(data);

            return Ok(data);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(BookDto data)
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
