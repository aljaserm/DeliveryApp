using DeliveryApp.Model;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace DeliveryPersonApp.IOS
{
    public partial class DeliveringTableViewController : UITableViewController
    {
        List<Delivery> deliveries;
        public DeliveringTableViewController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            deliveries = new List<Delivery>();
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "sgeDeliver")
            {
                var selected = TableView.IndexPathForSelectedRow;
                var destinationViewController = segue.DestinationViewController as DeliverViewController;
                destinationViewController.delivery = deliveries[selected.Row];
            }
            base.PrepareForSegue(segue, sender);

        }
    }
}