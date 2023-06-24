package com.example.travel.common.service.inter;

import com.example.travel.base.exception.TravelException;
import com.example.travel.base.pojo.User;
import com.example.travel.base.request.user.*;
import com.example.travel.base.response.user.LoadUserInfoVO;
import com.example.travel.base.response.user.LoadUserVO;
import com.example.travel.base.response.user.LoginVO;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface UserService {
    void add(AddUserForm addUserForm) throws TravelException;

    LoginVO login(LoginForm loginForm) throws TravelException;

    void logout(UserIdForm userIdForm) throws TravelException;

    void sendMailForReset(EmailForm emailForm) throws TravelException;

    void resetPwd(ResetPwdForm resetPwdForm) throws TravelException;

    LoadUserInfoVO getUserInfo(int id);

    void update(User user);
}
