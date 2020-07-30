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

SELECT * FROM Following;

INSERT INTO Media (mediaName, GenreId, MediaTypesId, Description, Rating, Approved, composer, mediaUrl)
Values
	('The Vanishing Half', 3, 4, 'The Vignes twin sisters will always be identical. But after growing up together in a small, southern black community and running away at age sixteen, its not just the shape of their daily lives that is different as adults, its everything: their families, their communities, their racial identities.',
	9, 'true', 'Brit Bennett', 'https://books.google.com/books/content?id=gxGuDwAAQBAJ&printsec=frontcover&img=1&zoom=1&edge=curl&imgtk=AFLRE722STrnIR7SA1AyFYdKiEi2_EIrGBznbWS6_7Q2KE8BoFW5mykCY8WUQGTv_NeAylZ14TWxV_m4dCJ4Pf6SWsjN4iOS2Sf8IOkcMK8eTDkyksWPowmWvNA2pRc306NnyK0838_k'),
	('The Glass Hotel', 6, 4, 'follows the aftermath of a disturbing graffiti incident at a hotel on Vancouver Island and the collapse of an international Ponzi scheme.', 8, 'true', 'Emily St. John Mandel', 'https://upload.wikimedia.org/wikipedia/en/4/40/The_Glass_Hotel_%28Emily_St._John_Mandel%29.png'),
	('A Burning', 8, 4, 'Set in Kolkata, India, the novel tells the story of its central character Jivan, a woman who witnesses a terrorist attack on an Indian train while it is stopped in a station.', 9, 'true', 'Megha Majumdar', ' https://books.google.com/books/content?id=oRGuDwAAQBAJ&printsec=frontcover&img=1&zoom=1&edge=curl&imgtk=AFLRE73CnXjaYn7chtoBo9NYRV7D8Fd5KLjQ0ZVPVUtuyMlwgPXxIErIsOvahE_DJtvgwh4za1JlpDlyVAFAnQZOMzh-XhlgHWWYeA6HFLtGq_ztaUvaPBoEb1Kfj8TPSYEScHgxFMug'),
	('Uncanny Valley', 3, 4, 'The book focuses on Wieners transition from the publishing industry to a series of jobs at technology companies, and her gradual disillusionment with the technology industry.', 8, 'true', 'Anna Wiener', 'https://upload.wikimedia.org/wikipedia/en/2/2a/Uncanny_Valley_%28Anna_Wiener%29.png'),
	('Death in Her Hands', 6, 4, 'Vesta Gul, a 72-year-old widow, is walking her dog in the woods and finds a note that reads: "Her name was Magda. Nobody will ever know who killed her. It wasnt me. Here is her dead body." However, no body is in sight. Vesta becomes obsessed with discovering who Magda was and the circumstances surrounding her death.', 9, 'true', 'Ottessa Moshfegh',
	'https://upload.wikimedia.org/wikipedia/en/a/aa/Death_in_Her_Hands_%28Ottessa_Moshfegh%29.png');

INSERT INTO Media (mediaName, GenreId, MediaTypesId, Description, Rating, Approved, composer, mediaUrl)
Values
    ('The Last Of Us: Part 2',1, 1, 'The Last of Us Part II is a 2020 action-adventure game developed by Naughty Dog and published by Sony Interactive Entertainment for the PlayStation 4. Set five years after The Last of Us (2013), players control two characters in a post-apocalyptic United States: Ellie, who sets out for revenge after suffering a great tragedy, and Abby Anderson, a soldier who becomes involved in a conflict between her militia and a cult.', 2, 'true', 'Naughty Dog', 'https://upload.wikimedia.org/wikipedia/en/4/4f/TLOU_P2_Box_Art_2.png%27'),
    ('Animal Crossing: New Horizons',4, 1, 'In New Horizons, the player assumes the role of a customizable character who moves to a deserted island after purchasing a package from Tom Nook, a tanuki character who has appeared in every entry in the Animal Crossing series.', 7, 'true', 'Nintendo EPD', 'https://upload.wikimedia.org/wikipedia/en/1/1f/Animal_Crossing_New_Horizons.jpg%27'),
    ('The Outer Worlds', 4, 1, 'The Outer Worlds is an action role-playing video game featuring a first-person perspective. In the early stages of the game, the player can create their own character and unlock a ship, which acts as the games central hub space.', 8, 'true', 'Obsidian Entertainment', 'https://upload.wikimedia.org/wikipedia/en/e/e7/The_Outer_Worlds_cover_art.png%27');

UPDATE Media
SET GenreID = 3, MediaTypesId = 1 Where MediaName = 'NBA 2k20';

