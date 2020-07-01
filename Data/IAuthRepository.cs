using System.Threading.Tasks;
using WebApiCore31.Models;

namespace WebApiCore31.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password); 
        Task<User> Login(string username, string pasword);
        Task<bool> UserExists(string username);
    }
}