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
                string username = UsernameText.Text;
                string password = PasswordText.Text;

                if (AppDelegate.sqlHandler.GetLogin(username, password))
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