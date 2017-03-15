using System.Threading.Tasks;
using GoMapsCloudAPI.Models;

namespace GoMapsCloudAPI.Interfaces
{
    public interface IUsersRepository
    {
        bool Exists(long user_id);
        Task Create(User user);
    }
}