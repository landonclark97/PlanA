﻿using System.Collections.Generic;
using System;

namespace PlanA
{
    public class Event
    {
        string Username { get; set; }
        string EventName { get; set; }
        int EventID { get; set; }
        string Location { get; set; }
        string Description { get; set; }
        List<string> Datetime { get; set; }


        /*User Creator { get; set; }
        MessageBoard Messages { get; set; }
        IList<string> Tags { get; set; }
        IList<User> Participants { get; set; }
        IList<Timeslot> Timeslots { get; set; }

        public void AddTag(string tag)
        {
            Tags.Add(tag);
        }

        public bool RemoveTag(string tag)
        {
            return Tags.Remove(tag);
        }

        public void AddParticipant(User user)
        {
            Participants.Add(user);
        }

        public bool RemoveParticipant(User user)
        {
            return Participants.Remove(user);
        }

        public void AddTimeslot(Timeslot ts)
        {
            Timeslots.Add(ts);
        }

        public bool RemoveTimeslot(Timeslot ts)
        {
            return Timeslots.Remove(ts);
        }*/
    }
}