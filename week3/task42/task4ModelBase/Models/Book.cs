using task4ModelBase.Interfaces;

namespace task4ModelBase.Models
{
    public class Book : IModel
    {
        public int Id { get; set; }
        public string Title {  get; set; }
        public DateTime PublishedYear { get; set; }
        public int? AuthorId { get; set; }
    }
}