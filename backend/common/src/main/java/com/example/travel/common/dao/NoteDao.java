package com.example.travel.common.dao;

import com.example.travel.base.pojo.Note;
import org.apache.ibatis.annotations.Mapper;
import org.springframework.stereotype.Repository;

import java.util.List;

@Mapper
@Repository
public interface NoteDao {
    void addNote(Note note);
}
