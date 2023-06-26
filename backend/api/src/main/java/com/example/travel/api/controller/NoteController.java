package com.example.travel.api.controller;

import com.example.travel.base.exception.TravelException;
import com.example.travel.base.request.note.AddNoteForm;
import com.example.travel.common.util.R;
import com.example.travel.common.service.inter.NoteService;
import lombok.extern.slf4j.Slf4j;
import org.springframework.web.bind.annotation.*;

import javax.annotation.Resource;

@RestController
@RequestMapping("/note")
@Slf4j
public class NoteController {
    @Resource
    private NoteService noteService;

//    @GetMapping("/getBlogs")
//    public R getBlogs(GetBlogForm getBlogForm) {
//        return R.ok(noteService.getBlogs(getBlogForm));
//    }
//
//    @GetMapping("/getBlogsCount")
//    public R getBlogsCount(GetBlogForm getBlogForm) {
//        return R.ok(noteService.searchBlogCount(getBlogForm));
//    }
//
//    @GetMapping("/getBlogContent/{id}")
//    public R getBlogContent(@PathVariable int id) throws TravelException {
//        return R.ok(noteService.loadBlogContent(id));
//    }
//
//    @GetMapping("/getBlogDetail/{id}")
//    public R getBlogDetail(@PathVariable int id) throws TravelException {
//        return R.ok(noteService.loadBlogDetail(id));
//    }
//
//    @GetMapping("/getLikeStatus/{blogId}/{userId}")
//    public R getLikeStatus(@PathVariable int blogId, @PathVariable int userId) throws TravelException {
//        return R.ok(noteService.loadLikeStatus(userId, blogId));
//    }
//
//    @GetMapping("/getBlogLikeCount/{blogId}")
//    public R getBlogLikeCount(@PathVariable int blogId) throws TravelException {
//        return R.ok(noteService.loadLikeCount(blogId));
//    }
//
//    @PutMapping("/updateLike")
//    public R updateLike(@RequestBody UpdateLikeForm updateLikeForm) throws TravelException {
//        noteService.updateLike(updateLikeForm);
//        return R.ok();
//    }

    @PostMapping()
    public R add(@RequestBody AddNoteForm addNoteForm) throws TravelException {
        noteService.addNote(addNoteForm);
        return R.ok();
    }
//
//    @DeleteMapping("/{id}")
//    public R delete(@PathVariable int id) {
//        noteService.delete(id);
//        return R.ok();
//    }

}
