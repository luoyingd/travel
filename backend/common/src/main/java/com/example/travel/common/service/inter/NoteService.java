package com.example.travel.common.service.inter;

import com.example.travel.base.exception.TravelException;
import com.example.travel.base.request.note.AddNoteForm;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface NoteService {
    void addNote(AddNoteForm addNoteForm) throws TravelException;
}
