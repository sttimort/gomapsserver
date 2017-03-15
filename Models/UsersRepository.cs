using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace GoMapsCloudAPI.Models
{

    public class UsersRepository
    {

        private UsersContext _db;
        public UsersRepository(UsersContext context)
        {
            _db = context;
        }
        public async Task create(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }

        public bool Exsists(int key)
        {
            IQueryable foundUsers = _db.Users.Where(p => p.Id == key);
            if (foundUsers == null) return false;
            else return true;
        }
    }
}
