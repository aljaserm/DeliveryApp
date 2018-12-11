using DeliveryApp.Model;
using Foundation;
using System;
using UIKit;

namespace DeliveryApp.IOS
{
    public partial class NewDeliveryVewController : UIViewController
    {
        public NewDeliveryVewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            bbtnSave.Clicked += BbtnSave_Clicked;
        }

        private async void BbtnSave_Clicked(object sender, EventArgs e)
        {
            Delivery delivery = new Delivery()
            {
                Name = tfPackageName.Text,
                Status = 0
            };
            await Delivery.InsertDelivery(delivery);
        }
    }
}