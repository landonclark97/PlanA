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
    [Register ("DisplayEventController")]
    partial class DisplayEventController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton CloseButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CloseLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DescriptionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel EventNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton JoinButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel JoinedLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel JoinErrorLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LocationLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UsernameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton VoteButton { get; set; }

        [Action ("CloseButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CloseButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("JoinButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void JoinButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("VoteButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void VoteButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (CloseButton != null) {
                CloseButton.Dispose ();
                CloseButton = null;
            }

            if (CloseLabel != null) {
                CloseLabel.Dispose ();
                CloseLabel = null;
            }

            if (DescriptionLabel != null) {
                DescriptionLabel.Dispose ();
                DescriptionLabel = null;
            }

            if (EventNameLabel != null) {
                EventNameLabel.Dispose ();
                EventNameLabel = null;
            }

            if (JoinButton != null) {
                JoinButton.Dispose ();
                JoinButton = null;
            }

            if (JoinedLabel != null) {
                JoinedLabel.Dispose ();
                JoinedLabel = null;
            }

            if (JoinErrorLabel != null) {
                JoinErrorLabel.Dispose ();
                JoinErrorLabel = null;
            }

            if (LocationLabel != null) {
                LocationLabel.Dispose ();
                LocationLabel = null;
            }

            if (UsernameLabel != null) {
                UsernameLabel.Dispose ();
                UsernameLabel = null;
            }

            if (VoteButton != null) {
                VoteButton.Dispose ();
                VoteButton = null;
            }
        }
    }
}