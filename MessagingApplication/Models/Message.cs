using MessagingApplication.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApplication.Models
{
    public class Message
    {
        private string _content;
        private Guid _senderId;
        private Guid _receiverId;
        
        public Message(string content, Guid senderId, Guid receiverId)
        {
            Id = Guid.NewGuid();                          
            Content = content;                       
            SenderId = senderId;
            ReceiverId = receiverId;
            CreatedDate = DateTime.Now;
        }

        public Guid Id { get; }                   
        public DateTime CreatedDate { get; }

        public string Content
        {
            get => _content;
            set => _content = Validator.Validator.ValidateMessageContent(value);
        }

        public Guid SenderId 
        {
            get => _senderId;
            set => _senderId = value.ValidateNotEmpty();
        }
        public Guid ReceiverId
        {
            get => _receiverId;
            set => _receiverId = value.ValidateNotEmpty();
        }

        public override string ToString()
        {
            return $"[{CreatedDate}] ({SenderId} -> {ReceiverId}) : {Content}";
        }
    }
}
