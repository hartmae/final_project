namespace FinalProject.Models
{
    public class Hobby
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int Timespent { get; set; }
        public string WhenStarted { get; set; } = string.Empty;
    }
}
