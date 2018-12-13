using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Android.Gms.Maps;
using Android.Locations;
using Android.Gms.Maps.Model;
using DeliveryApp.Model;

namespace DeliveryApp.Droid
{
    [Activity(Label = "NewDeliveryActivity")]
    public class NewDeliveryActivity : Activity, IOnMapReadyCallback, ILocationListener
    {
        Button btnSave;
        EditText etPackageName;
        MapFragment frgMap;
        MapFragment frgMapDest;
        double latitude,longitude;
        LocationManager locationManager;

        public void OnLocationChanged(Location location)
        {
            latitude = location.Latitude;
            longitude = location.Longitude;
            frgMap.GetMapAsync(this);
            frgMapDest.GetMapAsync(this);
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            MarkerOptions markerOptions = new MarkerOptions();
            markerOptions.SetPosition(new LatLng(latitude,longitude));
            markerOptions.SetTitle("Your Location");
            googleMap.AddMarker(markerOptions);
            googleMap.MoveCamera(CameraUpdateFactory.NewLatLngZoom(new LatLng(latitude,longitude), 10));
        }

        public void OnProviderDisabled(string provider)
        {
            
        }

        public void OnProviderEnabled(string provider)
        {
            
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NewDelivery);
            btnSave = FindViewById<Button>(Resource.Id.btnSave);
            etPackageName = FindViewById<EditText>(Resource.Id.etPackageName);
            frgMap = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.frgMap);
            frgMapDest = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.frgMapDest);
            //frgMap.GetMapAsync(this);

            btnSave.Click += BtnSave_Click;
        }

        protected override void OnResume()
        {
            base.OnResume();
            locationManager = GetSystemService(Context.LocationService) as LocationManager;
            string provider = LocationManager.GpsProvider;
            if (locationManager.IsProviderEnabled(provider))
            {
                locationManager.RequestLocationUpdates(provider, 5000, 1, this);
            }

            var location = locationManager.GetLastKnownLocation(LocationManager.NetworkProvider);
            latitude = location.Latitude;
            longitude = location.Longitude;
            frgMap.GetMapAsync(this);
            frgMapDest.GetMapAsync(this);
        }

        protected override void OnPause()
        {
            base.OnPause();
            locationManager.RemoveUpdates(this);
        }
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            var orginLocation = frgMap.Map.CameraPosition.Target;
            var DestLocation = frgMapDest.Map.CameraPosition.Target;

            Delivery delivery = new Delivery()
            {
                Name = etPackageName.Text,
                Status = 0,
                OrginLat=orginLocation.Latitude,
                DestLat=DestLocation.Latitude,
                OrginLong=orginLocation.Longitude,
                DestLong=DestLocation.Longitude
            };
            await Delivery.InsertDelivery(delivery);
        }
    }
}