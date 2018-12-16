using DeliveryApp.Model;
using Foundation;
using System;
using UIKit;

namespace DeliveryPersonApp.IOS
{
    public partial class DeliverViewController : UIViewController
    {
        public Delivery delivery;
        public DeliverViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            btnBarItemDelever.Clicked += BtnBarItemDelever_Clicked;
        }

        private async void BtnBarItemDelever_Clicked(object sender, EventArgs e)
        {
            await Delivery.DeliveredPackage(delivery);
        }
    }
}