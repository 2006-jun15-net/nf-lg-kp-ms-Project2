CREATE DATABASE Project2;

-- DROP TABLE Users;
-- DROP TABLE Following;
-- DROP TABLE CommentLikes;
-- DROP TABLE ReviewLikes;
-- DROP TABLE Category;
-- DROP TABLE Media;
-- DROP TABLE Reviews;
-- DROP TABLE Comments;
-- DROP TABLE Notifications;
-- DROP TABLE Genre;

CREATE TABLE Users (
    UserId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    FirstName NVARCHAR(255) NOT NULL,
    LastName NVARCHAR(255) NOT NULL,
    UserName NVARCHAR(255) NOT NULL UNIQUE,
    Password NVARCHAR (255) NOT NULL,
    Bio NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Picture NVARCHAR(255)
);

CREATE TABLE Following (
    FollowerId INT NOT NULL,
    FollowingId INT NOT NULL,
    CONSTRAINT PK_FollowerId_FollowingId PRIMARY KEY(FollowerId, FollowingId),
    CONSTRAINT FK_Following_FollowingId_Users FOREIGN KEY (FollowingId) 
        REFERENCES Users (UserId) ON DELETE CASCADE
);

CREATE TABLE Category (
    CategoryId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    CategoryName NVARCHAR(255)
);

CREATE TABLE Genre (
    GenreId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    GenreName NVARCHAR(255) NOT NULL
);

CREATE TABLE Media (
    MediaId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Rating INT,
    MediaName NVARCHAR(255),
    Description NVARCHAR(MAX),
    CategoryId INT,
    MediaURL NVARCHAR(MAX),
    GenreId INT,
    CONSTRAINT FK_Media_CategoryId_Category FOREIGN KEY (CategoryId) 
        REFERENCES Category (CategoryId),
    CONSTRAINT FK_Media_GenreId_Genre FOREIGN KEY (GenreId) 
        REFERENCES Genre (GenreId) 
);

CREATE TABLE Reviews (
    ReviewId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Content NVARCHAR(MAX) NOT NULL,
    MediaId INT NOT NULL,
    UserId INT NOT NULL,
    ReviewDate DATETIME,
    Likes INT,
    Rating INT,
    CONSTRAINT FK_Reviews_UserId_Users FOREIGN KEY (UserId) 
        REFERENCES Users (UserId) ON DELETE CASCADE,
    CONSTRAINT FK_Reviews_MediaId_Media FOREIGN KEY (MediaId) 
        REFERENCES Media (MediaId) ON DELETE CASCADE
);

CREATE TABLE Comments (
    CommentId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Content NVARCHAR(255) NOT NULL,
    ReviewId INT NOT NULL,
    UserId INT NOT NULL,
     CONSTRAINT FK_Comments_UserId_Users FOREIGN KEY (UserId) 
        REFERENCES Users (UserId) ON DELETE CASCADE
);

CREATE TABLE CommentLikes (
    UserId INT NOT NULL,
    CommentId INT NOT NULL,
    CONSTRAINT PK_UserId_CommentId PRIMARY KEY(UserId, CommentId),
    CONSTRAINT FK_CommentLikes_UserId_Users FOREIGN KEY (UserId) 
        REFERENCES Users (UserId) ON DELETE CASCADE,
    CONSTRAINT FK_CommentLikes_CommentId_Users FOREIGN KEY (CommentId) 
        REFERENCES Comments (CommentId) ON DELETE NO ACTION
);

CREATE TABLE ReviewLikes (
    UserId INT NOT NULL,
    ReviewId INT NOT NULL,
    CONSTRAINT PK_UserId_ReviewId PRIMARY KEY(UserId, ReviewId),
    CONSTRAINT FK_ReviewLikes_UserId_Users FOREIGN KEY (UserId) 
        REFERENCES Users (UserId) ON DELETE CASCADE,
    CONSTRAINT FK_ReviewLikes_ReviewId_Users FOREIGN KEY (ReviewId) 
        REFERENCES Reviews (ReviewId) ON DELETE NO ACTION
);

CREATE TABLE Notifications (
    NotificationId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    PostID INT NOT NULL,
    Status BIT NOT NULL,
    ReciverId INT NOT NULL,
    SenderId INT,
    NotificationType NVARCHAR(255) NOT NULL,
    CONSTRAINT FK_Notificatoins_Reciver_UserId_Users FOREIGN KEY (ReciverId) 
        REFERENCES Users (UserId) ON DELETE CASCADE,
    CONSTRAINT FK_Notifications_Sender_UserId_Users FOREIGN KEY (SenderId) 
        REFERENCES Users (UserId)
);