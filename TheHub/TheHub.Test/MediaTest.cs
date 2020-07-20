using System;
using System.Collections.Generic;
using System.Text;
using TheHub.Library.Model;
using Xunit;

namespace TheHub.Test
{
    public class MediaTest
    {
        private readonly Media media = new Media();

        [Fact]
        public void MediaName_NonEmptyValue_StoreCorrectly()
        {
            string randomName = "Star Wars Episode III: Revenge of the Sith";
            media.MediaName = randomName;
            Assert.Equal(randomName, media.MediaName);
        }

        [Fact]
        public void MediaName_ThrowsException_WhenEmpty()
        {
            Assert.ThrowsAny<ArgumentException>(() => media.MediaName = String.Empty);
        }
    }
}
