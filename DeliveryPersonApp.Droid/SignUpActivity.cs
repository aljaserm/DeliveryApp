using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DeliveryApp.Model;

namespace DeliveryPersonApp.Droid
{
    [Activity(Label = "SignUpActivity")]
    public class SignUpActivity : Activity
    {
        EditText etEmail, etPassword, etPasswordConfirm;
        Button btnSignUp;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SignUp);
            etEmail = FindViewById<EditText>(Resource.Id.etEmailSignUp);
            etPassword = FindViewById<EditText>(Resource.Id.etPasswordSignUp);
            etPasswordConfirm = FindViewById<EditText>(Resource.Id.etConfirmPasswordSignUp);
            btnSignUp = FindViewById<Button>(Resource.Id.btnSignUpSignUp);
            btnSignUp.Click += BtnSignUp_Click;
            string Email = Intent.GetStringExtra("email");
            etEmail.Text = Email;
            string Password = Intent.GetStringExtra("password");
            etPassword.Text = Password;
        }

        private async void BtnSignUp_Click(object sender, EventArgs e)
        {
            var result = await DeliveryPerson.SignUp(etEmail.Text, etPassword.Text, etPasswordConfirm.Text);
            if (result)
            {
                Toast.MakeText(this, "User Added", ToastLength.Long).Show();
                Intent intentMainActivity = new Intent(this, typeof(MainActivity));
                intentMainActivity.PutExtra("email", etEmail.Text);
                intentMainActivity.PutExtra("password", etPassword.Text);
                StartActivity(intentMainActivity);
                Finish();
            }
            else
            {
                Toast.MakeText(this, "Password empty or Doesn't Match", ToastLength.Long).Show();
            }
        }
    }
}