package com.example.travel.common.service.inter;

import com.example.travel.base.exception.TravelException;
import org.springframework.stereotype.Service;

import java.io.IOException;

@Service
public interface CommonService {
    void uploadPhoto(String filePath, String key) throws TravelException;

    byte[] getPhoto(String key) throws TravelException, IOException;
}
