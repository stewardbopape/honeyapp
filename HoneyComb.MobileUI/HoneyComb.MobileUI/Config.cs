using HoneyComb.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyComb.MobileUI
{
    public static class Config
    {
        // -- NETWORK ERROR CONSTANTS -- //
        public static string ErrNetworkError = "Unable to connect";
        public static string ErrServiceCallError = "Service call was not successful";
        public static string ErrMissingAction = "Invalid or missing action code ";
        public static string BASE_SERVICE_URL = "http://10.0.2.2/honeycomb/api/";
        public static List<GetAction> GetActions;
        public static List<PostAction> PostActions;

        static Config()
        {
            GetActions = new List<GetAction>();
            GetActions.Add(new GetAction() { Code = ActionCodeType.Login, Url = @"user/login/" });
        }
    }

    public static class CurrentLocation
    {
        private static double _lat, _long;
        public static double Latitude
        {
            get { return _lat; }
            set { _lat = value; }
        }
        public static double Longitude
        {
            get { return _long; }
            set { _long = value; }
        }
    }
}
