﻿using System;
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
    [Activity(Label = "PickUpActivity")]
    public class PickUpActivity : Activity,IOnMapReadyCallback
    {
        Button btnPickUp;
        MapFragment mapFragment;
        double lng, lat;
        string deliveryId, UserId;

        public void OnMapReady(GoogleMap googleMap)
        {
            MarkerOptions marker = new MarkerOptions();
            marker.SetPosition(new LatLng(lat, lng));
            marker.SetTitle("Package Location");
            googleMap.AddMarker(marker);

            googleMap.MoveCamera(CameraUpdateFactory.NewLatLngZoom(new LatLng(lat, lng), 12));
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PickUp);
            mapFragment = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.mpfrgPickUp);
            btnPickUp = FindViewById<Button>(Resource.Id.btnPickUp);

            btnPickUp.Click += BtnPickUp_Click;

            lng = Intent.GetDoubleExtra("longitude", 0);
            lat = Intent.GetDoubleExtra("latitude", 0);
            deliveryId = Intent.GetStringExtra("DeliveryId");
            UserId = Intent.GetStringExtra("UserId");
            mapFragment.GetMapAsync(this);
        }

        private async void BtnPickUp_Click(object sender, EventArgs e)
        {
            await Delivery.PickedUpPackage(deliveryId, UserId);
        }
    }
}