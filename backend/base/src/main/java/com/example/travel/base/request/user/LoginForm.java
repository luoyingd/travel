package com.example.travel.base.request.user;

import lombok.Data;

@Data
public class LoginForm {
    private String email;
    private String password;
    private Boolean isFromGoogle;
    private String accessToken;
}
