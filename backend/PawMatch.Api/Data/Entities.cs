namespace PawMatch.Api.Data
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Breed { get; set; } = null!;
    }

    public class Owner
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
    }
}
