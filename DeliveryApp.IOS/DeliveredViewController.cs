using DeliveryApp.Model;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace DeliveryApp.IOS
{
    public partial class DeliveredViewController : UITableViewController
    {
        List<Delivery> delivered;

        public DeliveredViewController (IntPtr handle) : base (handle)
        {
            delivered = new List<Delivery>();
        }

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();
            delivered = await Delivery.GetDelivered();
            TableView.ReloadData();
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return delivered.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("DeliveredCell") as VCDeliveriedTable;
            var deliveried = delivered[indexPath.Row];
            cell.lblName.Text = deliveried.Name;
            cell.lblCordinator.Text = $"{deliveried.DestLat},{deliveried.DestLong}";
            switch (deliveried.Status)
            {
                case 0:
                    cell.LblStatus.Text = "Waiting for Pickup";
                    break;
                case 1:
                    cell.LblStatus.Text = "On The Way";
                    break;
                case 2:
                    cell.LblStatus.Text = "Delivered";
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