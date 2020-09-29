using MusicApplication.Models;

namespace MusicApplication.Data.Interfaces
{
    public interface IUserService
    {
        void AddUser(User user);
        void DeleteUser(int id);
    }
}
