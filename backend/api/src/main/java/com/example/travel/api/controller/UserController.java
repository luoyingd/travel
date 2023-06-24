package com.example.travel.api.controller;

import com.example.travel.base.exception.TravelException;
import com.example.travel.base.pojo.User;
import com.example.travel.base.request.user.*;
import com.example.travel.base.util.R;
import com.example.travel.common.service.inter.UserService;
import lombok.extern.slf4j.Slf4j;
import org.springframework.web.bind.annotation.*;

import javax.annotation.Resource;

@RestController
@RequestMapping("/user")
@Slf4j
public class UserController {
    @Resource
    private UserService userService;

    @PostMapping("/register")
    public R register(@RequestBody AddUserForm addUserForm) throws TravelException {
        userService.add(addUserForm);
        return R.ok();
    }

    @PostMapping("/login")
    public R login(@RequestBody LoginForm loginForm) throws TravelException {
        return R.ok(userService.login(loginForm));
    }

    @PostMapping("/logout")
    public R logout(@RequestBody UserIdForm userIdForm) throws TravelException {
        userService.logout(userIdForm);
        return R.ok();
    }

    @PostMapping("/resetPwdSendMail")
    public R resetPwdSendMail(@RequestBody EmailForm emailForm) throws TravelException {
        userService.sendMailForReset(emailForm);
        return R.ok();
    }

    @PostMapping("/resetPwd")
    public R resetPwdSend(@RequestBody ResetPwdForm resetPwdForm) throws TravelException {
        userService.resetPwd(resetPwdForm);
        return R.ok();
    }

    @PutMapping("/update")
    public R update(@RequestBody User user) throws TravelException {
        userService.update(user);
        return R.ok();
    }

    @GetMapping("/getInfo")
    public R getInfo( UserIdForm userIdForm) {
        return R.ok(userService.getUserInfo(userIdForm.getUserId()));
    }

}
