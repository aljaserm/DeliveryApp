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
            if(!string.IsNullOrEmpty(tfPassword.Text))
            {
                if (tfPassword.Text == tfConfirmPassword.Text)
                {
                    User user = new User()
                    {
                        Email = tfEmail.Text,
                        Password = tfPassword.Text
                    };
                    await AppDelegate.mobile.GetTable<User>().InsertAsync(user);
                    alert = UIAlertController.Create("Success", "User Added", UIAlertControllerStyle.Alert);
                    alert.AddAction(UIAlertAction.Create("OK",UIAlertActionStyle.Default,null));
                    PresentViewController(alert,true,null);
                    return;
                }
                else
                {
                    alert= UIAlertController.Create("Wrong", "Password not match", UIAlertControllerStyle.Alert);
                    alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                }
            }
            else
            {
                alert = UIAlertController.Create("Wrong", "Password can't be empty", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
            }
            PresentViewController(alert, true, null);

        }
    }
}