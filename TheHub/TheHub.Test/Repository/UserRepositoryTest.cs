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
    public class UserRepositoryTest
    {
        private static readonly User user = new User
        {
            FirstName = "test",
            LastName = "tester",
            UserName = "testest",
            Bio = "Test bio",
            Email = "test@email.com",
            Password = "testPW",
            AdminUser = false,
            ConfirmPassword = "testPW"
        };
        [Fact]
        public void UserRepository_Add_AddsUser()
        {
            //arrange
           IUserRepo ur = GetInMemoryUserRepository();

            //act
            ur.Add(user);
            User savedUser = ur.GetById(1);

            //assert
            Assert.Equal(1, savedUser.UserId);
            Assert.Equal("test", savedUser.FirstName);
            Assert.Equal("tester", savedUser.LastName);
            Assert.Equal("testest", savedUser.UserName);
            Assert.Equal("Test bio", savedUser.Bio);
            Assert.Equal("test@email.com", savedUser.Email);
            Assert.Equal("testPW", savedUser.Password);
            Assert.False(savedUser.AdminUser);
        }

        [Fact]
        public void UserRepository_Update_UpdatesUser()
        {
            //arrange
            IUserRepo ur = GetInMemoryUserRepository();

            //act
            ur.Add(user);
            User savedUser = ur.GetById(1);
            savedUser.FirstName = "updatedUser";
            ur.Update(savedUser);
            User updatedUser = ur.GetById(1);

            //assert
            Assert.Equal("updatedUser", updatedUser.FirstName);
        }

        [Fact]
        public void UserRepository_GetById_GetsUser()
        {
            //arrange
            IUserRepo ur = GetInMemoryUserRepository();

            //act
            ur.Add(user);
            User savedUser = ur.GetById(1);

            //Assert
            Assert.Equal(1, savedUser.UserId);
            Assert.Equal("test", savedUser.FirstName);
            Assert.Equal("tester", savedUser.LastName);
            Assert.Equal("testest", savedUser.UserName);
            Assert.Equal("Test bio", savedUser.Bio);
            Assert.Equal("test@email.com", savedUser.Email);
            Assert.Equal("testPW", savedUser.Password);
        }

        [Fact]
        public void UserRepository_GetById_ThrowsExceptionWhenIdNotFound()
        {
            //arrange
            IUserRepo ur = GetInMemoryUserRepository();

            //act
            ur.Add(user);
            //there should be only 1 user with id=1

            //assert
            Assert.ThrowsAny<ArgumentNullException>(() => ur.GetById(2));
        }
       
        [Fact]
        public void UserRepository_Update_ThrowsExceptionWhenUserIdNotFound()
        {
            //arrange
            IUserRepo ur = GetInMemoryUserRepository();

            //act
            ur.Add(user);
            User savedUser = ur.GetById(1);
            savedUser.UserId = 0;//userId should is 1 in database and changing it to zero will throw exception
            
            //assert
            Assert.ThrowsAny<ArgumentNullException>(() => ur.Update(savedUser));
        }
        private IUserRepo GetInMemoryUserRepository()
        {
            DbContextOptions<Project2Context> options;
            var builder = new DbContextOptionsBuilder<Project2Context>();
            builder.UseInMemoryDatabase("Project2InMemory");
            options = builder.Options;
            Project2Context project2Context = new Project2Context(options);
            project2Context.Database.EnsureDeleted();
            project2Context.Database.EnsureCreated();
            return new UserRepository(project2Context);
        }
    }
}
