using System.Collections.Generic;

namespace PublicApi.DTO.v1
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