/*
 Navicat Premium Data Transfer

 Source Server         : MySQL
 Source Server Type    : MySQL
 Source Server Version : 50721
 Source Host           : localhost:3306
 Source Schema         : blog

 Target Server Type    : MySQL
 Target Server Version : 50721
 File Encoding         : 65001
*/

create database travel;
use travel;
SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for tb_user
-- ----------------------------
DROP TABLE IF EXISTS `tb_user`;
CREATE TABLE `tb_user`  (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'key',
  `first_name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'first_name',
  `last_name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'last_name',
  `password` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'password',
  `email` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'email',
  `create_time` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'create time',
  `update_time` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'update time',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `unq_email`(`email`) USING BTREE
) ENGINE = InnoDB  CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = 'user table' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Table structure for tb_note
-- ----------------------------
DROP TABLE IF EXISTS `tb_note`;
CREATE TABLE `tb_note`  (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'key',
  `user_id` int(11) NOT NULL COMMENT 'user id',
  `content` longtext CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'content',
  `title` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'title',
  `category` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'category',
  `likes` int(11) NOT NULL DEFAULT 0 COMMENT 'likes',
  `map_link` varchar(200) COMMENT 'map link',
  `country` varchar(100) COMMENT 'country',
  `photos` varchar(500) COMMENT 'photos',
  `create_time` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'create time',
  `update_time` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'update time',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `unq_user_id`(`user_id`) USING BTREE,
  INDEX `unq_category`(`category`) USING BTREE
) ENGINE = InnoDB  CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = 'article' ROW_FORMAT = DYNAMIC;

DROP TABLE IF EXISTS `tb_like`;
CREATE TABLE `tb_like`  (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'key',
  `user_id` int(11) NOT NULL COMMENT 'user id',
  `note_id` int(11) NOT NULL COMMENT 'note id',
  `status` tinyint(4) NOT NULL DEFAULT 0 COMMENT 'status 1liked 0 canceled',
  `create_time` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'create time',
  `update_time` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'update time',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `unq_note_id`(`note_id`) USING BTREE,
  INDEX `unq_user_id`(`user_id`) USING BTREE,
  UNIQUE INDEX`unq_user_note_id`(`user_id`, `note_id`)USING BTREE
) ENGINE = InnoDB  CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = 'like' ROW_FORMAT = DYNAMIC;

DROP TABLE IF EXISTS `tb_password`;
CREATE TABLE `tb_password`  (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'key',
  `client_id` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'client_id',
  `key` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'key',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB  CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = 'tb_password' ROW_FORMAT = DYNAMIC;
alter table `tb_password` add column `google_api` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'google_api';

SET FOREIGN_KEY_CHECKS = 1;
