namespace Project_Structure.Models
{
    public class Movie
    {
        public int Code { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = null!;

        public override string ToString()
        {
            return $"{Code}, {Name}, {Description ?? string.Empty}";
        }
    }
}
