using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportFragment = Android.Support.V4.App.Fragment;
using Android.Support.V7.App;
using Android.Views;
using HoneyComb.MobileUI.Droid.Custom;
using System.Collections.Generic;
using HoneyComb.MobileUI.Droid.Fragments;

namespace HoneyComb.MobileUI.Droid
{
	[Activity (Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon",Theme = "@style/MyTheme", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize | Android.Content.PM.ConfigChanges.Orientation)]

    public class MainActivity : AppCompatActivity
    {
        static MainActivity ins;
        private DrawerLayout mDrawerLayout;
        private NavigationView mNavigationView;
        private CustomActionBarDrawerToggle mDrawerToggle;
        SupportFragment mCurrentFragment;
        private Stack<SupportFragment> mStackFragment;
        private SupportToolbar mToolbar;

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it

            ins = this;
            mStackFragment = new Stack<Android.Support.V4.App.Fragment>();
            mToolbar = FindViewById(Resource.Id.toolbar) as SupportToolbar;
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);


            mStackFragment = new Stack<Android.Support.V4.App.Fragment>();

            ShowSideMenu(true);


            ShowSideMenu(true);
            mNavigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            mNavigationView.NavigationItemSelected += mNavigationView_NavigationItemSelected;

            SetSupportActionBar(mToolbar);

            var trans = SupportFragmentManager.BeginTransaction();
            trans.Replace(Resource.Id.fragmentContainer, new fragLogin(), "login");
            trans.Commit();

            mDrawerToggle = new CustomActionBarDrawerToggle(
                this,
                mDrawerLayout,
                Resource.String.openedDrawer,
                Resource.String.closedDrawer);

            mDrawerLayout.AddDrawerListener(mDrawerToggle);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            mDrawerToggle.SyncState();

            SupportActionBar.Title = "PSU Upate";

        }
        public void ShowSideMenu(bool locked)
        {

            if (locked)
            {
                mToolbar.Visibility = ViewStates.Invisible;
                mDrawerLayout.SetDrawerLockMode(DrawerLayout.LockModeLockedClosed);
            }
            else
            {
                mToolbar.Visibility = ViewStates.Visible;
                mDrawerLayout.SetDrawerLockMode(DrawerLayout.LockModeUnlocked);
            }
        }

        protected override void OnResume()
        {
            base.OnResume();

        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

        }
        private void mNavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            var trans = SupportFragmentManager.BeginTransaction();
            mCurrentFragment = new fragLogin();

            if (e.MenuItem.ItemId == Resource.Id.log_out)
            {
                SupportFragmentManager.PopBackStack();
                StartActivity(typeof(MainActivity));
            }
            else
            {
                trans.SetCustomAnimations(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out, Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out);

                trans.Replace(Resource.Id.fragmentContainer, mCurrentFragment);
                trans.Commit();
                mStackFragment.Push(mCurrentFragment);
                ShowSideMenu(false);
                mDrawerLayout.CloseDrawers();
            }


        }

        public void SetToolBarTitle(string title)
        {
            SupportActionBar.Title = title;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {

            mDrawerToggle.OnOptionsItemSelected(item);


            return base.OnOptionsItemSelected(item);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.action_menu, menu);

            return base.OnCreateOptionsMenu(menu);
        }
    }
}


