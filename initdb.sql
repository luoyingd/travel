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

insert into tb_note (user_id, content, title, category, address, address_code, photos, country)
VALUES
(1, 'Deep within the heartland of the United States, lies the enchanting Whispering Woods, a forest brimming with mystical beauty and a sense of untamed wilderness. 
Nestled in a region untouched by time, this sprawling forest captivates the imagination with its ancient trees, 
vibrant flora, and a tranquil ambiance that whispers tales of bygone eras.
<br></br>As you step into the Whispering Woods, a hushed serenity surrounds you. 
The sunlight filters through the dense canopy, creating a kaleidoscope of dancing rays that illuminate the forest floor. 
The air is crisp and fragrant, carrying the scent of earth, moss, and the delicate perfume of wildflowers.', 
'Whispering Woods', 
'Nature', 
'Whispering Woods, MD, USA', 
'ChIJZV918cvZx4kR7dHgPv_Bq2M', 
'7536be5f-ed9b-4fbf-b498-21fb6632e44f.png,21889adc-51a5-4852-a290-f385bd020e18.png,05473a38-8c64-4857-a3ef-2f816fc8cdb5.png', 
'USA')
GO

insert into tb_note (user_id, content, title, category, address, address_code, photos, country)
VALUES
(1, 'Nestled in a picturesque landscape, the serene Azure Lake beckons with its shimmering waters and captivating beauty. 
This enchanting body of water, located in a region known for its natural splendor, offers a sanctuary of tranquility and a playground for outdoor enthusiasts.
<br></br>
The stillness of Azure Lake is a testament to its peaceful ambiance. Here, time seems to slow down as the ripples gently lap against the shore. The air carries a sense of calmness, and the melodious songs of birds create a soothing soundtrack that harmonizes with the whispers of the wind.', 'Azure Lake', 
'Nature', 
'Azure Lake, Magnolia, TX, USA', 
'Eh1BenVyZSBMYWtlLCBNYWdub2xpYSwgVFgsIFVTQSIuKiwKFAoSCdUE_ZlwL0eGEaHztKxGxKptEhQKEgmbU0QZ7tdGhhFkwkp6ILjjVQ', 
'9078f25f-a4fd-4dbc-a2d5-58013edfcfb6.png', 
'USA')
GO

insert into tb_note (user_id, content, title, category, address, address_code, photos, country)
VALUES
(1, 'Situated amidst the breathtaking landscapes of the United States, Lake Tahoe stands as a crown jewel of natural beauty and serenity. Nestled in the Sierra Nevada mountains, straddling the border of California and Nevada, this iconic lake captivates visitors with its stunning cobalt blue waters, surrounding snow-capped peaks, and an abundance of outdoor activities.', 
'Lake Tahoe', 
'Nature', 
'Lake Tahoe Boulevard, South Lake Tahoe, CA, USA', 
'Ei9MYWtlIFRhaG9lIEJvdWxldmFyZCwgU291dGggTGFrZSBUYWhvZSwgQ0EsIFVTQSIuKiwKFAoSCa_vRwjGj5mAEbpLskbAr2O9EhQKEgnhT6XuiYWZgBGOkSP7Ri8b3Q', 
'63f126d4-f1fc-4471-824a-a44379908442.png', 
'USA')
GO

insert into tb_note (user_id, content, title, category, address, address_code, photos, country)
VALUES
(1, 'In the heart of the Pacific Northwest, the enchanting Olympic National Forest beckons with its lush greenery, towering trees, and a captivating sense of wilderness. Located in the state of Washington, this sprawling forest encompasses a diverse range of ecosystems, making it a haven for nature enthusiasts, hikers, and those seeking solace in the embrace of untouched beauty.', 
'Olympic National Forest', 
'Nature', 
'Olympic National Drive, Atascocita, TX, USA', 
'EitPbHltcGljIE5hdGlvbmFsIERyaXZlLCBBdGFzY29jaXRhLCBUWCwgVVNBIi4qLAoUChIJm4gI0X6uQIYRTfmStJEqDLUSFAoSCXXgCcZPrECGEeASeNLvSoOW', 
'c84708ac-1c41-4cda-aff2-4619091a457a.png', 
'USA')
GO

insert into tb_note (user_id, content, title, category, address, address_code, photos, country)
VALUES
(1, 'Deep within the heart of the Great Smoky Mountains, lies the enchanting Evergreen Forest, a realm of natural beauty and serene tranquility. This majestic forest captivates the senses with its towering trees, lush foliage, and a symphony of wildlife that harmonizes with the whispers of the wind.', 
'Great Smoky Mountains', 
'Nature', 
'Evergreen Park, IL, USA', 
'ChIJbWWVZQk_DogRTNG8LObTIoQ', 
'b9ba4f24-f5ac-4d7c-988a-a78a23fe97a6.png', 
'USA')
GO

