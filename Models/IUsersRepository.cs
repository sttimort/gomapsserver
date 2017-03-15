using System.Threading.Tasks;

namespace GoMapsCloudAPI.Models
{
    public interface IUsersRepository
    {
        bool Exists(long userId);
        Task Create(User user);
    }
}