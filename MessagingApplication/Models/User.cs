using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingApplication.Validator;

namespace MessagingApplication.Models
{
    public class User
    {
       
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _username;
		private string _password;

        public User(string username, string password, string email, string firstName, string lastName)
        {
            Username = username;
            Password = password;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }

        public Guid Id { get; }                     
        public DateTime CreatedDate { get; }

        public string Username
        {
            get => _username;
            set
            {
                _username = Validator.Validator.ValidateUsername(value);
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = Validator.Validator.ValidatePassword(value);
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = Validator.Validator.ValidateEmail(value);
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = Validator.Validator.ValidateName(value);
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = Validator.Validator.ValidateLastname(value);
            }
        }

        public override string ToString()
        {
            return $"[{Id}] {FirstName} {LastName} - {Username} - {Email} - {CreatedDate}";
        }

    }
}
