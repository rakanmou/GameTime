namespace GameTime.Models
{
    public class tblUsers
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string role { get; set; }   
        public string? ProfilePicUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }

        public ICollection<tblUserGames> UserGames { get; set; }  = new List<tblUserGames>();
        public ICollection<tblReviews> Reviews { get; set; } = new List<tblReviews>();
        public ICollection<tblUserList> Lists { get; set; } = new List<tblUserList>();

    }
}
