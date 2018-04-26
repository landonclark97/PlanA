using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace PlanA
{
    public partial class CreateEventController : UIViewController
    {

        List<string> times = new List<string>();

        public CreateEventController (IntPtr handle) : base (handle)
        {
        }

        partial void SubmitEventButton_TouchUpInside(UIButton sender)
        {
        }

        partial void AddButton_TouchUpInside(UIKit.UIButton sender)
        {
            times.Add(DatesText.Text);
            DatesText.Text = "";
        }



		public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
        {
            if (segueIdentifier == "CEtoHome")
            {
                var en = EventNameText.Text;
                var des = DescriptionText.Text;
                var loc = LocationText.Text;
  

                if (AppDelegate.sqlHandler.createEvent(AppDelegate.username, en, des, loc, times))
                {
                    EventNameText.ResignFirstResponder();
                    DescriptionText.ResignFirstResponder();
                    LocationText.ResignFirstResponder();
                    DatesText.ResignFirstResponder();

                    return true;
                }
                else
                {
                    return false;
                }
            }

            return base.ShouldPerformSegue(segueIdentifier, sender);
        }

    }
}