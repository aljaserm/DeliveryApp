using Foundation;
using System;
using UIKit;

namespace DeliveryPersonApp.IOS
{
    public partial class MainTabBarController : UITabBarController
    {
        public string UserId;
        public MainTabBarController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidAppear(bool animated)
        {
            
            base.ViewDidAppear(animated);
            NavigationItem.SetHidesBackButton(true,false);
            var deliveringVC = ViewControllers[0] as DeliveringTableViewController;
            deliveringVC.UserId = UserId;
            var WaitingVC =ViewControllers[1] as WaitingTableViewController;
            WaitingVC.UserId = UserId;
            var deliveredVC = ViewControllers[2] as DeliveredTableViewController;
            deliveredVC.UserId = UserId;
        }
    }
}