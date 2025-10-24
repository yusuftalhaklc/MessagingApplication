using MessagingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApplication.Database
{
    public static class Database
    {
        public static List<User> Users { get; } = new List<User>()
         {
            new User("yusuftalhaklc", "yusuf123", "yusuftalhaklc@gmail.com", "Yusuf Talha", "Kılıç"),
            new User("hakanshn", "hakan123", "hakan@gmail.com", "Hakan", "Şahin"),
            new User("fatihalkan", "fatih123", "fatih@gmail.com", "Fatih", "Alkan")
        };
        public static List<Message> Messages { get; } = new List<Message>();
    }
}
