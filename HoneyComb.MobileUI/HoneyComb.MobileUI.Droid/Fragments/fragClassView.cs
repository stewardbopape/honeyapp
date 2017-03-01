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
    public class fragClassView   : Android.Support.V4.App.Fragment, IServiceDeletegate<object>, IOnPageChangeListener
    {
    
        MainActivity _mainActivity;
        CalendarView _simpleCalendarView;
        PDFView PDFView { get; set; }

        Button _btnBookView;
        Button _btnBook2View;
        Button _btnBook3View;
        fragPDFViewer _dialog;

        public void HandleServiceResults(object resultRootObject, bool isSuccessfull, string message)
        {
            throw new NotImplementedException();
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        public void OnPageChanged(int p0, int p1)
        {
            System.Diagnostics.Debug.WriteLine("Change to Page " + p0);
        }
        private void load()
        {

            PDFView.FromAsset("Contract.pdf")
                .DefaultPage(1)
                .OnPageChange(this)
                .EnableDoubletap(true)    
                .EnableSwipe(true)            
               .ShowMinimap(false)
                .Load();

        }
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            load();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.uiClassView, container, false);

            PDFView = view.FindViewById<PDFView>(Resource.Id.pdfView1);

            _simpleCalendarView = view.FindViewById<CalendarView>(Resource.Id.simpleCalendarView); // get the reference of CalendarView
            _simpleCalendarView.FocusedMonthDateColor = Android.Graphics.Color.Red;
            _simpleCalendarView.UnfocusedMonthDateColor = Android.Graphics.Color.Blue; // set the yellow color for the dates of an unfocused month
            _simpleCalendarView.SelectedWeekBackgroundColor = Android.Graphics.Color.Red;
            _simpleCalendarView.WeekSeparatorLineColor = Android.Graphics.Color.Green; // green color for the week separator line

            _btnBookView = view.FindViewById<Button>(Resource.Id.btnBook);
            _btnBookView.Click += _btnBookView_Click;

            _btnBook2View = view.FindViewById<Button>(Resource.Id.btnBook2);

            _btnBook2View.Click += (o, e) =>
            {
                _dialog = new fragPDFViewer("Microsoft_Press_eBook_CreatingMobileAppswithXamarinForms_PDF.pdf");

                var trans = FragmentManager.BeginTransaction();
                _dialog.Show(trans, "book1");
            };
            _btnBook3View = view.FindViewById<Button>(Resource.Id.btnBook3);
            _btnBook3View.Click += (o, e) =>
            {

                _dialog = new fragPDFViewer("compressedtracemonkey_pldi_09.pdf");

                var trans = FragmentManager.BeginTransaction();
                _dialog.Show(trans, "book1");
            };

            _mainActivity = (MainActivity)this.Activity;


            _mainActivity.SetToolBarTitle("Grade 4.1 Asanda Mavuso");
            return view;
        }

        private void _btnBookView_Click(object sender, EventArgs e)
        {
            _dialog = new fragPDFViewer("Contract.pdf");

            var trans = FragmentManager.BeginTransaction();
            _dialog.Show(trans, "book1");

             
        }
    }
}