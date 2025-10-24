using MessagingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApplication.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public User? GetByUsername(string username);
        public User? GetById(string id);
        public User? GetByEmail(string email);
    }
}
