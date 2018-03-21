using Foundation;
using System;
using UIKit;

namespace PlanA
{
    public partial class LoginController : UIViewController
    {

        public LoginController(IntPtr handle) : base(handle)
        {
        }

        partial void CreateAccountButton_TouchUpInside(UIButton sender)
        {
            
        }

        public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
        {

            if (segueIdentifier == "SegueToHomepage")
            {
                if ((PasswordText.Text == "password") && (UsernameText.Text == "username"))
                {
                    PasswordText.ResignFirstResponder();
                    UsernameText.ResignFirstResponder();

                    return true;
                }
                else
                {
                    ErrorLabel.Hidden = false;
                    return false;
                }
            }

            else if (segueIdentifier == "SegueToCA")
            {
                ErrorLabel.Hidden = true;
                PasswordText.ResignFirstResponder();
                UsernameText.ResignFirstResponder();
            }

            return base.ShouldPerformSegue(segueIdentifier, sender);
        }
    }
}