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
    [Register ("DeliveredViewController")]
    partial class DeliveredViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITabBarItem Delivered { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Delivered != null) {
                Delivered.Dispose ();
                Delivered = null;
            }
        }
    }
}