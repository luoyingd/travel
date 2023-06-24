package com.example.travel.base.exception;

public class TravelException extends Exception {
    private CodeAndMsg exception;

    public TravelException(CodeAndMsg exception) {
        this.exception = exception;
    }

    public CodeAndMsg getException() {
        return exception;
    }

    public void setException(CodeAndMsg exception) {
        this.exception = exception;
    }
}
