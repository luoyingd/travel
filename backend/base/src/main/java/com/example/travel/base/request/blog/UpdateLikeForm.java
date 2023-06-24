package com.example.travel.base.request.blog;

import lombok.Data;

@Data
public class UpdateLikeForm {
    private int blogId;
    private int userId;
    private Boolean like;
}
