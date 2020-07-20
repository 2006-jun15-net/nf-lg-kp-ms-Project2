using System;
using System.Collections.Generic;
using System.Text;

namespace TheHub.Library.Model
{
    public class Review
    {
        public int ReviewId
        {
            get => ReviewId;
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Review ID cannot be 0", nameof(value));
                }
                ReviewId = value;
            }
        }
        public string Content 
        {
            get => Content;
            set
            {
                if (value == "")
                {
                    throw new ArgumentNullException("Contents of review may not be empty", nameof(value));
                }
                Content = value;
            }
        }
        public int MediaId
        {
            get => MediaId;
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Media ID cannot be 0", nameof(value));
                }
                MediaId = value;
            }
        }
        public int UserId
        {
            get => UserId;
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Review ID cannot be 0", nameof(value));
                }
                UserId = value;
            }
        }
        public DateTime? ReviewDate { get; set; }
        public int? Likes { get; set; }
        public int? Rating { get; set; }
        public List<Comment> comments = new List<Comment>();
        public List<User> Likers = new List<User>();

    }
}
