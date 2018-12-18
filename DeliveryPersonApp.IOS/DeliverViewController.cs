using CoreLocation;
using DeliveryApp.Model;
using Foundation;
using MapKit;
using System;
using UIKit;

namespace DeliveryPersonApp.IOS
{
    public partial class DeliverViewController : UIViewController
    {
        public Delivery delivery;
        CLLocationManager locationManager;
        public DeliverViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            btnBarItemDelever.Clicked += BtnBarItemDelever_Clicked;
            btnBarItemDirctition.Clicked += BtnBarItemDirctition_Clicked;
            prepareMap();
        }

        private void BtnBarItemDirctition_Clicked(object sender, EventArgs e)
        {
            var coordinate = new CLLocationCoordinate2D(delivery.DestLat, delivery.DestLong);
            var itemMap = new MKMapItem(new MKPlacemark(coordinate));
            itemMap.Name = "Deliver Package";
            itemMap.OpenInMaps();
        }

        private void prepareMap()
        {
            locationManager = new CLLocationManager();
            locationManager.RequestWhenInUseAuthorization();
            mvDeliver.ShowsUserLocation = true;
            var span = new MKCoordinateSpan(0.15,0.15);
            var coordinate = new CLLocationCoordinate2D(delivery.DestLat,delivery.DestLong);
            mvDeliver.Region=new MKCoordinateRegion(coordinate,span);
            mvDeliver.AddAnnotation(new MKPointAnnotation() {
                Coordinate = coordinate,
                Title = "Drop Package"
            });
        }

        private async void BtnBarItemDelever_Clicked(object sender, EventArgs e)
        {
            await Delivery.DeliveredPackage(delivery);
        }
    }
}