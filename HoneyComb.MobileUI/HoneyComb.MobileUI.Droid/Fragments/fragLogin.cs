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
using Android.Graphics.Drawables;
using HoneyComb.BusinessObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HoneyComb.MobileUI.Droid.Fragments
{
    public class fragLogin : Android.Support.V4.App.Fragment, IServiceDeletegate<object>
    {
        MainActivity _mainActivity;
        TextView _txtAppVersionView;
        EditText _txtUserNameView;
        EditText _txtPasswordView;
        Button _btnLoginView;
        ProgressBar _progressBarView;
        HoneyCombService _service;
        TextView _txtErroView;
        private MCR_PERSONS _user;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _mainActivity = (MainActivity)this.Activity;

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
           // Dialog.SetCancelable(false);
            View view = inflater.Inflate(Resource.Layout.uiLogin, container, false);
            _txtAppVersionView = view.FindViewById<TextView>(Resource.Id.txtAppVersion);
            _txtUserNameView = view.FindViewById<EditText>(Resource.Id.txtUsername);
            _txtPasswordView = view.FindViewById<EditText>(Resource.Id.txtPassword);
            _txtErroView = view.FindViewById<TextView>(Resource.Id.lblError);
            _txtErroView.Visibility = ViewStates.Gone;

            _progressBarView = view.FindViewById<ProgressBar>(Resource.Id.progressBar);
            _btnLoginView = view.FindViewById<Button>(Resource.Id.btnLogin);
            _btnLoginView.Click += _btnLoginView_Click;


            return view;
        }

        private void _btnLoginView_Click(object sender, EventArgs e)
        {
            //var trans = FragmentManager.BeginTransaction();
            //trans.Replace(Resource.Id.fragmentContainer, new fragHome(), "home");
            //trans.Commit();

            Drawable errorIcon = Resources.GetDrawable(Resource.Drawable.Attention);

            if (_txtUserNameView.Text == string.Empty)
            {
                _txtUserNameView.SetError("Required!", errorIcon);
                _txtUserNameView.RequestFocus();
                return;
            }
            if (_txtPasswordView.Text == string.Empty)
            {
                _txtPasswordView.SetError("Required!", errorIcon);
                _txtPasswordView.RequestFocus();
                return;
            }

            GetAction action = Config.GetActions.Where(o => o.Code == ActionCodeType.Login).SingleOrDefault();

            if (action == null)
                throw new Exception(Config.ErrMissingAction);

            object[] param = new[] { _txtUserNameView.Text, _txtPasswordView.Text };

            _service = new Services.HoneyCombService();
            _progressBarView.Visibility = ViewStates.Visible;
            _service.GetObject(this, action, param);


        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            var versionName = Context.PackageManager.GetPackageInfo(Context.PackageName, 0).VersionName;
            _txtAppVersionView.Text = "V " + versionName;
        }

        public void HandleServiceResults(object resultRootObject, bool isSuccessfull, string message)
        {
            _mainActivity = (MainActivity)this.Activity;
            _user = new MCR_PERSONS();

            if (resultRootObject != null)
            {
                JsonSerializerSettings serSettings = new JsonSerializerSettings();
                serSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                var resultObj = JsonConvert.DeserializeObject<ResultObj<MCR_PERSONS>>(resultRootObject.ToString(), serSettings);

                if (resultObj.isSuccessful)
                {
                    _user = JsonConvert.DeserializeObject<ResultObj<MCR_PERSONS>>(resultRootObject.ToString(), serSettings).Data;

                    if (_user!=null)
                    {
                        _mainActivity.RunOnUiThread(() =>
                        {
                            var trans = FragmentManager.BeginTransaction();
                            trans.Replace(Resource.Id.fragmentContainer, new fragClassView(), "classview");
                            trans.Commit();

                            _mainActivity.ShowSideMenu(false);
                            _progressBarView.Visibility = ViewStates.Gone;
                        });
                    }
                }
                else
                {
                    _mainActivity.RunOnUiThread(() =>
                    {
                        _progressBarView.Visibility = ViewStates.Gone;
                        _txtErroView.Visibility = ViewStates.Visible;
                        _txtErroView.Text = resultObj.Error;
                    });
                }
            }
            else
            {
                _mainActivity.RunOnUiThread(() =>
                {
                    _progressBarView.Visibility = ViewStates.Gone;
                    _txtErroView.Text = Config.ErrServiceCallError;
                });
            }
        }

    }
}