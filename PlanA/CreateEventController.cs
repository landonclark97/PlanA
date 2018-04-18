using Foundation;
using System;
using UIKit;

namespace PlanA
{
    public partial class CreateEventController : UIViewController
    {
        public CreateEventController (IntPtr handle) : base (handle)
        {
        }

        partial void SubmitEventButton_TouchUpInside(UIButton sender)
        {
        }

        public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
        {
            if (segueIdentifier == "CEtoHome")
            {
                var en = EventNameText.Text;
                var des = DescriptionText.Text;
                var loc = LocationText.Text;
                var dts = DatesText.Text;
  

                if (AppDelegate.sqlHandler.createEvent(AppDelegate.username, en, des, loc, dts))
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