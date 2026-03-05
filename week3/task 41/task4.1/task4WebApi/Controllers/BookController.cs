using Microsoft.AspNetCore.Mvc;
using task4ModelBase.Models;
using task4ModelBase.Repository;
using task4Services.Mapper;
using task4Services.Mapper.DtoModdels;
using task4Services.RepositoryService;

namespace task4WebApi.Controllers
{
    [ApiController]
    [Route("api/Books")]
    public class BookController : Controller
    {
        private BookService repo;
        public BookController(BookService _repo)
        {
            repo = _repo;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = repo.GetById(id);
            return View(data);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(BookDto data)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(BookDto data)
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return View();
        }
          
    }
}
