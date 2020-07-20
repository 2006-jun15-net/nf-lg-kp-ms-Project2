using System;
using System.Collections.Generic;
using System.Text;

namespace TheHub.Library.Model
{
    public class Review
    {
        private int _reviewId;
        private string _content;
        private int _mediaId;
        private int _userId;
        
        public DateTime ReviewDate { get; set; }
        public int? Likes { get; set; }
        public int? Rating { get; set; }
        public List<Comment> comments = new List<Comment>();
        public List<User> Likers = new List<User>();


        public int ReviewId
        {
            get => _reviewId;
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Review ID cannot be 0", nameof(value));
                }
                _reviewId = value;
            }
        }
        public string Content
        {
            get => _content;
            set
            {
                if (value == "")
                {
                    throw new ArgumentNullException("Contents of review may not be empty", nameof(value));
                }
                _content = value;
            }
        }
        public int MediaId
        {
            get => _mediaId;
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Media ID cannot be 0", nameof(value));
                }
                _mediaId = value;
            }
        }
        public int UserId
        {
            get => _userId;
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Review ID cannot be 0", nameof(value));
                }
                _userId = value;
            }
        }
    }
}
