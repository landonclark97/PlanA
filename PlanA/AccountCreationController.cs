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
                var fn = FirstNameText.Text;
                var ln = LastNameText.Text;
                var un = NewUsernameText.Text;
                var pw = NewPasswordText.Text;
                var email = EmailText.Text;

                if (AppDelegate.sqlHandler.CreateAccount(un, pw, email, fn, ln))
                {
                    FirstNameText.ResignFirstResponder();
                    LastNameText.ResignFirstResponder();
                    NewUsernameText.ResignFirstResponder();
                    NewPasswordText.ResignFirstResponder();
                    EmailText.ResignFirstResponder();

                    return true;
                }
                else
                {
                    ErrorLabel.Hidden = false;
                    return false;
                }
            }

            return base.ShouldPerformSegue(segueIdentifier, sender);
        }
    }
}