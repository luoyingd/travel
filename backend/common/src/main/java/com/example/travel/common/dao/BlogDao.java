package com.example.travel.common.dao;

import com.example.travel.base.pojo.Blog;
import com.example.travel.base.request.blog.GetBlogForm;
import com.example.travel.base.response.blog.BlogLikeCountRedisData;
import com.example.travel.base.response.blog.LoadBlogContentDVO;
import com.example.travel.base.response.blog.LoadBlogDetailDVO;
import com.example.travel.base.response.blog.LoadBlogInfoDVO;
import org.apache.ibatis.annotations.Mapper;
import org.springframework.stereotype.Repository;

import java.util.List;

@Mapper
@Repository
public interface BlogDao {
    int searchBlogCount(GetBlogForm getBlogForm);


    List<LoadBlogInfoDVO> getBlogs(GetBlogForm getBlogForm);

    LoadBlogContentDVO loadBlogContent(int blogId);

    int searchLikeCountById(int blogId);

    void updateBlog(Blog blog);

    void batchUpdateBlogLike(List<BlogLikeCountRedisData> blogLikeCountRedisDataList);

    void addBlog(Blog blog);


    LoadBlogDetailDVO loadBlogDetail(int blogId);

    void delete(int id);
}
