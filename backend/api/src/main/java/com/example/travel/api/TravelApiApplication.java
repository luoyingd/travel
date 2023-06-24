package com.example.travel.api;

import lombok.extern.slf4j.Slf4j;
import org.mybatis.spring.annotation.MapperScan;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.web.servlet.ServletComponentScan;
import org.springframework.cache.annotation.EnableCaching;
import org.springframework.scheduling.annotation.EnableAsync;
import org.springframework.transaction.annotation.EnableTransactionManagement;

@SpringBootApplication(scanBasePackages = {"com.example.travel"})
@ServletComponentScan
@Slf4j
@MapperScan(basePackages = {"com.example.travel.common.dao"})
@EnableAsync(proxyTargetClass=true)
@EnableCaching
@EnableTransactionManagement
public class TravelApiApplication {

    public static void main(String[] args) {
        SpringApplication.run(TravelApiApplication.class, args);
    }
}