INSERT INTO Media (mediaName, GenreId, MediaTypesId, Description, Rating, Approved, composer, mediaUrl)
Values
	('Breaking Bad', 3, 5, 'tells the story of Walter White (Bryan Cranston), an underemployed and depressed high school chemistry teacher who is struggling with a recent diagnosis of stage-three lung cancer. White turns to a life of crime, partnering with his former student Jesse Pinkman (Aaron Paul), by producing and distributing crystallized methamphetamine to secure his familys financial future before he dies, while navigating the dangers of the criminal underworld. ',
 	10, 'true', 'Vince Gilligan', 'https://upload.wikimedia.org/wikipedia/en/6/61/Breaking_Bad_title_card.png'),
	('Friends', 2, 5, 'Friends is an American sitcom television series, created by David Crane and Marta Kauffman, which aired on NBC from September 22, 1994, to May 6, 2004, lasting ten seasons. With an ensemble cast starring Jennifer Aniston, Courteney Cox, Lisa Kudrow, Matt LeBlanc, Matthew Perry and David Schwimmer, the show revolves around six friends in their 20s and 30s who live in Manhattan, New York City.', 8, 'true', 'David Crane', 'https://www.gstatic.com/tv/thumb/tvbanners/7892603/p7892603_b_v8_ad.jpg'),
	('The Office', 2, 5, 'The Office is an American mockumentary sitcom television series that depicts the everyday lives of office employees in the Scranton, Pennsylvania, branch of the fictional Dunder Mifflin Paper Company. It aired on NBC from March 24, 2005, to May 16, 2013, lasting a total of nine seasons. It is an adaptation of the 2001-2003 BBC series of the same name, being adapted for American television by Greg Daniels, a veteran writer for Saturday Night Live, King of the Hill, and The Simpsons. ', 9, 'true', 'Greg Daniels', 'https://upload.wikimedia.org/wikipedia/en/5/58/TheOffice_S7_DVD.jpg'),
	('Mad Men', 3, 5, 'Mad Men begins at the fictional Sterling Cooper advertising agency on Madison Avenue in Manhattan, New York City and later at the newly created firm of Sterling Cooper Draper Pryce (later named Sterling Cooper & Partners), located near the Time-Life Building at 1271 Sixth Avenue. According to the pilot episode, the phrase "Mad men" was a slang term coined in the 1950s by advertisers working on Madison Avenue to refer to themselves, "Mad" being short for "Madison".', 8, 'true', 'Matthew Weiner', 'https://www.gstatic.com/tv/thumb/tvbanners/10426355/p10426355_b_v8_aa.jpg');	

UPDATE Media
SET mediaUrl = 'https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg'
Where mediaId = 4;

INSERT INTO Media (mediaName, GenreId, MediaTypesId, Description, Rating, Approved, composer, mediaUrl)
Values
    ('Hollywoods Bleeding', 18, 3, 'Hollywoods Bleeding is the third studio album by American rapper Post Malone. It was released on September 6, 2019, by Republic Records. The album features guest appearances from DaBaby, Future, Halsey, Meek Mill, Lil Baby, Ozzy Osbourne, Travis Scott, SZA, Swae Lee, and Young Thug.', 8, 'true', 'Post Malone', 'https://upload.wikimedia.org/wikipedia/en/5/58/Post_Malone_-_Hollywood%27s_Bleeding.png%27'),
    ('Heaven or Hell', 18, 3, 'Heaven or Hell is the debut studio album by American rapper and singer Don Toliver. It was released on March 13, 2020, by Cactus Jack Records and Atlantic Records. The album features guest appearances by Travis Scott, Kaash Paige, Quavo and Offset from the hip hop trio Migos, and Sheck Wes.', 7, 'true', 'Don Toliver', 'https://upload.wikimedia.org/wikipedia/en/a/a0/Don_Toliver_-_Heaven_or_Hell.png%27'),
    ('Views', 18, 3, 'Views is the fourth studio album by Canadian rapper Drake. It was released on April 29, 2016, by Cash Money Records, Republic Records, and Young Money Entertainment. Recording sessions took place from 2015 to 2016, with both Drake and his longtime collaborator and record producer 40 serving as the records executive producers.', 9, 'true', 'Drake', 'https://upload.wikimedia.org/wikipedia/en/a/af/Drake_-_Views_cover.jpg%27'),
    ('After Hours', 18, 3, 'After Hours is the fourth studio album by Canadian singer The Weeknd. The album was released on March 20, 2020, by XO and Republic Records. The album was produced primarily by The Weeknd, along with a variety of high-profile producers such as DaHeala, Illangelo, Max Martin and Metro Boomin, all of whom The Weeknd had worked with previously.', 8, 'true', 'The Weeknd', 'https://upload.wikimedia.org/wikipedia/en/c/c1/The_Weeknd_-_After_Hours.png%27');

UPDATE Users
SET picture = 'https://media-exp1.licdn.com/dms/image/C5603AQFl1CUOXDHvcA/profile-displayphoto-shrink_200_200/0?e=1601510400&v=beta&t=Icgeow6UAZ_Jqu5MQfaekTotv4Ndm97TFOdAJ1hXpFQ'
Where UserId = 6;