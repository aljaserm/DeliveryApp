using Foundation;
using System;
using UIKit;

namespace DeliveryApp.IOS
{
    public partial class SignUpViewController : UIViewController
    {
        public string Email;
        public SignUpViewController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            tfEmail.Text = Email;
        }

    }
}