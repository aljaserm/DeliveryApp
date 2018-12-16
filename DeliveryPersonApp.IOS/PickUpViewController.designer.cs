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

namespace DeliveryPersonApp.IOS
{
    [Register ("PickUpViewController")]
    partial class PickUpViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnBarItemPickUp { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnBarItemPickUp != null) {
                btnBarItemPickUp.Dispose ();
                btnBarItemPickUp = null;
            }
        }
    }
}