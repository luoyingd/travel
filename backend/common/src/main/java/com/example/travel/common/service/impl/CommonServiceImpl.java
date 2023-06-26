package com.example.travel.common.service.impl;

import com.alibaba.fastjson.JSON;
import com.alibaba.fastjson.JSONArray;
import com.alibaba.fastjson.JSONObject;
import com.amazonaws.services.s3.model.PutObjectResult;
import com.example.travel.base.exception.TravelException;
import com.example.travel.base.exception.CodeAndMsg;
import com.example.travel.base.response.map.MapResVO;
import com.example.travel.common.dao.PasswordDao;
import com.example.travel.common.util.FileUtils;
import com.example.travel.common.service.inter.CommonService;
import com.example.travel.common.util.HttpUtil;
import lombok.extern.slf4j.Slf4j;
import org.apache.commons.lang3.StringUtils;
import org.springframework.stereotype.Component;

import javax.annotation.Resource;
import java.io.File;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLDecoder;
import java.net.URLEncoder;
import java.nio.charset.StandardCharsets;
import java.util.ArrayList;
import java.util.List;

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

    @Override
    public List<MapResVO> getAddress(String input){
        List<MapResVO> list = new ArrayList<>();
        if (StringUtils.isEmpty(input)) {
            return list;
        }
        String encodeInput = URLEncoder.encode(input, StandardCharsets.UTF_8);
        log.info("encodeInput input: {}", encodeInput);
        String mapApi = getMapApi();
        JSONObject response = HttpUtil.doGet("https://maps.googleapis.com/maps/api/place/autocomplete/json?input=" +
                encodeInput +
                "&types=geocode&key=" + mapApi, null);
        log.info("google address response: {}", response);
        if (response != null) {
            JSONArray predictions = response.getJSONArray("predictions");
            for (int i = 0; i < predictions.size(); i++) {
                JSONObject jsonObject = predictions.getJSONObject(i);
                MapResVO mapResVO = new MapResVO();
                mapResVO.setAddress(jsonObject.getString("description"));
                mapResVO.setCode(jsonObject.getString("place_id"));
                list.add(mapResVO);
            }
        }
        return list;
    }

}
