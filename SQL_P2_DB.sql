CREATE DATABASE Project2;

CREATE TABLE Users (
    UserId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    FirstName NVARCHAR(255) NOT NULL,
    LastName NVARCHAR(255) NOT NULL,
    UserName NVARCHAR(255) NOT NULL,
    Password NVARCHAR (255) NOT NULL,
    Bio NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255),
    Picture NVARCHAR(255)
);

CREATE TABLE Following (
    UserIdOne INT IDENTITY(1,1) NOT NULL,
    UserIdTwo INT IDENTITY(1,1) NOT NULL,
    CONSTRAINT PK_UserIdOne_UserIdTwo PRIMARY KEY(UserIdOne, UserIdTwo),
    CONSTRAINT FK_Following_UserId_Users FOREIGN KEY (UserIdTwo) 
        REFERENCES Users (UserId) ON DELETE CASCADE
);

CREATE TABLE Likes (
    UserId INT NOT NULL,
    PostId INT NOT NULL,
    CONSTRAINT PK_UserId_PostId PRIMARY KEY(UserId, PostId),
    CONSTRAINT FK_Likes_UserId_Users FOREIGN KEY (UserId) 
        REFERENCES Users (UserId) ON DELETE CASCADE
);

CREATE TABLE Category (
    CategoryId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    CategoryName NVARCHAR(255)
);

CREATE TABLE Media (
    MediaId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Rating INT,
    MediaName NVARCHAR(255),
    Description NVARCHAR(MAX),
    CategoryId INT,
    MediaURL NVARCHAR(MAX),
    CONSTRAINT FK_Media_CategoryId_Category FOREIGN KEY (CategoryId) 
        REFERENCES Category (CategoryId)
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

CREATE TABLE Notifications (
    NotificationId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    PostID INT NOT NULL,
    Status BIT NOT NULL,
    Reciver INT NOT NULL,
    Sender INT NOT NULL,
    NotificationType NVARCHAR(255) NOT NULL,
    CONSTRAINT FK_Notificatoins_Reciver_UserId_Users FOREIGN KEY (Reciver) 
        REFERENCES Users (UserId) ON DELETE CASCADE,
    CONSTRAINT FK_Notifications_Sender_UserId_Users FOREIGN KEY (Sender) 
        REFERENCES Users (UserId) ON DELETE CASCADE
);

CREATE 