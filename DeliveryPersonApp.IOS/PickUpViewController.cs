using DeliveryApp.Model;
using Foundation;
using System;
using UIKit;

namespace DeliveryPersonApp.IOS
{
    public partial class PickUpViewController : UIViewController
    {
        public Delivery delivery;
        public string UserId;
        public PickUpViewController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            btnBarItemPickUp.Clicked += BtnBarItemPickUp_Clicked;
        }

        private async void BtnBarItemPickUp_Clicked(object sender, EventArgs e)
        {
           await Delivery.PickedUpPackage(delivery,UserId);
        }
    }
}