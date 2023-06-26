package com.example.travel.base.enums;

public enum CategoryEnum {
    Museum("Museum"),
    City("City"),
    Shopping("Shopping"),
    Adventure("Adventure"),
    Entertainment("Entertainment"),
    Nature("Nature");
    private String value;

    CategoryEnum(String value) {
        this.value = value;
    }

    public String getValue() {
        return value;
    }

    public void setValue(String value) {
        this.value = value;
    }
}
