using System.ComponentModel.DataAnnotations;

namespace task4Services.Mapper.DtoModdels
{
    public class BookDto : IDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Title { get; set; }
        public DateTime PublishedYear { get; set; } = DateTime.Now;
        public int AuthorId { get; set; }
        public int GetId() { return Id; }

    }
}
