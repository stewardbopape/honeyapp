using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SupportActionBarDrawerToggle = Android.Support.V7.App.ActionBarDrawerToggle;
using Android.Support.V7.App;
using Android.Support.V4.Widget;

namespace HoneyComb.MobileUI.Droid.Custom
{
    public class CustomActionBarDrawerToggle : SupportActionBarDrawerToggle
    {
        private AppCompatActivity mHostActivity;
        private int mOpenedResource;
        private int mClosedResource;
        public CustomActionBarDrawerToggle(AppCompatActivity host, DrawerLayout drawerlayout, int openedResource, int closedResource)
            : base(host, drawerlayout, openedResource, closedResource)
        {
            mHostActivity = host;
            mClosedResource = closedResource;
            mOpenedResource = openedResource;
        }

        public override void OnDrawerOpened(View drawerView)
        {
            base.OnDrawerOpened(drawerView);
            // mHostActivity.SupportActionBar.SetTitle(mOpenedResource);
        }

        public override void OnDrawerClosed(View drawerView)
        {
            base.OnDrawerClosed(drawerView);
            // mHostActivity.SupportActionBar.SetTitle(mClosedResource);
        }

        public override void OnDrawerSlide(View drawerView, float slideOffset)
        {
            base.OnDrawerSlide(drawerView, slideOffset);
        }
    }
}