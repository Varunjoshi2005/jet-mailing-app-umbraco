using ArielProject.Models;

namespace ArielProject.Interfaces.IRepositories
{

    public interface IUserRepository
    {
        public void HandleAddNewUser(UserModel user);
        public bool CheckUserExistsByItsId(Guid userId);

        public Task<UserModel> GetUserByItsEmailAsync(string email);
     }

}