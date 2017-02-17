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
using HoneyComb.MobileUI.Droid.Services;

namespace HoneyComb.MobileUI.Droid.Fragments
{
    public class fragHome : Android.Support.V4.App.Fragment, IServiceDeletegate<object>
    {
        MainActivity _mainActivity;
        CalendarView _simpleCalendarView;

        public void HandleServiceResults(object resultRootObject, bool isSuccessfull, string message)
        {
            throw new NotImplementedException();
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.uiMaster, container, false);

            _simpleCalendarView = view.FindViewById<CalendarView>(Resource.Id.simpleCalendarView); // get the reference of CalendarView
            _simpleCalendarView.FocusedMonthDateColor = Android.Graphics.Color.Red;
            _simpleCalendarView.UnfocusedMonthDateColor = Android.Graphics.Color.Blue; // set the yellow color for the dates of an unfocused month
            _simpleCalendarView.SelectedWeekBackgroundColor = Android.Graphics.Color.Red;
            _simpleCalendarView.WeekSeparatorLineColor= Android.Graphics.Color.Green; // green color for the week separator line

            _mainActivity = (MainActivity)this.Activity;

            _mainActivity.SetToolBarTitle("Grade 4.1 Asanda Mavuso");
            return view;
        }
    }
}