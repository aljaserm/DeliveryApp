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

namespace DeliveryApp.IOS
{
    [Register ("SignUpViewController")]
    partial class SignUpViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSignUp { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tfConfirmPassword { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tfEmail { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tfPassword { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnSignUp != null) {
                btnSignUp.Dispose ();
                btnSignUp = null;
            }

            if (tfConfirmPassword != null) {
                tfConfirmPassword.Dispose ();
                tfConfirmPassword = null;
            }

            if (tfEmail != null) {
                tfEmail.Dispose ();
                tfEmail = null;
            }

            if (tfPassword != null) {
                tfPassword.Dispose ();
                tfPassword = null;
            }
        }
    }
}