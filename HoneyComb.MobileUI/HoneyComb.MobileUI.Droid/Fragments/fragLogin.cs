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
    public class fragLogin :  Android.Support.V4.App.Fragment, IServiceDeletegate<object>
    {
       

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.uiLogin, container, false);
            return view;
        }

        public void HandleServiceResults(object resultRootObject, bool isSuccessfull, string message)
        {
            throw new NotImplementedException();
        }
    }
}