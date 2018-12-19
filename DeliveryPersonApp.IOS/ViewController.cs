using DeliveryApp.Model;
using Foundation;
using LocalAuthentication;
using System;
using UIKit;

namespace DeliveryPersonApp.IOS
{
    public partial class ViewController : UIViewController
    {
        bool isLogged = false;
        string UserId=string.Empty;
        //public string Email, Password;
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.
            //tfEmail.Text = Email;
            //tfPassword.Text = Password;
            btnLogin.TouchUpInside += BtnLogin_TouchUpInside;
        }

        private async void BtnLogin_TouchUpInside(object sender, EventArgs e)
        {
            
            bool hasLogged = CheckLogin();
            if (hasLogged)
            {
                BiometricAuth();
            }
            else
            {
                NormalLogin();
            }
            
            //PerformSegue("sgeLogin", this);
    
        }

        private void BiometricAuth()
        {
            NSError error;
            var contxt=new LAContext(); 
            if(contxt.CanEvaluatePolicy(LAPolicy.DeviceOwnerAuthenticationWithBiometrics,out error))
            {
                InvokeOnMainThread(async() =>
                {
                   var canLogin=await contxt.EvaluatePolicyAsync(LAPolicy.DeviceOwnerAuthenticationWithBiometrics,"Login");
                    if (canLogin.Item1)
                    {
                        isLogged = true;
                        PerformSegue("sgeLogin", this);
                    }
                    else
                    {
                        NormalLogin();
                    }
                });
            }
            else
            {
                NormalLogin();
            }
        }

        private async void NormalLogin()
        {
            UIAlertController alert = null;
            UserId = await DeliveryPerson.Login(tfEmail.Text, tfPassword.Text);
            if (!string.IsNullOrEmpty(UserId))
            {
                NSUserDefaults.StandardUserDefaults.SetString(UserId, "userId");
                NSUserDefaults.StandardUserDefaults.Synchronize();
                isLogged = true;
                PerformSegue("sgeLogin", this);
                alert = UIAlertController.Create("Success", "Welcome back", UIAlertControllerStyle.Alert);
            }
            else
            {
                alert = UIAlertController.Create("Wrong", "Can't login, Please check your information", UIAlertControllerStyle.Alert);
            }
            alert.AddAction(UIAlertAction.Create("ok", UIAlertActionStyle.Default, null));
            PresentViewController(alert, true, null);
        }

        private bool CheckLogin()
        {
            bool logged = false;
            UserId = NSUserDefaults.StandardUserDefaults.StringForKey("userId");
            if (!string.IsNullOrEmpty(UserId))
            {
                logged = true;
            }
            return logged;
        }

        public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
        {
            if (segueIdentifier== "sgeLogin")
            {
                return isLogged;
            }
            return base.ShouldPerformSegue(segueIdentifier, sender);
        }


        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if(segue.Identifier == "sgeLogin")
            {
                var destinationViewController = segue.DestinationViewController as MainTabBarController;
                destinationViewController.UserId = UserId;
            }
            if (segue.Identifier == "sgeSignUp")
            {
                var vcDestination = segue.DestinationViewController as SignUpViewController;

                vcDestination.Email = tfEmail.Text;
            }
            base.PrepareForSegue(segue, sender);
        }



        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}