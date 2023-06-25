package com.example.travel.common.dao;

import com.example.travel.base.pojo.Like;
import com.example.travel.base.pojo.Password;
import com.example.travel.base.response.blog.BlogLikeStatusRedisData;
import org.apache.ibatis.annotations.Mapper;
import org.springframework.stereotype.Repository;

import java.util.List;

@Mapper
@Repository
public interface PasswordDao {

    List<Password> getPassword();
}
