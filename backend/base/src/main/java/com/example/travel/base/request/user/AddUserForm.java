package com.example.travel.base.request.user;

import lombok.Data;

@Data
public class AddUserForm {
    private String username;
    private String password;
    private String email;
}
