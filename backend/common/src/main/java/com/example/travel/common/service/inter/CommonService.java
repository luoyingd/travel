package com.example.travel.common.service.inter;

import com.example.travel.base.exception.TravelException;
import com.example.travel.base.response.map.MapResVO;
import org.springframework.stereotype.Service;

import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.util.List;

@Service
public interface CommonService {
    void uploadPhoto(String filePath, String key) throws TravelException;

    byte[] getPhoto(String key) throws TravelException, IOException;

    String getMapApi();

    List<MapResVO> getAddress(String input);
}
