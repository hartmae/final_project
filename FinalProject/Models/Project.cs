namespace FinalProject.Models
{
    public class Project
    {
        public int Id { get; set; } // Primary Key
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public bool IsComplete { get; set; }
        public int DifficultyLevel { get; set; }
    }
}
