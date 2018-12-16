using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DeliveryApp.Model;

namespace DeliveryPersonApp.Droid
{
    [Activity(Label = "DeliverActivity")]
    public class DeliverActivity : Activity
    {
        Button btnDelivere;
        MapFragment mapFragment;
        double lat, lng;
        string deliveryId;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Deliver);
            mapFragment = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.mpfrgDeliver);
            btnDelivere = FindViewById<Button>(Resource.Id.btnDeliver);
            btnDelivere.Click += BtnDelivere_Click;

            lat = Intent.GetDoubleExtra("latitude",0);
            lng = Intent.GetDoubleExtra("longitude",0);
            deliveryId = Intent.GetStringExtra("DeliveryId");
            
        }

        private async void BtnDelivere_Click(object sender, EventArgs e)
        {
            await Delivery.DeliveredPackage(deliveryId);
        }
    }
}