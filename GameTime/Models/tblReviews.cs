namespace GameTime.Models
{
    public class tblReviews
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public required tblUsers User { get; set; }
        public int GameId { get; set; }
        public required tblGames Game { get; set; }
        public required string? Text { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }

    }
}
