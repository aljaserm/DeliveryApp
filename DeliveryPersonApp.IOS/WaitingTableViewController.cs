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
        public string UserId;
        public WaitingTableViewController (IntPtr handle) : base (handle)
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
            var cell = tableView.DequeueReusableCell("WaitingCell");
            var delivery = deliveries[indexPath.Row];
            cell.TextLabel.Text = delivery.Name;
            cell.DetailTextLabel.Text = $"{delivery.OrginLat}, {delivery.OrginLong}";
            return cell;
        }
        public override async void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            deliveries = await Delivery.GetWaitingForDelivery();
            TableView.ReloadData();
        }
        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "sgePickUp")
            {
                var selected = TableView.IndexPathForSelectedRow;
                var destinationViewController = segue.DestinationViewController as PickUpViewController;
                destinationViewController.delivery = deliveries[selected.Row];
                destinationViewController.UserId = UserId;
            }
            base.PrepareForSegue(segue, sender);
        }
    }
}