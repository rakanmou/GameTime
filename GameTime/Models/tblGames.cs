namespace GameTime.Models
{
    public class tblGames
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Genre { get; set; }
        public string? Platform { get; set; }
        public DateOnly? ReleaseDate { get; set; }
        public string? CoverImageUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
        public ICollection<tblUserGames> UserGames { get; set; } = new List<tblUserGames>();
        public ICollection<tblReviews> Reviews { get; set; } = new List<tblReviews>();
        public ICollection<tblUserListItems> ListItems { get; set; } = new List<tblUserListItems>();
    }
}
