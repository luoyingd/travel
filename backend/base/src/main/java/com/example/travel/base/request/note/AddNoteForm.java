package com.example.travel.base.request.note;

import lombok.Data;

import java.util.List;

@Data
public class AddNoteForm {
    private String title;
    private String category;
    private String description;
    private String addressCode;
    private String address;
    private String[] photoKeys;
}
