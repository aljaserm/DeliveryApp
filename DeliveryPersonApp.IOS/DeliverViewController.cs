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
    }
}