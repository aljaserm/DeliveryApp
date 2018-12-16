using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using DeliveryApp.Model;
using Android.Content;

namespace DeliveryPersonApp.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText etEmail, etPassword;
        Button btnSignIn, btnSignUp;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
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
            var email = etEmail.Text;
            var pass = etPassword.Text;
            var userId = await DeliveryPerson.Login(email, pass);
            if (!string.IsNullOrEmpty(userId))
            {
                Toast.MakeText(this, "User login", ToastLength.Long).Show();
                Intent intent = new Intent(this, typeof(TabsActivity));
                intent.PutExtra("UserId",userId);
                StartActivity(intent);
                Finish();
            }
            else
            {
                Toast.MakeText(this, "incorrect email or password", ToastLength.Long).Show();
            }
        }

        private void BtnSignUp_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(SignUpActivity));
            intent.PutExtra("email", etEmail.Text);
            StartActivity(intent);
        }
    }
}