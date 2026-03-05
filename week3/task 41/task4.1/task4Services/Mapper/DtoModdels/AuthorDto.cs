using task4Services.Mapper.DtoModdels;

namespace task4Services.Mapper
{
    public class AuthorDto : IDto
    {
        public int Id;
        public string Name;
        public DateTime DateOfBirth;
        public int GetId() { return Id; }

    }
}
