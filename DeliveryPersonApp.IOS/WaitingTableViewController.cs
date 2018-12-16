using DeliveryApp.Model;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace DeliveryPersonApp.IOS
{
    public partial class WaitingTableViewController : UITableViewController
    {
        List<Delivery> deliveries;
        public WaitingTableViewController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            deliveries = new List<Delivery>();
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "sgePickUp")
            {
                var selected = TableView.IndexPathForSelectedRow;
                var destinationViewController = segue.DestinationViewController as PickUpViewController;
                destinationViewController.delivery = deliveries[selected.Row];
            }
            base.PrepareForSegue(segue, sender);
        }
    }
}