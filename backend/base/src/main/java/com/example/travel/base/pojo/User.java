package com.example.travel.base.pojo;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.Date;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class User {
    private int id;
    private String firstName;
    private String lastName;
    private String password;
    private String email;
    private Date createTime;
    private Date updateTime;
}
