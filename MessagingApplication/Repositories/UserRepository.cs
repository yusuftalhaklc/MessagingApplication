using MessagingApplication.Interfaces;
using MessagingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApplication.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        public UserRepository() : base(Database.Database.Users)
        {
        }

        public User? GetByUsername(string username)
        {
            return _list.FirstOrDefault(u => u.Username.Equals(username));
        }

        public User? GetByEmail(string email)
        {
            return _list.FirstOrDefault(u => u.Email.Equals(email));
        }

        public User? GetById(string id)
        {
            return _list.FirstOrDefault(u => u.Id.Equals(id));
        }
    }
}
