using GameTime.Models;
using GameTime.ViewModels.User;
using Microsoft.EntityFrameworkCore;

namespace GameTime.Services
{
    public class UserServices
    {
        private readonly GameTimeDbContext _context;

        public UserServices (GameTimeDbContext Context) {  _context = Context; }

        
        public async Task AddUser(RegistrationVM model)
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

        public async Task<bool> EmailExistsInRegistration(string email)
        {
            return await _context.tblUsers.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> UserNameExistsInRegistration(string username)
        {
            return await _context.tblUsers.AnyAsync(u => u.UserName == username);
        }

        public async Task<tblUsers?> AuthenticateUser(string username, string password)
        {
            var user = await _context.tblUsers.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
            return user;
        }
    }
}
