using MessagingApplication.Extensions;
using MessagingApplication.Interfaces;
using MessagingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApplication.Services
{
    public class MessageService
    {
        private IMessageRepository _repository;

        public MessageService(IMessageRepository repository)
        {
            _repository = repository;
        }

        public void SendMessage(Guid senderId, Guid recieverId, string content)
        {
            senderId.ValidateNotEmpty();
            recieverId.ValidateNotEmpty();

            var message = new Message(content, senderId, recieverId);
            _repository.Add(message);
        }

        public List<Message> GetMessages(Guid senderId, Guid receiverId)
        {
            var messages = _repository.GetAll()
                .Where(m => (m.SenderId == senderId && m.ReceiverId == receiverId) ||
                            (m.SenderId == receiverId && m.ReceiverId == senderId))
                .OrderBy(m => m.CreatedDate)
                .ToList();

            return messages;
        }
    }
}
