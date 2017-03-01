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
using Com.Joanzapata.Pdfview.Listener;
using Com.Joanzapata.Pdfview;

namespace HoneyComb.MobileUI.Droid.Fragments
{
    public class fragPDFViewer : Android.Support.V4.App.DialogFragment, IServiceDeletegate<object>, IOnPageChangeListener
    {
       private MainActivity _mainActivity;
        private string _path;
        PDFView PDFView { get; set; }

        public fragPDFViewer(string pdfPath)
        {
            PDFPath = pdfPath;
        }
        public void HandleServiceResults(object resultRootObject, bool isSuccessfull, string message)
        {
            throw new NotImplementedException();
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            if (PDFPath != string.Empty)
                LoadDocument();
        }

        public string PDFPath
        {
            get { return _path; }
            set { _path = value; }
        }
        private void LoadDocument()
        {

            PDFView.FromAsset(PDFPath)
                .DefaultPage(1)
                .OnPageChange(this)
                .EnableDoubletap(true)
                .EnableSwipe(true)
               .ShowMinimap(false)
                .Load();
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.uiPDF, container, false);
            _mainActivity = (MainActivity)this.Activity;
            PDFView = view.FindViewById<PDFView>(Resource.Id.pdfView1);

            return view;
        }

        public void OnPageChanged(int p0, int p1)
        {
            System.Diagnostics.Debug.WriteLine("Change to Page " + p0);
        }
    }
}