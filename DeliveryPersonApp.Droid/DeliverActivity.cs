using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DeliveryApp.Model;

namespace DeliveryPersonApp.Droid
{
    [Activity(Label = "DeliverActivity")]
    public class DeliverActivity : Activity,IOnMapReadyCallback
    {
        Button btnDelivere;
        MapFragment mapFragment;
        double lat, lng;
        string deliveryId;

        public void OnMapReady(GoogleMap googleMap)
        {
            MarkerOptions marker = new MarkerOptions();
            marker.SetPosition(new LatLng(lat, lng));
            marker.SetTitle("Package Drop");
            googleMap.AddMarker(marker);

            googleMap.MoveCamera(CameraUpdateFactory.NewLatLngZoom(new LatLng(lat, lng), 12));
        }

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
            mapFragment.GetMapAsync(this);
        }

        private async void BtnDelivere_Click(object sender, EventArgs e)
        {
            await Delivery.DeliveredPackage(deliveryId);
        }
    }
}