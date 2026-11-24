namespace movieAPI_v1.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int BirthYear { get; set; }
        public ICollection<Movies> Movies { get; set; } = new List<Movies>();
    }
}
