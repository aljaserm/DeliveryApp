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
        public string UserId;
        public DeliveringTableViewController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            deliveries = new List<Delivery>();
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return deliveries.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("DeliveringCell");
            var delivery = deliveries[indexPath.Row];
            cell.TextLabel.Text = delivery.Name;
            cell.DetailTextLabel.Text = $"{delivery.DestLat}, {delivery.DestLong}";
            return cell;
        }
        public override async void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            deliveries = await Delivery.GetOnTheWayDelivery(UserId);
            TableView.ReloadData();
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