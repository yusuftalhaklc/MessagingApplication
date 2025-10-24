using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApplication.Validator
{
    public static partial class Validator
    {
        public static string ValidateMessageContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                content = " ";

            return content;
        }
    }
}