insert into tb_note (user_id, content, title, category, address, address_code, photos, country)
VALUES
(1, 'Originating from the majestic Rocky Mountains, the Swan River winds its way through verdant valleys and pristine forests, creating a haven for outdoor enthusiasts and nature lovers. As you follow the rivergentle course, you will be captivated by the sights and sounds that surround you.
<br></br>
The river tranquil waters are a perfect invitation for a leisurely canoe or kayak adventure. Glide along the peaceful currents, surrounded by towering trees and the symphony of birdsong. Explore hidden coves, navigate gentle rapids, and soak in the serenity of the river embrace.', 
'Swan River', 
'Nature', 
'Swan River, MB, Canada', 
'ChIJU3f7Tm3S5FIRBVlUgE0xJUw', 
'a56bb58e-5760-4bd2-87a6-8094471709b0.png', 
'USA')
GO

insert into tb_note (user_id, content, title, category, address, address_code, photos, country)
VALUES
(1, 'Exploring the Stores:<br/>
Starlight Mall is home to an array of stores, ranging from high-end fashion boutiques to popular retail chains. From the latest fashion trends to electronics, home decor, beauty products, and more, you will find a treasure trove of options to suit every style and taste. Prepare to browse through designer collections, discover unique local brands, and uncover hidden gems.
<br></br>
Indulging in Retail Therapy:<br/>
Get ready to experience the thrill of retail therapy at its finest. Explore the diverse range of shops, where friendly and knowledgeable staff will assist you in finding that perfect purchase. Take your time, try on different outfits, and treat yourself to that must-have item you have been eyeing. Let the joy of discovering new styles and adding to your wardrobe fill your shopping adventure.', 
'A Shopping Adventure at the Starlight Mall', 
'Shopping', 
'SHOPPING MALL, Bhrigu Path, Sector 12, Mansarovar Sector 1, Mansarovar, Jaipur, Rajasthan, India', 
'ChIJM3RMVfi0bTkRMWg7CnCxnxA', 
'e452dd56-5b9b-4f58-acd9-e0c549243a76.png', 
'India')
GO

insert into tb_note (user_id, content, title, category, address, address_code, photos, country)
VALUES
(1, 'Paris is divided by the River Seine, with its charming riverbanks adorned by beautiful bridges and quays. Strolling along the Seine, visitors can experience the city romantic ambiance and discover famous landmarks like the Louvre Pyramid, the Musée dOrsay, and the picturesque Île de la Cité.', 
'City of Light', 
'City', 
'Paris, France', 
'ChIJD7fiBh9u5kcRYJSMaMOCCwQ', 
'10791023-de85-4fad-913f-764d5a6910a6.png', 
'France')
GO

insert into tb_note (user_id, content, title, category, address, address_code, photos, country)
VALUES
(1, 'With a history spanning over 3,000 years, Beijing is deeply rooted in Chinese heritage. The city is home to numerous UNESCO World Heritage Sites, including the majestic Great Wall of China, one of the most iconic and awe-inspiring structures in the world. The Forbidden City, a sprawling palace complex that once housed emperors during the Ming and Qing dynasties, stands as a testament to China imperial past. Its intricate architecture, grand halls, and beautiful gardens make it a must-visit destination for history enthusiasts.', 
'Beijing, the capital city of the People Republic', 
'City', 
'Beijing, China', 
'ChIJuSwU55ZS8DURiqkPryBWYrk', 
'fe5ca03d-c86f-4758-b9a9-0d2751ed0cb1.png,2485fa94-c286-43b9-a925-cacca3723370.png', 
'China')
GO

insert into tb_note (user_id, content, title, category, address, address_code, photos, country)
VALUES
(1, 'The Louvre Museum, located in Paris, France, is one of the most renowned and prestigious museums in the world. It is a symbol of art, history, and cultural heritage, attracting millions of visitors each year.
<br></br>
Originally a medieval fortress, the Louvre was transformed into a royal palace in the 16th century before being converted into a museum during the French Revolution in 1793. Today, 
it spans over 60,000 square meters and houses an extensive collection of over 38,000 artworks, ranging from ancient civilizations to the 19th century.', 
'The Louvre Museum', 
'Museum', 
'Louvre, Paris, France', 
'ChIJPStI0CVu5kcRUBqUaMOCCwU', 
'887073af-207e-4c62-b720-c0f429cf6e94.png', 
'France')

GO