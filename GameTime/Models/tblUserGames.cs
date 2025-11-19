namespace GameTime.Models
{
    public class tblUserGames
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public required tblUsers User { get; set; }
        public int GameId { get; set; }
        public required tblGames Game { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

    }
}
