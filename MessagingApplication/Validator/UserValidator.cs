using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MessagingApplication.Validator
{
    public static partial class Validator
    {
        public static string ValidateUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username boş olamaz");

            username = username.Trim().ToLower();
            username = (username.Length > 20) ? username.Substring(0, 20) : (username.Length < 3) ? username = username.PadLeft(3, '*') : username;

            return username;
        }

        public static string ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password boş olamaz");

            password = password.Trim();

            if (password.Length < 8)
            {
                var random = new Random();
                while (password.Length < 8)
                {
                    password += (char)random.Next(128);
                }
            }

            return password;
        }

        public static string ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email boş olamaz");

            email = email.Trim();

            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, emailPattern))
                throw new ArgumentException("Geçersiz e-posta formatı");

            return email;
        }

        public static string ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"isim boş olamaz");

            return name;
        }

        public static string ValidateLastname(string lastname)
        {
            if (string.IsNullOrWhiteSpace(lastname))
                throw new ArgumentException($"soyisim boş olamaz");

            return lastname;
        }
    }
}
