using Foundation;
using System;
using UIKit;
using System.Data;

namespace PlanA
{
    public partial class DisplayEventController : UIViewController
    {
        public string EventID { get; set; }

        string[] EventInfo { get; set; }

        public DisplayEventController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            EventInfo = AppDelegate.sqlHandler.getEventInfo(EventID);
            EventNameLabel.Text = EventInfo[2];
            UsernameLabel.Text = EventInfo[0];
            DescriptionLabel.Text = EventInfo[3];
        }
    }
}