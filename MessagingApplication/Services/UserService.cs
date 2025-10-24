using MessagingApplication.Interfaces;
using MessagingApplication.Models;
using MessagingApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApplication.Services
{
    public class UserService
    {
        private IUserRepository _repository;
        public User CurrentUser { get; private set; }

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Register(string username, string password, string email, string firstName, string lastName)
        {
            var user = new User(username, password, email, firstName, lastName);

            if (_repository.GetByUsername(username) != null || _repository.GetByEmail(email) != null)
            {
                throw new Exception("Bu kullanıcı adı veya email zaten kullanılıyor.");
            }

            _repository.Add(user);
            CurrentUser = user;
        }

        public void Login(string username, string password)
        {
            var user = _repository.GetByUsername(username);
            if (user == null) 
                throw new Exception("Kullanıcı adı veya şifre hatalı.");
            
            if (user.Password != password)
            {
                throw new Exception("Kullanıcı adı veya şifre hatalı.");
            }

            CurrentUser = user;
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public List<User> GetUsers()
        {
            return _repository.GetAll();
        }
    }
}
