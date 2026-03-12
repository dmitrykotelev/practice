using System.ComponentModel.DataAnnotations;
using task4ModelBase.Interfaces;

namespace task4Services.Mapper.DtoModdels
{
    public class BookDto : IModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Title { get; set; }
        public DateTime PublishedYear { get; set; } = DateTime.Now;
        [Required]
        public int AuthorId { get; set; }

    }
}
