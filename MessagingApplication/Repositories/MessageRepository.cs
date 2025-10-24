using MessagingApplication.Interfaces;
using MessagingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApplication.Repositories
{
    internal class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository() : base(Database.Database.Messages)
        {
        }
    }
}
