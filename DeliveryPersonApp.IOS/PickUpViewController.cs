using DeliveryApp.Model;
using Foundation;
using System;
using UIKit;

namespace DeliveryPersonApp.IOS
{
    public partial class PickUpViewController : UIViewController
    {
        public Delivery delivery;
        public PickUpViewController (IntPtr handle) : base (handle)
        {
        }
    }
}