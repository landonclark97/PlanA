using System;
using System.Collections.Generic;

namespace PlanA
{
    public class MessageBoard
    {
        int ID;
        IList<Message> Messages { get; set; }

        public void AddMessage(Message newMessage)
        {
            Messages.Add(newMessage);
        }

        public bool RemoveMessage(Message message)
        {
            return Messages.Remove(message);
        }
    }
}
