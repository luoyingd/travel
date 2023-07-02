using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Constant
{
    public class Constant
    {
        public static readonly string PHOTO_KEY = "5326.png_300.png";
        // public static final Regions AWS_CLIENT_REGION = Regions.AP_SOUTHEAST_2;
        public static readonly string AWS_BUCKET_NAME = "traveldly";
        public static readonly string EMAIL_TITLE_RESET_PWD = "Reset password for your travel note account";
        public static readonly string EMAIL_CONTENT_RESET_PWD = "Please click this link to reset your password. Note that the link will expire in 10 minutes.";
        public static readonly string RESET_PWD_URL = "localhost:3000/login/resetPwd";
        // public static final string BASE_DIR = System.getProperty("user.dir") + "/tmp_file";
        public static readonly string GOOGLE_INFO_URL = "https://www.googleapis.com/oauth2/v3/userinfo?access_token=";
        public static readonly string GOOGLE_ADDRESS_URL = "https://maps.googleapis.com/maps/api/place/autocomplete/json?input=";
    }
}