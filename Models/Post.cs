namespace backend_EAD.Models
{
    public class Post
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}