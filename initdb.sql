use travel;

-- ----------------------------
-- Table structure for tb_user
-- ----------------------------
DROP TABLE IF EXISTS tb_user;
CREATE TABLE tb_user
(
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  first_name varchar(50) NULL DEFAULT NULL,
  last_name varchar(50) NULL DEFAULT NULL,
  password varchar(50) NULL DEFAULT NULL,
  email varchar(50) NULL DEFAULT NULL,
  create_time datetime NOT NULL DEFAULT GETDATE(),
  update_time datetime NOT NULL DEFAULT GETDATE(),
  [salt] NVARCHAR(50) Not NULL
)
GO

CREATE UNIQUE INDEX email ON tb_user(email)
GO

create trigger mytrigger ON tb_user
after INSERT ,update
AS
begin
  update  tb_user set update_time = GETDATE() 
  from tb_user t
    INNER JOIN Inserted i on t.id = i.id
end
Go

-- ----------------------------
-- Table structure for tb_note
-- ----------------------------

DROP TABLE IF EXISTS tb_note;
CREATE TABLE tb_note
(
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  user_id INT NOT NULL,
  content VARCHAR(MAX) NULL DEFAULT NULL,
  title varchar(200) NULL DEFAULT NULL,
  category varchar(50) NULL DEFAULT NULL,
  likes INT NOT NULL DEFAULT 0,
  address_code varchar(200) NULL DEFAULT NULL,
  address varchar(100) NULL DEFAULT NULL,
  photos varchar(500) NULL DEFAULT NULL,
  create_time datetime NOT NULL DEFAULT GETDATE(),
  update_time datetime NOT NULL DEFAULT GETDATE(),
)
GO
ALTER TABLE [dbo].[tb_note]
  ADD [country] varchar(50) NULL DEFAULT NULL
GO

CREATE INDEX user_id ON tb_note(user_id)
GO

create trigger mytrigger2 ON tb_note
after INSERT ,update
AS
begin
  update  tb_note set update_time = GETDATE() 
  from tb_note t
    INNER JOIN Inserted i on t.id = i.id
end
Go

-- ----------------------------
-- Table structure for tb_like
-- ----------------------------
DROP TABLE IF EXISTS tb_like;
CREATE TABLE tb_like
(
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  user_id INT NOT NULL,
  note_id INT NOT NULL,
  status TINYINT NOT NULL,
  create_time datetime NOT NULL DEFAULT GETDATE(),
  update_time datetime NOT NULL DEFAULT GETDATE(),
)
GO

CREATE INDEX note_id ON tb_like(note_id)
CREATE INDEX user_id ON tb_like(user_id)
GO

create trigger mytrigger3 ON tb_like
after INSERT ,update
AS
begin
  update  tb_like set update_time = GETDATE() 
  from tb_like t
    INNER JOIN Inserted i on t.id = i.id
end
Go

-- ----------------------------
-- Table structure for tb_password
-- ----------------------------
DROP TABLE IF EXISTS tb_password;
CREATE TABLE tb_password
(
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  client_id varchar(50) NULL DEFAULT NULL,
  client_key varchar(50) NULL DEFAULT NULL,
  google_api varchar(50) NULL DEFAULT NULL,
  [email_pwd] varchar(50) NULL DEFAULT NULL
)
GO


DROP TABLE IF EXISTS tb_reset_token;
CREATE TABLE tb_reset_token
(
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  token varchar(50) NULL DEFAULT NULL,
  email varchar(50) NULL DEFAULT NULL,
  create_time DATETIME NOT NULL DEFAULT GETDATE()
)
GO
CREATE UNIQUE INDEX email ON tb_reset_token(email)
GO

DROP TABLE IF EXISTS tb_user_subscribe;
CREATE TABLE tb_user_subscribe
(
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  user_id INT NOT NULL,
  author_id INT NOT NULL,
  create_time DATETIME NOT NULL DEFAULT GETDATE()
)
GO
CREATE UNIQUE INDEX id_pair ON tb_user_subscribe(user_id, author_id);
GO