package com.example.travel.common.service.inter;

import com.example.travel.base.exception.TravelException;
import com.example.travel.base.pojo.Blog;
import com.example.travel.base.request.blog.GetBlogForm;
import com.example.travel.base.request.blog.UpdateLikeForm;
import com.example.travel.base.response.blog.LoadBlogContentDVO;
import com.example.travel.base.response.blog.LoadBlogDetailDVO;
import com.example.travel.base.response.blog.LoadBlogInfoDVO;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface BlogService {
    int searchBlogCount(GetBlogForm getBlogForm);


    List<LoadBlogInfoDVO> getBlogs(GetBlogForm getBlogForm);

    LoadBlogContentDVO loadBlogContent(int blogId) throws TravelException;

    boolean loadLikeStatus(int userId, int blogId) throws TravelException;

    void updateLike(UpdateLikeForm updateLikeForm) throws TravelException;

    int loadLikeCount(int blogId);

    void saveLikeDataFromRedis();

    void addOrUpdateBlog(Blog blog) throws TravelException;

    void updateBlog(Blog blog) throws TravelException;

    LoadBlogDetailDVO loadBlogDetail(int blogId) throws TravelException;

    void delete(int id);
}
