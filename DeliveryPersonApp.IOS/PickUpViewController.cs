using CoreLocation;
using DeliveryApp.Model;
using Foundation;
using MapKit;
using System;
using UIKit;

namespace DeliveryPersonApp.IOS
{
    public partial class PickUpViewController : UIViewController
    {
        public Delivery delivery;
        public string UserId;
        CLLocationManager locationManager;
        public PickUpViewController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            btnBarItemPickUp.Clicked += BtnBarItemPickUp_Clicked;
            btnBarItemDirctition.Clicked += BtnBarItemDirctition_Clicked;
            prepareMap();
        }

        private void BtnBarItemDirctition_Clicked(object sender, EventArgs e)
        {
            var coordinate = new CLLocationCoordinate2D(delivery.OrginLat, delivery.OrginLong);
            var itemMap = new MKMapItem(new MKPlacemark(coordinate));
            itemMap.Name = "Pick Package";
            itemMap.OpenInMaps();
        }

        private void prepareMap()
        {
            locationManager = new CLLocationManager();
            locationManager.RequestWhenInUseAuthorization();
            mvPickUp.ShowsUserLocation = true;
            var span = new MKCoordinateSpan(0.15, 0.15);
            var coordinate = new CLLocationCoordinate2D(delivery.OrginLat, delivery.OrginLong);
            mvPickUp.Region = new MKCoordinateRegion(coordinate, span);
            mvPickUp.AddAnnotation(new MKPointAnnotation()
            {
                Coordinate = coordinate,
                Title = "Package Location"
            });
        }
        private async void BtnBarItemPickUp_Clicked(object sender, EventArgs e)
        {
            var haptic = new UINotificationFeedbackGenerator();
            haptic.Prepare();
           bool status=await Delivery.PickedUpPackage(delivery,UserId);
            UIAlertController alert = null;
            if (status)
            {
                haptic.NotificationOccurred(UINotificationFeedbackType.Success);
                alert = UIAlertController.Create("Sucess","Your package is picked up and on it way. Enjoy!",UIAlertControllerStyle.Alert);
            }
            else
            {
                haptic.NotificationOccurred(UINotificationFeedbackType.Error);
                alert = UIAlertController.Create("failed", "Try Again!", UIAlertControllerStyle.Alert);
            }
            alert.AddAction(UIAlertAction.Create("ok",UIAlertActionStyle.Default,null));
            PresentViewController(alert, true, null);
        }
    }
}