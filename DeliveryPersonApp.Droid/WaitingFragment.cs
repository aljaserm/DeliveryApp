using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using DeliveryApp.Model;

namespace DeliveryPersonApp.Droid
{
    public class WaitingFragment : global::Android.Support.V4.App.ListFragment
    {
        List<Delivery> deliveries;
        public async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            deliveries = new List<Delivery>();
            deliveries = await Delivery.GetWaitingForDelivery();
            ListAdapter = new ArrayAdapter(Activity, global::Android.Resource.Layout.SimpleListItem1, deliveries);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return base.OnCreateView(inflater, container, savedInstanceState);
        }
        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
            var selected = deliveries[position];
            var UserId = (Activity as TabsActivity).UserId;
            Intent intent = new Intent(Activity, typeof(PickUpActivity));
            intent.PutExtra("latitude", selected.OrginLat);
            intent.PutExtra("longitude", selected.OrginLong);
            intent.PutExtra("UserId", UserId);
            intent.PutExtra("DeliveryId", selected.Id);
            StartActivity(intent);
        }
    }
}