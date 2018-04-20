using Foundation;
using System;
using UIKit;

namespace PlanA
{
    public partial class DisplayClosedEventController : UIViewController
    {
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
        }
    }
}