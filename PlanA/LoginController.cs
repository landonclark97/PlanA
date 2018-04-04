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

                    /*var username = UsernameText.Text;
                    var password = PasswordText.Text;

                    Dictionary<string, string> loginCred = new Dictionary<string, string>
                    {
                        {"username", username},
                        {"password", password}
                    };

                    string result = AppDelegate.client.POST("account", "login", loginCred).Result;

                    PasswordText.Text = result;*/
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