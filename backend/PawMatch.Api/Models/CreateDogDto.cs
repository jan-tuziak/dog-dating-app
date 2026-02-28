namespace PawMatch.Api.Models
{
    public class CreateDogDto
    {
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Breed { get; set; } = null!;
    }
}