using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;

namespace DeliveryApp.Droid
{
    [Activity(Label = "TabsActivity")]
    public class TabsActivity : Android.Support.V4.App.FragmentActivity
    {
        TabLayout tab;
        Android.Support.V7.Widget.Toolbar toolbar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Tabs);
            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.tabsToolbar);
            tab = FindViewById<TabLayout>(Resource.Id.mainTabsLayout);
            tab.TabSelected += Tab_TabSelected;

            toolbar.InflateMenu(Resource.Menu.TabsMenu);
            toolbar.MenuItemClick += Toolbar_MenuItemClick;

            FragmentNavigation(new DeliveriesFragment());
        }

        private void Toolbar_MenuItemClick(object sender, Android.Support.V7.Widget.Toolbar.MenuItemClickEventArgs e)
        {
            if (e.Item.ItemId == Resource.Id.action_add)
            {
                StartActivity(typeof(NewDeliveryActivity));
            }
        }

        private void Tab_TabSelected(object sender, TabLayout.TabSelectedEventArgs e)
        {
            switch (e.Tab.Position)
            {
                case 0:
                    FragmentNavigation(new DeliveriesFragment());
                    break;
                case 1:
                    FragmentNavigation(new DeliveredFragment());
                    break;
                case 2:
                    FragmentNavigation(new ProfileFragment());
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