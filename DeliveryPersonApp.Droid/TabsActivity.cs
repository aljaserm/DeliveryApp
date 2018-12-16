using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace DeliveryPersonApp.Droid
{
    [Activity(Label = "TabsActivity")]
    public class TabsActivity : FragmentActivity
    {
        TabLayout tabLayout;
        public string UserId;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Tabs);
            UserId = Intent.GetStringExtra("UserId");
            tabLayout = FindViewById<TabLayout>(Resource.Id.mainTabsLayout);
            tabLayout.TabSelected += TabLayout_TabSelected;
            FragmentNavigation(new DeliveringFragment());
        }

        private void TabLayout_TabSelected(object sender, TabLayout.TabSelectedEventArgs e)
        {
            switch (e.Tab.Position)
            {
                case 0:
                    FragmentNavigation(new DeliveringFragment());
                    break;
                case 1:
                    FragmentNavigation(new WaitingFragment());
                    break;
                case 2:
                    FragmentNavigation(new DeliveredFragment());
                    break;
            }
        }
        private void FragmentNavigation(Android.Support.V4.App.Fragment fragment)
        {
            var transactionManager = SupportFragmentManager.BeginTransaction();
            transactionManager.Replace(Resource.Id.contentFrame, fragment);
            transactionManager.Commit();
        }
    }
}