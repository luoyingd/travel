using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;

namespace backend.Constant
{
    public class Constant
    {
        public static readonly RegionEndpoint AWS_CLIENT_REGION = RegionEndpoint.APSoutheast2;
        public static readonly string AWS_BUCKET_NAME = "traveldly";
        public static readonly string EMAIL_TITLE_RESET_PWD = "Reset password for your travel note account";
        public static readonly string EMAIL_CONTENT_RESET_PWD = "Please click this link to reset your password. Note that the link will expire in 10 minutes.";
        public static readonly string BASE_DIR = System.Environment.CurrentDirectory + "/wwwroot";
        public static readonly string GOOGLE_INFO_URL = "https://www.googleapis.com/oauth2/v3/userinfo?access_token=";
        public static readonly string GOOGLE_ADDRESS_URL = "https://maps.googleapis.com/maps/api/place/autocomplete/json?input=";
        public static readonly string GOOGLE_MAP_URL = "https://maps.googleapis.com/maps/api/place/details/json?placeid=";
        public static readonly string URL = "http://3.27.172.149:9090";
        // public static readonly string URL = "http://localhost:8090";
        public static readonly string BLANK_KEY = "blank.jpg";
        public static readonly string INFO_HREF = "http://deloriatravel.net/note/info?id=";
        // public static readonly string INFO_HREF = "http://localhost:3000/note/info?id=";
    }
}