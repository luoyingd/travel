package com.example.travel.base.request.user;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class AddUserForm {
    private String firstName;
    private String lastName;
    private String password;
    private String email;
}
