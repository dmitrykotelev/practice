namespace task4Services.Mapper.DtoModdels
{
    public class BookDto : IDto
    {
        public int Id;
        public string Title;
        public DateTime PublishedYear;
        public int AuthorId;
        public int GetId() { return Id; }

    }
}
