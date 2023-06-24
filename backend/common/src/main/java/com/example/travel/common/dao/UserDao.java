package com.example.travel.common.dao;
import com.example.travel.base.pojo.User;
import com.example.travel.base.response.user.LoadUserInfoVO;
import com.example.travel.base.response.user.LoadUserVO;
import org.apache.ibatis.annotations.Mapper;
import org.springframework.stereotype.Repository;

import java.util.Date;
import java.util.List;

@Mapper
@Repository
public interface UserDao {
    void add(User user);

    User searchByUsernameOrEmail(String username, String email);

    void update(User user);

    LoadUserInfoVO searchUserInfoById(int userId);

}
