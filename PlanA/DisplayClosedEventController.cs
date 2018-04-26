using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace PlanA
{
    public partial class DisplayClosedEventController : UIViewController
    {
        public List<string> JoinedUsers { get; set; }

        public string EventID { get; set; }

        public string[] EventInfo { get; set; }

        public DisplayClosedEventController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            EventNameLabel.Text = EventInfo[2];
            UsernameLabel.Text = EventInfo[0];
            DescriptionLabel.Text = EventInfo[3];
            LocationLabel.Text = EventInfo[4];
            TimeLabel.Text = EventInfo[5];
            JoinedUsersLabel.Text = "";
            JoinedUsers = AppDelegate.sqlHandler.getJoinedUsers(EventID);
            for (int i = 0; i < JoinedUsers.Count; i ++)
            {
                if (JoinedUsers[i].Equals(JoinedUsers[JoinedUsers.Count-1]))
                {
                    JoinedUsersLabel.Text += JoinedUsers[i];
                }
                else
                {
                    JoinedUsersLabel.Text += JoinedUsers[i] + ", ";
                }
            }
        }
    }
}