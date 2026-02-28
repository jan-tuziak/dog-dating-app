namespace PawMatch.Api.Models
{
    public class DogDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Breed { get; set; } = null!;
    }
}