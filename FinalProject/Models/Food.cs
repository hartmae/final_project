namespace FinalProject.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int Calories { get; set; }
        public string MainIngredient { get; set; } = string.Empty;
    }
}
