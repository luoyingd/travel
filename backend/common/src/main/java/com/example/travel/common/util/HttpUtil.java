package com.example.travel.common.util;

import com.alibaba.fastjson.JSONObject;
import lombok.extern.slf4j.Slf4j;
import org.apache.http.client.config.RequestConfig;
import org.apache.http.client.methods.CloseableHttpResponse;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.utils.URIBuilder;
import org.apache.http.impl.client.CloseableHttpClient;
import org.apache.http.impl.client.HttpClients;
import org.apache.http.util.EntityUtils;

import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.util.Map;

@Slf4j
public class HttpUtil {
    private static final RequestConfig requestConfig;


    static {
        requestConfig = RequestConfig.custom()
                .setConnectTimeout(1000 * 60)
                .setConnectionRequestTimeout(6000)
                .setSocketTimeout(1000 * 60 * 3)
                .build();
    }

    public static JSONObject doGet(String url, Map<String, String> param) {

        CloseableHttpClient httpClient = HttpClients.createDefault();

        String resultString = "";
        CloseableHttpResponse response = null;
        try {
            URIBuilder builder = new URIBuilder(url);
            if (param != null) {
                for (String key : param.keySet()) {
                    builder.addParameter(key, param.get(key));
                }
            }
            URI uri = builder.build();
            log.debug("-->>Http GET url：" + url);
            if (null != param) {
                log.debug("-->>Http get param：" + param);
            }

            HttpGet httpGet = new HttpGet(uri);
            httpGet.setConfig(requestConfig);

            response = httpClient.execute(httpGet);
            if (response.getStatusLine().getStatusCode() == 200) {
                resultString = EntityUtils.toString(response.getEntity(), "UTF-8");
                log.debug("<<--Http get response ：" + resultString);
            } else {
                log.error("<<--Http 响应状态码：" + response.getStatusLine().getStatusCode());
                return null;
            }

        } catch (IOException | URISyntaxException e) {
            log.error("Http 发送请求异常 url:{}", url, e);
            return null;
        } finally {
            try {
                if (response != null) {
                    response.close();
                }
                httpClient.close();
            } catch (IOException e) {
                log.error("Http 关闭流异常", e);
            }
        }
        return JSONObject.parseObject(resultString);
    }

}
