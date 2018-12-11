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
    [Register ("NewDeliveryVewController")]
    partial class NewDeliveryVewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem bbtnSave { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tfPackageName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (bbtnSave != null) {
                bbtnSave.Dispose ();
                bbtnSave = null;
            }

            if (tfPackageName != null) {
                tfPackageName.Dispose ();
                tfPackageName = null;
            }
        }
    }
}