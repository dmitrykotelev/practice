using System.ComponentModel.DataAnnotations;
using task4ModelBase.Interfaces;
using task4ModelBase.Models;

namespace task4Services.Mapper
{
    public class AuthorDto : IModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public ICollection<Book> Books { get; set; }
    }
}