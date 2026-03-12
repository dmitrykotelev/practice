using Microsoft.AspNetCore.Mvc;
using task4ModelBase.Models;
using task4Services.Mapper;
using task4Services.RepositoryService;
using task4Services.Validator;

namespace task4WebApi.Controllers
{
    [Route("api/Author")]
    public class AuthorController : BaseController<Author,AuthorDto>
    {
        public AuthorController(AuthorService repo, AuthorValidator validator) : base(repo, validator) { }
    }
}