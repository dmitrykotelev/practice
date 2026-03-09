using task4ModelBase.Interfaces;

namespace task4ModelBase.Models
{
    public class Book : IModel
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public string Title;
        public DateTime PublishedYear;
        public int AuthorId;
        public int GetId() {  return Id; }

    }
}
