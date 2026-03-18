using Microsoft.AspNetCore.Mvc;
using task4Services.Mapper.DtoModdels;
using task4Services.RepositoryService;
using task4Services.Validator;
using task4ModelBase.Models;

namespace task4WebApi.Controllers
{
    [Route("api/Books")]
    public class BookController : BaseController<Book,BookDto>
    {
        private readonly AuthorService _authorService;
        private readonly BookService _bookService;
        public BookController(BookService repo, AuthorService authorService, BookValidator validator) : base (repo, validator)
        {
            _authorService = authorService;
            _bookService = repo;
        }

        [HttpPost("Add")]
        public override async Task<IActionResult> Add(BookDto data)
        {
            if (data == null)
                return BadRequest();

            if (_authorService.GetById(data.AuthorId ?? 0) == null)
                data.AuthorId = null;

            var validationResult = await validator.ValidateAsync(data);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }
            
            return Ok(repo.Add(data));
        }
        [HttpPost("Update")]
        public override async Task<IActionResult> Update(BookDto data)
        {
            if (data == null)
                return BadRequest();

            if (_authorService.GetById(data.AuthorId ?? 0) == null)
                data.AuthorId = null;

            if (repo.GetById(data.Id) == null)
                return NotFound();

            return Ok(repo.Update(data));
        }

        [HttpGet("FindWithYear")]
        public async Task<IActionResult> FindWithYear(int year)
        {
            var data = _bookService.FindBooksByYear(new DateTime(year, 1, 1));

            if (data == null) 
                return NotFound();

            return Ok(data);
        }
    }
}