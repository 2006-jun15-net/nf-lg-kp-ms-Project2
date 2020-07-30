CREATE DATABASE Project2;

-- DROP TABLE Users;
-- DROP TABLE Following;
-- DROP TABLE CommentLikes;
-- DROP TABLE ReviewLikes;
-- DROP TABLE Media;
-- DROP TABLE Reviews;
-- DROP TABLE Comments;
-- DROP TABLE Notifications;
-- DROP TABLE Genre;
-- DROP TABLE MediaTypes;

CREATE TABLE Users (
    UserId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    FirstName NVARCHAR(255) NOT NULL,
    LastName NVARCHAR(255) NOT NULL,
    UserName NVARCHAR(255) NOT NULL UNIQUE,
    Password NVARCHAR (255) NOT NULL,
    Bio NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Picture NVARCHAR(255),
    AdminUser BIT NOT NULL
);

CREATE TABLE Following (
    FollowerId INT NOT NULL,
    FollowingId INT NOT NULL,
    CONSTRAINT PK_FollowerId_FollowingId PRIMARY KEY(FollowerId, FollowingId),
    CONSTRAINT FK_Following_FollowingId_Users FOREIGN KEY (FollowingId) 
        REFERENCES Users (UserId) ON DELETE CASCADE
);

CREATE TABLE MediaTypes (
    MediaTypesId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    MediaTypesName NVARCHAR(255)
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
    MediaTypesId INT,
    MediaURL NVARCHAR(MAX),
    GenreId INT,
    Approved BIT NOT NULL,
    Composer NVARCHAR(255),
    CONSTRAINT FK_Media_MediaTypesId_MediaTypes FOREIGN KEY (MediaTypesId) 
        REFERENCES MediaTypes (MediaTypesId),
    CONSTRAINT FK_Media_GenreId_Genre FOREIGN KEY (GenreId) 
        REFERENCES Genre (GenreId) 
);

CREATE TABLE Reviews (
    ReviewId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Content NVARCHAR(MAX) NOT NULL,
    MediaId INT NOT NULL,
    UserId INT NOT NULL,
    ReviewDate DATETIME2 NOT NULL,
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
    CommentDate DATETIME2 NOT NULL,
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
    NotificationDate DATETIME2 NOT NULL,
    NotificationType NVARCHAR(255) NOT NULL,
    CONSTRAINT FK_Notificatoins_Reciver_UserId_Users FOREIGN KEY (ReciverId) 
        REFERENCES Users (UserId) ON DELETE CASCADE,
    CONSTRAINT FK_Notifications_Sender_UserId_Users FOREIGN KEY (SenderId) 
        REFERENCES Users (UserId)
);

INSERT INTO Genre (GenreName)
VALUES ('Action'), ('Comedy'), ('Drama'), ('Fantasy'), ('Horror'), ('Mystery'), ('Romance'), 
('Thriller'), ('Western'), ('Blues Music'), ('Jazz Music'), ('Rhythm and Blues Music'), 
('Rock and Roll Music'), ('Rock Music'), ('Country Music'), ('Soul Music'), ('Dance Music'), ('Hip Hop Music'), ('Anime');

INSERT INTO MediaTypes (MediaTypesName)
VALUES ('Video Games'), ('Movies'), ('Albums'), ('Books'), ('TV Shows');

INSERT INTO Users (FirstName, LastName, UserName, Password, Bio, Email, AdminUser)
VALUES ('Noah', 'Funtanilla', 'nfun', 'passnfun', 'Hello, I am Noah, I like pie', 'noahfuntanilla6@gmail.com', 'true'),
    ('Kirti', 'Patel', 'kirti', 'password', 'Hello, I am Kirti, I like cake', 'kirti.bapa@gmail.com', 'true');

INSERT INTO Following (FollowerId, FollowingId)
VALUES (6, 2), (6, 1), (6, 5), (5, 2), (5, 1), (5, 6), (2, 5), (2, 6), (1, 5), (1, 6);

UPDATE Users SET Email = 'luey714@gmail.com' WHERE UserId = 1;

SELECT * FROM Users;

