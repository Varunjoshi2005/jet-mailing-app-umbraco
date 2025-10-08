using ArielProject.Data;
using ArielProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ArielProject.Repositories
{
    public class UserRepository(AppDbContext appDbContext)
    {

        public readonly AppDbContext _context = appDbContext;

        public void HandleAddNewUser(UserModel user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public bool CheckUserExistsByItsId(Guid userId)
        {
            if (userId.Equals("")) return false;

            return _context.Users.Any(u => u.Id == userId);
        }

        public async Task<UserModel> GetUserByItsEmailAsync(string email)
        {

            UserModel user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }
    }
}