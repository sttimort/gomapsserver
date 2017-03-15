using System.Linq;
using System.Threading.Tasks;
using GoMapsCloudAPI.Interfaces;

namespace GoMapsCloudAPI.Models
{

    public class UsersRepository : IUsersRepository
    {

        private UsersContext _db;
        public UsersRepository(UsersContext context)
        {
            _db = context;
        }
        public async Task Create(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }

        public bool Exists(long key)
        {
            IQueryable foundUsers = _db.Users.Where(p => p.Id == key);
            if (foundUsers == null) return false;
            else return true;
        }
    }
}
