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

        Button _btbSub1;
        Button _btbSub2;
        Button _btbSub3;
        Button _btbSub4;
        Button _btbSub5;
        Button _btbSub6;
        Button _btbSub7;
        Button _btbSub8;
        Button _btbSub9;
        Button _btbSub10;
        Button _btbSub11;
        Button _btbSub12;
      

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

            PDFView.FromAsset("Life_Skills_Sesotho_GrR_FS.pdf")
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



            _btbSub1 = view.FindViewById<Button>(Resource.Id.btnSub1);
            _btbSub1.Click += (o, e) => { Toast.MakeText(this.Context, _btbSub1.Text + "No implementation", ToastLength.Long).Show(); };
            _btbSub2 = view.FindViewById<Button>(Resource.Id.btnSub2);
            _btbSub2.Click += (o, e) => { Toast.MakeText(this.Context, _btbSub2.Text + "No implementation", ToastLength.Long).Show(); };
            _btbSub3 = view.FindViewById<Button>(Resource.Id.btnSub3);
            _btbSub3.Click += (o, e) => { Toast.MakeText(this.Context, _btbSub3.Text + "No implementation", ToastLength.Long).Show(); };
            _btbSub4 = view.FindViewById<Button>(Resource.Id.btnSub4);
            _btbSub4.Click += (o, e) => { Toast.MakeText(this.Context, _btbSub4.Text + "No implementation", ToastLength.Long).Show(); };
            _btbSub5 = view.FindViewById<Button>(Resource.Id.btnSub5);
            _btbSub5.Click += (o, e) => { Toast.MakeText(this.Context, _btbSub5.Text + "No implementation", ToastLength.Long).Show(); };
            _btbSub6 = view.FindViewById<Button>(Resource.Id.btnSub6);
            _btbSub6.Click += (o, e) => { Toast.MakeText(this.Context, _btbSub6.Text + "No implementation", ToastLength.Long).Show(); };
            _btbSub7 = view.FindViewById<Button>(Resource.Id.btnSub7);
            _btbSub7.Click += (o, e) => { Toast.MakeText(this.Context, _btbSub7.Text + "No implementation", ToastLength.Long).Show(); };
            _btbSub8 = view.FindViewById<Button>(Resource.Id.btnSub8);
            _btbSub8.Click += (o, e) => { Toast.MakeText(this.Context, _btbSub8.Text + "No implementation", ToastLength.Long).Show(); };
            _btbSub9 = view.FindViewById<Button>(Resource.Id.btnSub9);
            _btbSub9.Click += (o, e) => { Toast.MakeText(this.Context, _btbSub9.Text + "No implementation", ToastLength.Long).Show(); };
            _btbSub10 = view.FindViewById<Button>(Resource.Id.btnSub1);
            _btbSub10.Click += (o, e) => { Toast.MakeText(this.Context, _btbSub10.Text + "No implementation", ToastLength.Long).Show(); };
            _btbSub11 = view.FindViewById<Button>(Resource.Id.btnSub11);
            _btbSub11.Click += (o, e) => { Toast.MakeText(this.Context, _btbSub11.Text + "No implementation", ToastLength.Long).Show(); };
            _btbSub12 = view.FindViewById<Button>(Resource.Id.btnSub12);
            _btbSub12.Click += (o, e) => { Toast.MakeText(this.Context, _btbSub12.Text + "No implementation", ToastLength.Long).Show(); };


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
                _dialog = new fragPDFViewer("CAPS_SAL_XITSONGA_FP.pdf");

                var trans = FragmentManager.BeginTransaction();
                _dialog.Show(trans, "book1");
            };
            _btnBook3View = view.FindViewById<Button>(Resource.Id.btnBook3);
            _btnBook3View.Click += (o, e) =>
            {

                _dialog = new fragPDFViewer("CAPS_SAL_Akrikaans_FP.pdf");

                var trans = FragmentManager.BeginTransaction();
                _dialog.Show(trans, "book1");
            };

            _mainActivity = (MainActivity)this.Activity;


            _mainActivity.SetToolBarTitle("Grade 4.1 Asanda Mavuso");
            return view;
        }

        private void _btnBookView_Click(object sender, EventArgs e)
        {
            _dialog = new fragPDFViewer("Life_Skills_Sesotho_GrR_FS.pdf");

            var trans = FragmentManager.BeginTransaction();
            _dialog.Show(trans, "book1");

             
        }
    }
}