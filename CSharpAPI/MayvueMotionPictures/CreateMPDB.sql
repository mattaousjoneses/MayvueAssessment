Create Database MotionPictureDB
Go

Use MotionPictureDB
Go

Create table MotionPictures
(
     ID int primary key,
     Name nvarchar(50) NOT NULL,
     Description nvarchar(500),
     ReleaseYear int NOT NULL
)
Go

Insert into MotionPictures values ('Batman', 'About a man who''s a Bat.', 1989)
Insert into MotionPictures values ('Superman', 'About a man who''s just super.', 1978)
Insert into MotionPictures values ('Spiderman', 'About a man who gets bit by a spider and dies.', 2002)
Insert into MotionPictures values ('Hitman', 'About a man who released the spider.', 2007)
Insert into MotionPictures values ('Layman', 'About a man who might not know this is a joke', 2022)
Insert into MotionPictures values ('Funnyman', 'About a man who needed something to fill in space in a model database', 1337)
Insert into MotionPictures values ('Talisman', 'About a man or not', 2008)
Go