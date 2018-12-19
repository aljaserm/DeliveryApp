using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using DeliveryApp.Model;
using Android.Content;
using Android.Support.V4.Hardware.Fingerprint;
using System;
using Android.Support.V4.Content;
using Android;
using Android.Preferences;

namespace DeliveryPersonApp.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText etEmail, etPassword;
        Button btnSignIn, btnSignUp;
        FingerprintManagerCompat fpm;
        global::Android.Support.V4.OS.CancellationSignal cancel;
        ISharedPreferences sharedPreferences;
        string UserId;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            fpm = FingerprintManagerCompat.From(this);
            cancel = new Android.Support.V4.OS.CancellationSignal();
            sharedPreferences = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            etEmail = FindViewById<EditText>(Resource.Id.etEmail);
            etPassword = FindViewById<EditText>(Resource.Id.etPassword);
            btnSignIn = FindViewById<Button>(Resource.Id.btnSignIn);
            btnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            btnSignIn.Click += BtnSignIn_Click;
            btnSignUp.Click += BtnSignUp_Click;
            string Email = Intent.GetStringExtra("email");
            etEmail.Text = Email;
            string Password = Intent.GetStringExtra("password");
            etPassword.Text = Password;
        }

        private async void BtnSignIn_Click(object sender, System.EventArgs e)
        {
            bool canUse=CanUseFPM();
            if (canUse)
            {
                UserFPMLogin();            
            }
            else
            {
                var email = etEmail.Text;
                var pass = etPassword.Text;
                UserId = await DeliveryPerson.Login(email, pass);
                if (!string.IsNullOrEmpty(UserId))
                {
                    try
                    {
                        var editPreference = sharedPreferences.Edit();
                        editPreference.PutString("UserID", UserId);
                        editPreference.Apply();
        

                    }
                    catch(Exception ex)
                    {
                        Toast.MakeText(this, ex.ToString(), ToastLength.Long).Show();
                    }
                    Toast.MakeText(this, "User login", ToastLength.Long).Show();
                    Intent intent = new Intent(this, typeof(TabsActivity));
                    intent.PutExtra("UserId", UserId);
                    StartActivity(intent);
                    Finish();
                }
                else
                {
                    Toast.MakeText(this, "incorrect email or password", ToastLength.Long).Show();
                }
            }
          
        }

        private void UserFPMLogin()
        {
            var cancel = new global::Android.Support.V4.OS.CancellationSignal();
            FingerprintManagerCompat.AuthenticationCallback authentication = new AuthenticationCallback(this,UserId);
            Toast.MakeText(this, "Place fingerprint on sensor", ToastLength.Long).Show();
            fpm.Authenticate(null,0,cancel, authentication, null);
        }


        private bool CanUseFPM()
        {
            UserId = sharedPreferences.GetString("UserID",string.Empty);
            if (!string.IsNullOrEmpty(UserId))
            {
                if (fpm.IsHardwareDetected)
                {
                    if (fpm.HasEnrolledFingerprints)
                    {
                        var PermissionFPM = ContextCompat.CheckSelfPermission(this, Manifest.Permission.UseFingerprint);
                        if (PermissionFPM == global::Android.Content.PM.Permission.Granted)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
           
            return false;

        }

        private void BtnSignUp_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(SignUpActivity));
            intent.PutExtra("email", etEmail.Text);
            StartActivity(intent);
        }
    }

    class AuthenticationCallback : FingerprintManagerCompat.AuthenticationCallback
    {
        Activity activity;
        string UserId;
        public AuthenticationCallback(Activity activity,string UserId)
        {
            this.activity = activity;
        }
        public override void OnAuthenticationSucceeded(FingerprintManagerCompat.AuthenticationResult result)
        {
            base.OnAuthenticationSucceeded(result);
            Intent intent = new Intent(activity, typeof(TabsActivity));
            intent.PutExtra("UserId", UserId);
            activity.StartActivity(intent);
        }

        public override void OnAuthenticationFailed()
        {
            base.OnAuthenticationFailed();
            Toast.MakeText(activity, "Failed To Read FingerPrint", ToastLength.Long).Show();
        }
    }
}