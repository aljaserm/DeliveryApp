using DeliveryApp.Model;
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
            btnSignUp.TouchUpInside += btnSignUp_TouchUpInside;
        }

        private async void btnSignUp_TouchUpInside(object sender, EventArgs e)
        {
            UIAlertController alert = null;
            var result =await User.SignUp(tfEmail.Text, tfPassword.Text, tfConfirmPassword.Text);
            if (result)
            {
                alert = UIAlertController.Create("Success", "User Added", UIAlertControllerStyle.Alert);
            }
            else
            {
                alert = UIAlertController.Create("Wrong", "Password not match or empty", UIAlertControllerStyle.Alert);
            }
            alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
            PresentViewController(alert, true, null);

        }
    }
}