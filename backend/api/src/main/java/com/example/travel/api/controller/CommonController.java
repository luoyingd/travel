package com.example.travel.api.controller;

import com.example.travel.base.constant.Constant;
import com.example.travel.base.exception.TravelException;
import com.example.travel.base.pojo.Blog;
import com.example.travel.base.request.blog.GetBlogForm;
import com.example.travel.base.request.blog.UpdateLikeForm;
import com.example.travel.common.service.inter.BlogService;
import com.example.travel.common.service.inter.CommonService;
import com.example.travel.common.util.FileUtils;
import com.example.travel.common.util.R;
import lombok.extern.slf4j.Slf4j;
import org.springframework.http.MediaType;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;

import javax.annotation.Resource;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.OutputStream;
import java.io.UnsupportedEncodingException;
import java.util.UUID;

@RestController
@RequestMapping("/common")
@Slf4j
public class CommonController {
    @Resource
    private CommonService commonService;

    @GetMapping("/getMapResult/{input}")
    public R getMapResult(@PathVariable String input){
        return R.ok(commonService.getAddress(input));
    }

    @PostMapping("/uploadPhoto")
    public R uploadPhoto(@RequestParam(value = "file") MultipartFile multipartFile) throws IOException, TravelException {
        String filePath = FileUtils.saveFile(Constant.BASE_DIR, multipartFile);
        log.info("file path is " + filePath);
        String key = UUID.randomUUID() + filePath.substring(filePath.lastIndexOf("."));
        commonService.uploadPhoto(filePath, key);
        return R.ok(key);
    }

    @GetMapping("/photo/{key}")
    public void photo(@PathVariable String key,
                      HttpServletResponse httpServletResponse) throws TravelException {
        httpServletResponse.setContentType(MediaType.IMAGE_PNG_VALUE);
        try {
            OutputStream out = httpServletResponse.getOutputStream();
            out.write(commonService.getPhoto(key));
            out.flush();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

}
