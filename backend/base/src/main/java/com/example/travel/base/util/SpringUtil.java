package com.example.travel.base.util;


import org.springframework.beans.BeansException;
import org.springframework.context.ApplicationContext;
import org.springframework.context.ApplicationContextAware;
import org.springframework.stereotype.Component;

@Component
public class SpringUtil implements ApplicationContextAware {

    private static ApplicationContext applicationContext;

    @Override
    public void setApplicationContext(ApplicationContext applicationContext) throws BeansException {
        this.applicationContext = applicationContext;
    }

    public static <T> T getObject(Class<T> clazz){
        return applicationContext.getBean(clazz);
    }

    public static void main(String[] args) {
        String my = "123123";
        String replace = my.replace('1', 'h');
        System.out.println(replace);
    }
}