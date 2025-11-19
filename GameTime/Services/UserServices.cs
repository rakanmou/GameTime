using GameTime.Models;
using GameTime.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GameTime.Services
{
    public class UserServices
    {
        private readonly GameTimeDbContext _context;

        public UserServices (GameTimeDbContext Context) {  _context = Context; }

        public async Task AddUser(UserRegistrationVM model)
        {
            

            var user = new tblUsers
            {
                UserName = model.UserName,
                Email = model.Email,
                Password = model.Password,
                role = "User",
                CreatedAt = DateTime.Now,
                IsDeleted = false
            };

            _context.tblUsers.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
