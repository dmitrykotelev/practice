using System.ComponentModel.DataAnnotations;
using task4Services.Mapper.DtoModdels;

namespace task4Services.Mapper
{
    public class AuthorDto : IDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
    }
}
