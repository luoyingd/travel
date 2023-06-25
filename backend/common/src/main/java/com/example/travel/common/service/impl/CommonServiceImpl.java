package com.example.travel.common.service.impl;

import com.amazonaws.services.s3.model.PutObjectResult;
import com.example.travel.base.exception.TravelException;
import com.example.travel.base.exception.CodeAndMsg;
import com.example.travel.common.dao.PasswordDao;
import com.example.travel.common.util.FileUtils;
import com.example.travel.common.service.inter.CommonService;
import lombok.extern.slf4j.Slf4j;
import org.apache.commons.lang3.StringUtils;
import org.springframework.stereotype.Component;

import javax.annotation.Resource;
import java.io.File;
import java.io.IOException;

@Component
@Slf4j
public class CommonServiceImpl implements CommonService {
    @Resource
    private PasswordDao passwordDao;

    @Override
    public void uploadPhoto(String filePath, String key) throws TravelException {
        if (StringUtils.isEmpty(filePath) || StringUtils.isEmpty(key)) {
            throw new TravelException(CodeAndMsg.PARAM_VERIFICATION_FAIL);
        }
        PutObjectResult putObjectResult = FileUtils.uploadFile(key, filePath);
        if (putObjectResult == null) {
            throw new TravelException(CodeAndMsg.FILE_UPLOAD_FAIL);
        }
        File file = new File(filePath);
        boolean delete = file.delete();
        log.info("delete file: " + delete + ": " + filePath);
    }

    @Override
    public byte[] getPhoto(String key) throws TravelException, IOException {
        if (StringUtils.isEmpty(key)) {
            throw new TravelException(CodeAndMsg.PARAM_VERIFICATION_FAIL);
        }
        return FileUtils.downloadPhoto(key);
    }

    @Override
    public String getMapApi() {
        return passwordDao.getPassword().get(0).getGoogleApi();
    }

}
