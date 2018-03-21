// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace PlanA
{
    [Register ("AccountCreationController")]
    partial class AccountCreationController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CALabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton CreateButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ErrorLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField NewPasswordText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField NewRePasswordText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField NewUsernameText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel PlanATitle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ReEnterPasswordLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UsernameLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CALabel != null) {
                CALabel.Dispose ();
                CALabel = null;
            }

            if (CreateButton != null) {
                CreateButton.Dispose ();
                CreateButton = null;
            }

            if (ErrorLabel != null) {
                ErrorLabel.Dispose ();
                ErrorLabel = null;
            }

            if (NewPasswordText != null) {
                NewPasswordText.Dispose ();
                NewPasswordText = null;
            }

            if (NewRePasswordText != null) {
                NewRePasswordText.Dispose ();
                NewRePasswordText = null;
            }

            if (NewUsernameText != null) {
                NewUsernameText.Dispose ();
                NewUsernameText = null;
            }

            if (PlanATitle != null) {
                PlanATitle.Dispose ();
                PlanATitle = null;
            }

            if (ReEnterPasswordLabel != null) {
                ReEnterPasswordLabel.Dispose ();
                ReEnterPasswordLabel = null;
            }

            if (UsernameLabel != null) {
                UsernameLabel.Dispose ();
                UsernameLabel = null;
            }
        }
    }
}