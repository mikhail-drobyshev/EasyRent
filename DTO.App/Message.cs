using System.Collections.Generic;

namespace DTO.App
{
    public class Message
    {
        public Message()
        {
            
        }

        public Message(params string[] message)
        {
            Messages = message;
        }
        public IList<string> Messages { get; set; } = new List<string>();
    }
}