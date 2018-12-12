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
    [Register ("VCDeliveriedTable")]
    partial class VCDeliveriedTable
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
       public UIKit.UILabel lblCordinator { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        public UIKit.UILabel lblName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        public UIKit.UILabel LblStatus { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblCordinator != null) {
                lblCordinator.Dispose ();
                lblCordinator = null;
            }

            if (lblName != null) {
                lblName.Dispose ();
                lblName = null;
            }

            if (LblStatus != null) {
                LblStatus.Dispose ();
                LblStatus = null;
            }
        }
    }
}