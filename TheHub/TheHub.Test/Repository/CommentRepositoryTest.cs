using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TheHub.DataAccess.Model;
using TheHub.DataAccess.Repository;
using TheHub.Library.Interfaces;
using TheHub.Library.Model;
using Xunit;

namespace TheHub.Test.Repository
{
    public class CommentRepositoryTest
    {
        private static readonly Comment comment = new Comment
        {
            Content = "test test test",
            ReviewId = 1,
            UserId = 1
        };

        [Fact]
        public void CommentRepository_Add_AddsComment()
        {
            //arrange
            ICommentRepo cr = GetInMemoryCommentRepository();

            //act
            cr.Add(comment);
            var savedComment = cr.GetById(1); //should have Id of 1

            //assert
            Assert.Equal(1, savedComment.CommentId);
            Assert.Equal(1, savedComment.ReviewId);
            Assert.Equal(1, savedComment.UserId);
            Assert.IsType<DateTime>(savedComment.Date);
        }
        [Fact]
        public void CommentRepository_GetById_ThrowsExceptionWhenIdNotFound()
        {
            //arrange
            ICommentRepo cr = GetInMemoryCommentRepository();

            //act
            cr.Add(comment);
            //Id should be 1

            //assert
            Assert.ThrowsAny<ArgumentNullException>(() => cr.GetById(0));
        }

        private ICommentRepo GetInMemoryCommentRepository()
        {
            DbContextOptions<Project2Context> options;
            var builder = new DbContextOptionsBuilder<Project2Context>();
            builder.UseInMemoryDatabase("Project2InMemory");
            options = builder.Options;
            Project2Context project2Context = new Project2Context(options);
            project2Context.Database.EnsureDeleted();
            project2Context.Database.EnsureCreated();
            return new CommentRepository(project2Context);
        }
    }
}
