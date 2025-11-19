namespace GameTime.Models
{
    public class tblUserListItems
    {
        public int Id { get; set; }

        public int UserListId { get; set; }
        public required tblUserList UserList { get; set; }

        public int GameId { get; set; }
        public required tblGames Game { get; set; }
        public bool IsDeleted { get; set; }
    }
}
