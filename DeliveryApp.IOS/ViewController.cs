using Foundation;
using System;
using System.Linq;
using UIKit;

namespace DeliveryApp.IOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            btnLogin.TouchUpInside += btnSignIn_TouchUpInside;
            // Perform any additional setup after loading the view, typically from a nib.
        }

        private async void btnSignIn_TouchUpInside(object sender, EventArgs e)
        {
            var email = tfEmail.Text;
            var pass = tfPassword.Text;
            UIAlertController alert = null;
            if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(pass))
            {
                var user = (await AppDelegate.mobile.GetTable<User>().Where(u => u.Email == email).ToListAsync()).FirstOrDefault();
                if (user.Password == pass)
                {
                    alert = UIAlertController.Create("Success", "User login", UIAlertControllerStyle.Alert);
                    alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                }
                else
                {
                    alert = UIAlertController.Create("Wrong", "incorrect password", UIAlertControllerStyle.Alert);
                    alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                }

            }
            else
            {
                alert = UIAlertController.Create("Wrong", "Email or Password Cannot be empty", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
            }
            PresentViewController(alert, true, null);

        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            if(segue.Identifier== "sgeSignUp")
            {
                var vcDestination = segue.DestinationViewController as SignUpViewController;

                vcDestination.Email = tfEmail.Text;
            }
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}