using System;
using Microsoft.EntityFrameworkCore;
using TheHub.DataAccess.Model;
using TheHub.DataAccess.Repository;
using TheHub.Library.Interfaces;
using TheHub.Library.Model;
using Xunit;
using Media = TheHub.Library.Model.Media;

namespace TheHub.Test.Repository
{
    public class MediaRepositoryTest
    {
        private static readonly Media media = new Media
        {
            MediaName = "test media name",
            Composer = "test composer",
            Description = "hello, this is a test description",
            Rating = 9,
            MediaUrl = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg",
            Approved = true
        };

        private IMediaRepo GetInMemoryMediaRepository()
        {
            DbContextOptions<Project2Context> options;

            var builder = new DbContextOptionsBuilder<Project2Context>();

            builder.UseInMemoryDatabase("Project2InMemoryMedia");
            options = builder.Options;

            Project2Context project2Context = new Project2Context(options);

            project2Context.Database.EnsureDeleted();
            project2Context.Database.EnsureCreated();

            return new MediaRepository(project2Context);
        }

        [Fact]
        public void MediaRepository_Add_AddsMedia()
        {
            //arrange
            IMediaRepo mediaRepo  = GetInMemoryMediaRepository();

            //act
            mediaRepo.Add(media);
            Media saveMedia = mediaRepo.GetByTitle(media.MediaName);

            //assert
            Assert.Equal(1, saveMedia.MediaId);
            Assert.Equal("test media name", saveMedia.MediaName);
            Assert.Equal("test composer", saveMedia.Composer);
            Assert.Equal("hello, this is a test description", saveMedia.Description);
            Assert.Equal(9, saveMedia.Rating);
            Assert.Equal("https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg", saveMedia.MediaUrl);
            Assert.True(saveMedia.Approved);
        }

        [Fact]
        public void MediaRepository_Update_UpdatesMedia()
        {
            //arrange
            IMediaRepo mediaRepo = GetInMemoryMediaRepository();

            //act
            mediaRepo.Add(media);
            Media saveMedia = mediaRepo.GetByTitle(media.MediaName);
            saveMedia.Composer = "update composer";
            mediaRepo.Update(saveMedia);

            Media updateMedia = mediaRepo.GetByTitle(media.MediaName);

            //assert
            Assert.Equal("update composer", updateMedia.Composer);
        }

        [Fact]
        public void MediaRepository_GetById_GetsMedia()
        {
            //arrange
            IMediaRepo mediaRepo = GetInMemoryMediaRepository();

            //act
            mediaRepo.Add(media);
            Media saveMedia = mediaRepo.GetById(1);

            //Assert
            Assert.Equal(1, saveMedia.MediaId);
            Assert.Equal("test media name", saveMedia.MediaName);
            Assert.Equal("test composer", saveMedia.Composer);
            Assert.Equal("hello, this is a test description", saveMedia.Description);
            Assert.Equal(9, saveMedia.Rating);
            Assert.Equal("https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg", saveMedia.MediaUrl);
            Assert.True(saveMedia.Approved);
        }

        [Fact]
        public void MediaRepository_GetById_ThrowsExceptionWhenIdNotFound()
        {
            //arrange
            IMediaRepo mediaRepo = GetInMemoryMediaRepository();

            //act
            mediaRepo.Add(media);

            //assert
            Assert.ThrowsAny<ArgumentNullException>(() => mediaRepo.GetById(2));
        }

        [Fact]
        public void MediaRepository_GetByUserName_ThrowsExceptionWhenUserNameNotFound()
        {
            //arrange
            IMediaRepo mediaRepo = GetInMemoryMediaRepository();

            //act
            mediaRepo.Add(media);

            //assert
            Assert.ThrowsAny<ArgumentNullException>(() => mediaRepo.GetByTitle("NotExistingTitle"));
        }

        [Fact]
        public void MediaRepository_Update_ThrowsExceptionWhenUserIdNotFound()
        {
            //arrange
            IMediaRepo mediaRepo = GetInMemoryMediaRepository();

            //act
            mediaRepo.Add(media);
            Media saveMedia = mediaRepo.GetByTitle(media.MediaName);
            saveMedia.MediaId = 0;

            //assert
            Assert.ThrowsAny<ArgumentNullException>(() => mediaRepo.Update(saveMedia));
        }
    }
}
