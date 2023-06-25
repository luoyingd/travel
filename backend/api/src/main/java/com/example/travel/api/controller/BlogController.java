package com.example.travel.api.controller;

import com.example.travel.base.exception.TravelException;
import com.example.travel.base.pojo.Blog;
import com.example.travel.base.request.blog.GetBlogForm;
import com.example.travel.base.request.blog.UpdateLikeForm;
import com.example.travel.common.util.R;
import com.example.travel.common.service.inter.BlogService;
import lombok.extern.slf4j.Slf4j;
import org.springframework.web.bind.annotation.*;

import javax.annotation.Resource;

@RestController
@RequestMapping("/blog")
@Slf4j
public class BlogController {
    @Resource
    private BlogService blogService;

    @GetMapping("/getBlogs")
    public R getBlogs(GetBlogForm getBlogForm) {
        return R.ok(blogService.getBlogs(getBlogForm));
    }

    @GetMapping("/getBlogsCount")
    public R getBlogsCount(GetBlogForm getBlogForm) {
        return R.ok(blogService.searchBlogCount(getBlogForm));
    }

    @GetMapping("/getBlogContent/{id}")
    public R getBlogContent(@PathVariable int id) throws TravelException {
        return R.ok(blogService.loadBlogContent(id));
    }

    @GetMapping("/getBlogDetail/{id}")
    public R getBlogDetail(@PathVariable int id) throws TravelException {
        return R.ok(blogService.loadBlogDetail(id));
    }

    @GetMapping("/getLikeStatus/{blogId}/{userId}")
    public R getLikeStatus(@PathVariable int blogId, @PathVariable int userId) throws TravelException {
        return R.ok(blogService.loadLikeStatus(userId, blogId));
    }

    @GetMapping("/getBlogLikeCount/{blogId}")
    public R getBlogLikeCount(@PathVariable int blogId) throws TravelException {
        return R.ok(blogService.loadLikeCount(blogId));
    }

    @PutMapping("/updateLike")
    public R updateLike(@RequestBody UpdateLikeForm updateLikeForm) throws TravelException {
        blogService.updateLike(updateLikeForm);
        return R.ok();
    }

    @PostMapping("/addOrUpdate")
    public R addOrUpdate(@RequestBody Blog blog) throws TravelException {
        blogService.addOrUpdateBlog(blog);
        return R.ok();
    }

    @DeleteMapping("/{id}")
    public R delete(@PathVariable int id) {
        blogService.delete(id);
        return R.ok();
    }

}
