using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace GoMapsCloudAPI.Models
{

    public class UsersRepository : IUsersRepository
    {

        private UsersContext _db;
        public UsersRepository(UsersContext context)
        {
            _db = context;
            initialize();
        }

        public async Task Create(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }

        public bool Exists(long key)
        {
            return (_db.Users.Find(key) is null) ? false : true;
        }

        void initialize()
        {
            var user1 = new User
            {
                user_id = 111
            };

            var user2 = new User
            {
                user_id = 222
            };

            var user3 = new User
            {
                user_id = 333
            };

            _db.Add(user1);
            _db.Add(user2);
            _db.Add(user3);
            _db.SaveChanges();
        }
    }
}
