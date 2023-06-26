package com.example.travel.common.dao;

import com.example.travel.base.pojo.Like;
import org.apache.ibatis.annotations.Mapper;
import org.springframework.stereotype.Repository;

import java.util.List;

@Mapper
@Repository
public interface LikeDao {
    Byte loadLikeStatus(int userId, int blogId);

//    void batchAddLike(List<BlogLikeStatusRedisData> likeList);
//
//    void batchUpdateLike(List<BlogLikeStatusRedisData> likeList);
//
//    List<Like> batchSearchLike(List<BlogLikeStatusRedisData> blogLikeStatusRedisData);

    void deleteBatch(int blogId);
}
