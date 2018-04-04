using System.Collections.Generic;

namespace PlanA
{
    public class User
    {
        string First { get; set; }
        string Last { get; set; }
        string Username { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        IList<User> Friends;
        IList<User> AddedBy;
        IList<Event> CreatedEvents;
        IList<Event> JoinedEvents;

        public void AddFriend(User friend)
        {
            Friends.Add(friend);
        }

        public void AddAddedBy(User adder)
        {
            AddedBy.Add(adder);
        }

        public void AddCreatedEvent(Event ce)
        {
            CreatedEvents.Add(ce);
        }

        public void AddJoinedEvent(Event je)
        {
            JoinedEvents.Add(je);
        }

        public bool RemoveFriend(User friend)
        {
            return Friends.Remove(friend);
        }

        public bool RemoveAddedBy(User adder)
        {
            return AddedBy.Remove(adder);
        }

        public bool RemoveCreatedEvent(Event ce)
        {
            return CreatedEvents.Remove(ce);
        }

        public bool RemoveJoinedEvent(Event je)
        {
            return JoinedEvents.Remove(je);
        }
    }
}
