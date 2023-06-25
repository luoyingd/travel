package com.example.travel.base.pojo;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.Date;

@Data
public class Password {
    private int id;
    private String clientId;
    private String key;
    private String googleApi;
}
