using Microsoft.AspNetCore.Mvc;
using task4Services.Mapper;
using task4Services.Mapper.DtoModdels;
using task4Services.RepositoryService;

namespace task4WebApi.Controllers
{
    public class AuthorController : Controller
    {
        private AuthorService repo;
        public AuthorController(AuthorService _repo)
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
        public IActionResult Add(AuthorDto data)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(AuthorDto data)
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
