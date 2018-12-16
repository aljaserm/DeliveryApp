using DeliveryApp.Model;
using Foundation;
using System;
using UIKit;

namespace DeliveryPersonApp.IOS
{
    public partial class SignUpViewController : UIViewController
    {
        public string Email;
        bool IsSignedUp = false;
        public SignUpViewController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            tfEmail.Text = Email;
            btnSignUp.TouchUpInside += BtnSignUp_TouchUpInside;
        }

        private async void BtnSignUp_TouchUpInside(object sender, EventArgs e)
        {
            UIAlertController alert = null;
            var result=  await DeliveryPerson.SignUp(tfEmail.Text,tfPassword.Text, tfConfirmPass.Text);
            IsSignedUp = result;
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