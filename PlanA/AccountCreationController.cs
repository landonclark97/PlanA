using Foundation;
using System;
using UIKit;

namespace PlanA
{
    public partial class AccountCreationController : UIViewController
    {
        public AccountCreationController (IntPtr handle) : base (handle)
        {
        }

        public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
        {
            if(segueIdentifier == "SegueToLogin")
            {
                if (NewPasswordText.Text != NewRePasswordText.Text)
                {
                    ErrorLabel.Hidden = false;
                    return false;
                }
                else
                {
                    NewRePasswordText.ResignFirstResponder();
                    NewPasswordText.ResignFirstResponder();
                    NewUsernameText.ResignFirstResponder();

                    return true;
                }
            }

            return base.ShouldPerformSegue(segueIdentifier, sender);
        }
    }
}