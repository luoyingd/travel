package com.example.travel.base.constant;

import com.amazonaws.regions.Regions;

public class Constant {
    public static final String PHOTO_KEY = "5326.png_300.png";
    public static final Regions AWS_CLIENT_REGION = Regions.AP_SOUTHEAST_2;
    public static final String AWS_BUCKET_NAME = "traveldly";
    public static final String EMAIL_TITLE_RESET_PWD = "Reset password for your travel note account";
    public static final String EMAIL_CONTENT_RESET_PWD = "Please click this link to reset your password. Note that the link will expire in 10 minutes.";
    public static final String RESET_PWD_URL = "localhost:3000/login/resetPwd";
    public static final String BASE_DIR = System.getProperty("user.dir") + "/tmp_file";
    public static final String GOOGLE_INFO_URL = "https://www.googleapis.com/oauth2/v3/userinfo?access_token=";
    public static final String GOOGLE_ADDRESS_URL = "https://maps.googleapis.com/maps/api/place/autocomplete/json?input=";
}
