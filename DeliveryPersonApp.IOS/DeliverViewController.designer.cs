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
    [Register ("DeliverViewController")]
    partial class DeliverViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnBarItemDelever { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnBarItemDirctition { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView mvDeliver { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnBarItemDelever != null) {
                btnBarItemDelever.Dispose ();
                btnBarItemDelever = null;
            }

            if (btnBarItemDirctition != null) {
                btnBarItemDirctition.Dispose ();
                btnBarItemDirctition = null;
            }

            if (mvDeliver != null) {
                mvDeliver.Dispose ();
                mvDeliver = null;
            }
        }
    }
}