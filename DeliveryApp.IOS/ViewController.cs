using DeliveryApp.Model;
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
            var result = await User.Login(email, pass);
            if (result)
            {
                alert = UIAlertController.Create("Success","Welcome back",UIAlertControllerStyle.Alert);
            }
            else
            {
                alert = UIAlertController.Create("Wrong", "Can't login, Please check your information", UIAlertControllerStyle.Alert);
            }
            alert.AddAction(UIAlertAction.Create("ok",UIAlertActionStyle.Default,null));
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