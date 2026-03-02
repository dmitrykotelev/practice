using task4ModelBase.Interfaces;

namespace task4ModelBase.Models
{
    public class Author : IModel
    {
        private int Id;
        public int GetId() { return Id; }
    }
}
