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

namespace DeliveryApp.Droid
{
    [Activity(Label = "NewDeliveryActivity")]
    public class NewDeliveryActivity : Activity
    {
        Button btnSave;
        EditText etPackageName;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NewDelivery);
            btnSave = FindViewById<Button>(Resource.Id.btnSave);
            etPackageName = FindViewById<EditText>(Resource.Id.etPackageName);

            btnSave.Click += BtnSave_Click;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            Delivery delivery = new Delivery()
            {
                Name = etPackageName.Text,
                Status = 0
            };
            await Delivery.InsertDelivery(delivery);
        }
    }
}