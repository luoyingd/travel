package com.example.travel.base.pojo;

import lombok.Data;

import java.util.Date;

@Data
public class Note {
    private int id;
    private int userId;
    private String content;
    private String title;
    private String category;
    private String addressCode;
    private String address;
    private Integer likes;
    private String photos;
    private Date createTime;
    private Date updateTime;
}
