using task4ModelBase.Interfaces;

namespace task4ModelBase.Models
{
    public class Book : IModel
    {
        public int Id;
        public string Title;
        public DateTime PublishedYear;
        public int AuthorId;
        public int GetId() {  return Id; }

    }
}
