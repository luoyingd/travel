package com.example.travel.common.service.impl;

import cn.dev33.satoken.stp.StpUtil;
import com.example.travel.base.exception.CodeAndMsg;
import com.example.travel.base.exception.TravelException;
import com.example.travel.base.pojo.Note;
import com.example.travel.base.request.note.AddNoteForm;
import com.example.travel.common.dao.NoteDao;
import com.example.travel.common.dao.LikeDao;
import com.example.travel.common.service.inter.NoteService;
import com.example.travel.common.service.inter.RedisService;
import lombok.extern.slf4j.Slf4j;
import org.apache.commons.lang3.StringUtils;
import org.springframework.stereotype.Component;
import org.springframework.transaction.annotation.Transactional;

import javax.annotation.Resource;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

@Component
@Slf4j
public class NoteServiceImpl implements NoteService {
    @Resource
    private NoteDao noteDao;
    @Resource
    private LikeDao likeDao;
    @Resource
    private RedisService redisService;
    private final SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");

    @Override
    public void addNote(AddNoteForm addNoteForm) throws TravelException {
        if (StringUtils.isEmpty(addNoteForm.getAddress())
                || StringUtils.isEmpty(addNoteForm.getAddressCode())
                || StringUtils.isEmpty(addNoteForm.getCategory())
                || StringUtils.isEmpty(addNoteForm.getTitle())) {
            throw new TravelException(CodeAndMsg.PARAM_VERIFICATION_FAIL);
        }
        Note note = new Note();
        note.setAddress(addNoteForm.getAddress());
        note.setAddressCode(addNoteForm.getAddressCode());
        note.setTitle(addNoteForm.getTitle());
        note.setCategory(addNoteForm.getCategory());
        note.setContent(addNoteForm.getDescription());
        note.setUserId(StpUtil.getLoginIdAsInt());
        if (addNoteForm.getPhotoKeys().length > 0) {
            StringBuilder keys = new StringBuilder();
            for (String photoKey : addNoteForm.getPhotoKeys()) {
                keys.append(photoKey).append(",");
            }
            note.setPhotos(keys.substring(0, keys.length() - 1));
        }
        noteDao.addNote(note);
    }

//    @Override
//    public int searchBlogCount(GetBlogForm getBlogForm) {
//        if (StringUtils.isNotEmpty(getBlogForm.getTopic()) && getBlogForm.getTopic().equals(CategoryEnum.ALL.getValue())) {
//            getBlogForm.setTopic(null);
//        }
//        if (StringUtils.isNotEmpty(getBlogForm.getTitle())) {
//            getBlogForm.setTitle("%" + getBlogForm.getTitle() + "%");
//        } else {
//            getBlogForm.setTitle(null);
//        }
//        return noteDao.searchBlogCount(getBlogForm);
//    }
//
//    @Override
//    public List<LoadBlogInfoDVO> getBlogs(GetBlogForm getBlogForm) {
//        getBlogForm.setPage((getBlogForm.getPage() - 1) * getBlogForm.getPageSize());
//        if (StringUtils.isNotEmpty(getBlogForm.getTopic()) && getBlogForm.getTopic().equals(CategoryEnum.ALL.getValue())) {
//            getBlogForm.setTopic(null);
//        }
//        if (StringUtils.isNotEmpty(getBlogForm.getTitle())) {
//            getBlogForm.setTitle("%" + getBlogForm.getTitle() + "%");
//        } else {
//            getBlogForm.setTitle(null);
//        }
//        List<LoadBlogInfoDVO> blogs = noteDao.getBlogs(getBlogForm);
//        blogs.forEach(loadBlogInfoDVO -> {
//            // Get like count from redis first
//            Integer likes = redisService.getLikedCountFromRedis(loadBlogInfoDVO.getId());
//            if (likes == null) {
//                redisService.incrementLikedCount(loadBlogInfoDVO.getId(), loadBlogInfoDVO.getLikes());
//            } else {
//                loadBlogInfoDVO.setLikes(likes);
//            }
//        });
//        return blogs;
//    }
//
//    @Override
//    public LoadBlogContentDVO loadBlogContent(int blogId) throws TravelException {
//        if (blogId == 0) {
//            throw new TravelException(CodeAndMsg.PARAM_VERIFICATION_FAIL);
//        }
//        LoadBlogContentDVO loadBlogContentDVO = noteDao.loadBlogContent(blogId);
//        // Get like count from redis first
//        Integer likes = redisService.getLikedCountFromRedis(blogId);
//        if (likes != null) {
//            loadBlogContentDVO.setLikes(likes);
//        } else {
//            // sync from db to redis
//            int likeCountById = noteDao.searchLikeCountById(blogId);
//            loadBlogContentDVO.setLikes(likeCountById);
//            redisService.incrementLikedCount(blogId, likeCountById);
//        }
//        return loadBlogContentDVO;
//    }
//
//    @Override
//    public LoadBlogDetailDVO loadBlogDetail(int blogId) throws TravelException {
//        if (blogId == 0) {
//            throw new TravelException(CodeAndMsg.PARAM_VERIFICATION_FAIL);
//        }
//        return noteDao.loadBlogDetail(blogId);
//    }
//
//    @Override
//    @Transactional(rollbackFor = Exception.class)
//    public void delete(int blogId) {
//        likeDao.deleteBatch(blogId);
//        noteDao.delete(blogId);
//    }
//
//    @Override
//    public boolean loadLikeStatus(int userId, int blogId) throws TravelException {
//        if (blogId == 0 || userId == 0) {
//            throw new TravelException(CodeAndMsg.PARAM_VERIFICATION_FAIL);
//        }
//        Integer likedStatusFromRedis = redisService.getLikedStatusFromRedis(userId, blogId);
//        if (likedStatusFromRedis == null) {
//            Byte likeStatus = likeDao.loadLikeStatus(userId, blogId);
//            if (likeStatus == null || likeStatus == LikeStatusEnum.NOT_LIKED.getValue()) {
//                redisService.unlikeFromRedis(userId, blogId);
//                return false;
//            }
//            redisService.saveLiked2Redis(userId, blogId);
//            return true;
//        }
//        return likedStatusFromRedis.byteValue() == LikeStatusEnum.LIKED.getValue();
//    }
//
//    @Override
//    public void updateLike(UpdateLikeForm updateLikeForm) throws TravelException {
//        if (updateLikeForm.getBlogId() == 0 || updateLikeForm.getUserId() == 0) {
//            throw new TravelException(CodeAndMsg.PARAM_VERIFICATION_FAIL);
//        }
//        if (updateLikeForm.getLike() == Boolean.TRUE) {
//            redisService.saveLiked2Redis(updateLikeForm.getUserId(), updateLikeForm.getBlogId());
//            redisService.incrementLikedCount(updateLikeForm.getBlogId(), 1);
//        } else {
//            redisService.unlikeFromRedis(updateLikeForm.getUserId(), updateLikeForm.getBlogId());
//            redisService.decrementLikedCount(updateLikeForm.getBlogId(), 1);
//        }
//    }
//
//    @Override
//    public int loadLikeCount(int blogId) {
//        Integer likedCountFromRedis = redisService.getLikedCountFromRedis(blogId);
//        if (likedCountFromRedis == null) {
//            int likeCountById = noteDao.searchLikeCountById(blogId);
//            redisService.incrementLikedCount(blogId, likeCountById);
//            return likeCountById;
//        }
//        return likedCountFromRedis;
//    }
//
//    @Override
//    @Transactional(rollbackFor = Exception.class)
//    public void saveLikeDataFromRedis() {
//        List<BlogLikeCountRedisData> allLikeCountRedisDataFromRedis = redisService.getAllLikeCountRedisDataFromRedis();
//        if (CollectionUtil.isNotEmpty(allLikeCountRedisDataFromRedis)) {
//            noteDao.batchUpdateBlogLike(allLikeCountRedisDataFromRedis);
//            redisService.deleteLikeCountDataFromRedis();
//        }
//        List<BlogLikeStatusRedisData> allLikeStatusRedisDataFromRedis = redisService.getAllLikeStatusRedisDataFromRedis();
//        if (CollectionUtil.isNotEmpty(allLikeStatusRedisDataFromRedis)) {
//            List<Like> currentLikes = likeDao.batchSearchLike(allLikeStatusRedisDataFromRedis);
//            List<BlogLikeStatusRedisData> newData = new ArrayList<>();
//            List<BlogLikeStatusRedisData> needUpdateData = new ArrayList<>();
//            for (BlogLikeStatusRedisData blogLikeStatusRedisData : allLikeStatusRedisDataFromRedis) {
//                if (noteDao.loadBlogDetail(blogLikeStatusRedisData.getBlogId()) == null) {
//                    continue;
//                }
//                boolean contains = false;
//                for (Like currentLike : currentLikes) {
//                    if (blogLikeStatusRedisData.getBlogId() == currentLike.getBlogId()
//                            && blogLikeStatusRedisData.getUserId() == currentLike.getUserId()) {
//                        if (blogLikeStatusRedisData.getLike() != currentLike.getStatus().byteValue()) {
//                            needUpdateData.add(blogLikeStatusRedisData);
//                        }
//                        contains = true;
//                        break;
//                    }
//                }
//                if (!contains && blogLikeStatusRedisData.getLike() == LikeStatusEnum.LIKED.getValue()) {
//                    newData.add(blogLikeStatusRedisData);
//                }
//            }
//            if (CollectionUtil.isNotEmpty(needUpdateData)) {
//                likeDao.batchUpdateLike(needUpdateData);
//            }
//            if (CollectionUtil.isNotEmpty(newData)) {
//                likeDao.batchAddLike(newData);
//            }
//            redisService.deleteLikeDataFromRedis();
//        }
//
//        log.info("LikeSyncJob Finish On {}", sdf.format(new Date()));
//    }
//
//    @Override
//    public void addOrUpdateBlog(Note note) throws TravelException {
////        if (StringUtils.isEmpty(blog.getContent())
////                || StringUtils.isEmpty(blog.getIntroduction())
////                || StringUtils.isEmpty(blog.getTopic())
////                || StringUtils.isEmpty(blog.getTitle())
////                || blog.getUserId() == 0) {
////            throw new TravelException(CodeAndMsg.PARAM_VERIFICATION_FAIL);
////        }
////        if (blog.getId() != 0) {
////            if (StringUtils.isEmpty(blog.getCover())) {
////                blog.setCover("");
////            }
////            updateBlog(blog);
////        } else {
////            blogDao.addBlog(blog);
////        }
//    }
//
//    @Override
//    public void updateBlog(Note note) throws TravelException {
////        if (blog.getId() == 0) {
////            throw new TravelException(CodeAndMsg.PARAM_VERIFICATION_FAIL);
////        }
////        blogDao.updateBlog(blog);
//    }

}
