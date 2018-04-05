using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using System.Threading.Tasks;

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
                if ((PasswordText.Text.Length > 0) && (UsernameText.Text.Length > 0))
                {
                    PasswordText.ResignFirstResponder();
                    UsernameText.ResignFirstResponder();

                    string username = UsernameText.Text;
                    string password = PasswordText.Text;

                    AppDelegate.sqlHandler.GetLogin(username, password);

                    return false;

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