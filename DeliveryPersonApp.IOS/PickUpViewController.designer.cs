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
        UIKit.UIBarButtonItem btnBarItemDirctition { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnBarItemPickUp { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView mvPickUp { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnBarItemDirctition != null) {
                btnBarItemDirctition.Dispose ();
                btnBarItemDirctition = null;
            }

            if (btnBarItemPickUp != null) {
                btnBarItemPickUp.Dispose ();
                btnBarItemPickUp = null;
            }

            if (mvPickUp != null) {
                mvPickUp.Dispose ();
                mvPickUp = null;
            }
        }
    }
}