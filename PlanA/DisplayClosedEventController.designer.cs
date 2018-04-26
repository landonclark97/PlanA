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
    [Register ("DisplayClosedEventController")]
    partial class DisplayClosedEventController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DescriptionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel EventNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel JoinedUsersLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LocationLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TimeLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UsernameLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DescriptionLabel != null) {
                DescriptionLabel.Dispose ();
                DescriptionLabel = null;
            }

            if (EventNameLabel != null) {
                EventNameLabel.Dispose ();
                EventNameLabel = null;
            }

            if (JoinedUsersLabel != null) {
                JoinedUsersLabel.Dispose ();
                JoinedUsersLabel = null;
            }

            if (LocationLabel != null) {
                LocationLabel.Dispose ();
                LocationLabel = null;
            }

            if (TimeLabel != null) {
                TimeLabel.Dispose ();
                TimeLabel = null;
            }

            if (UsernameLabel != null) {
                UsernameLabel.Dispose ();
                UsernameLabel = null;
            }
        }
    }
}