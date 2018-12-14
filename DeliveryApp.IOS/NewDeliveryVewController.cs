using CoreLocation;
using DeliveryApp.Model;
using Foundation;
using MapKit;
using System;
using UIKit;

namespace DeliveryApp.IOS
{
    public partial class NewDeliveryVewController : UIViewController
    {
        CLLocationManager locationManager;
        public NewDeliveryVewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            locationManager = new CLLocationManager();
            locationManager.RequestWhenInUseAuthorization();
            mvOrgin.ShowsUserLocation = true;
            mvDest.ShowsUserLocation = true;
            mvOrgin.DidUpdateUserLocation += MvOrgin_DidUpdateUserLocation;
            mvDest.DidUpdateUserLocation += MvDest_DidUpdateUserLocation;

            bbtnSave.Clicked += BbtnSave_Clicked;
        }

        private void MvDest_DidUpdateUserLocation(object sender, MapKit.MKUserLocationEventArgs e)
        {
            if (mvDest.UserLocation != null)
            {
                var cordinate = mvDest.UserLocation.Coordinate;
                var span = new MKCoordinateSpan(0.15, 0.15);
                mvDest.Region = new MKCoordinateRegion(cordinate, span);
                mvDest.RemoveAnnotations();
                mvDest.AddAnnotation(new MKPointAnnotation() {
                    Coordinate = cordinate,
                    Title = "Packege Location"
                });
            }
        }

        private void MvOrgin_DidUpdateUserLocation(object sender, MapKit.MKUserLocationEventArgs e)
        {
            if (mvOrgin.UserLocation != null)
            {
                var cordinate = mvOrgin.UserLocation.Coordinate;
                var span = new MKCoordinateSpan(0.15,0.15);
                mvOrgin.Region = new MKCoordinateRegion(cordinate,span);
                mvOrgin.RemoveAnnotations();
                mvOrgin.AddAnnotation(new MKPointAnnotation()
                {
                    Coordinate = cordinate,
                    Title = "Your Location"
                });
            }
        }

        private async void BbtnSave_Clicked(object sender, EventArgs e)
        {
            var orgin = mvOrgin.CenterCoordinate;
            var dest = mvDest.CenterCoordinate;
            Delivery delivery = new Delivery()
            {
                Name = tfPackageName.Text,
                Status = 0,
                OrginLat=orgin.Latitude,
                OrginLong=orgin.Longitude,
                DestLat=dest.Latitude,
                DestLong=dest.Longitude

            };
            await Delivery.InsertDelivery(delivery);
        }
    }
}