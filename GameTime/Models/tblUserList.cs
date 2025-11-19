namespace GameTime.Models
{
    public class tblUserList
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public required tblUsers User { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }

        public ICollection<tblUserListItems> Items { get; set; } = new List<tblUserListItems>();
    }
}
