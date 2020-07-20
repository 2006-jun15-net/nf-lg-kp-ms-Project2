using System;
using TheHub.Library.Model;
using Xunit;

namespace TheHub.Test
{
    public class UserTest
    {
        private readonly User user = new User();

        [Fact]
        public void FirstName_NonEmptyValue_StoreCorrectly()
        {
            string randomName = "Steven";
            user.FirstName = randomName;
            Assert.Equal(randomName, user.FirstName);
        }

        [Fact]
        public void FirstName_ThrowsException_WhenEmpty()
        {
            Assert.ThrowsAny<ArgumentException>(() => user.FirstName = String.Empty);
        }

        [Fact]
        public void LastName_NonEmptyValue_StoresCorrectly()
        {
            string randomName = "Spielberg";
            user.LastName = randomName;
            Assert.Equal(randomName, user.LastName);
        }

        [Fact]
        public void LastName_ThrowsException_WhenEmpty()
        {
            Assert.ThrowsAny<ArgumentException>(() => user.LastName = String.Empty);
        }

        [Fact]
        public void UserName_NonEmptyValue_StoresCorrectly()
        {
            string randomName = "SwaggySpielberg805";
            user.UserName = randomName;
            Assert.Equal(randomName, user.UserName);
        }

        [Fact]
        public void UserName_ThrowsException_WhenEmpty()
        {
            Assert.ThrowsAny<ArgumentException>(() => user.UserName = String.Empty);
        }

        [Fact]
        public void Password_NonEmptyValue_StoresCorrectly()
        {
            string randomPassword = "ETphonedHome123!";
            user.UserName = randomPassword;
            Assert.Equal(randomPassword, user.Password);
        }

        [Fact]
        public void Password_ThrowsException_WhenEmpty()
        {
            Assert.ThrowsAny<ArgumentException>(() => user.Password = String.Empty);
        }
    }
}
