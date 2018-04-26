using Foundation;
using System;
using UIKit;
using System.Data;

namespace PlanA
{
    public partial class DisplayEventController : UIViewController
    {
        public string EventID { get; set; }

        public string[] EventInfo { get; set; }

        public DisplayEventController (IntPtr handle) : base (handle)
        {
        }

        partial void JoinButton_TouchUpInside(UIButton sender)
        {
            if (AppDelegate.sqlHandler.joinEvent(EventID))
            {
                JoinErrorLabel.Hidden = true;
                JoinedLabel.Hidden = false;
            }
            else
            {
                JoinErrorLabel.Hidden = false;
            }
        }

        partial void CloseButton_TouchUpInside(UIButton sender)
        {
            if(AppDelegate.sqlHandler.closeEvent(EventID, AppDelegate.username))
            {
                AppDelegate.sqlHandler.chooseBestTime(EventID);
                this.NavigationController.PopViewController(true);
            }
            else
            {
                CloseLabel.Hidden = false;
            }
        }

        partial void VoteButton_TouchUpInside(UIButton sender)
        {
            UIStoryboard board = this.Storyboard;

            var timeTable = (TimesListController)board.InstantiateViewController("TimesListController");
            timeTable.EventID = EventID;

            this.NavigationController.PushViewController(timeTable, true);
        }

        public override void ViewDidLoad()
        {
            EventNameLabel.Text = EventInfo[2];
            UsernameLabel.Text = EventInfo[0];
            DescriptionLabel.Text = EventInfo[3];
            LocationLabel.Text = EventInfo[4];
        }
    }
}