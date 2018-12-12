using DeliveryApp.Model;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace DeliveryApp.IOS
{
    public partial class DeliveriesViewController : UITableViewController
    {
        List<Delivery> deliveries;
        public DeliveriesViewController (IntPtr handle) : base (handle)
        {
            deliveries = new List<Delivery>();
        }

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();
            deliveries = await Delivery.GetDleivery();
            TableView.ReloadData();
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return deliveries.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            //var cell = tableView.DequeueReusableCell("DeliveryCell");
            var cell = tableView.DequeueReusableCell("DeliveryCell") as VCDeliveryTable;
            var delivery = deliveries[indexPath.Row];
            cell.lblName.Text = delivery.Name;
            cell.lblCordinator.Text = $"{delivery.DestLat},{delivery.DestLong}";
            switch (delivery.Status)
            {
                case 0:
                    cell.lblStatus.Text = "Waiting for Pickup";
                    break;
                case 1:
                    cell.lblStatus.Text = "On The Way";
                    break;
                case 2:
                    cell.lblStatus.Text = "Delivered";
                    break;
            }

            return cell;
        }
        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 60;
        }
    }
}