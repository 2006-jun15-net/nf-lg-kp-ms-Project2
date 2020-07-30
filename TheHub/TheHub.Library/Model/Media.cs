using System;

namespace TheHub.Library.Model
{
    public class Media
    {
        public int MediaId { get; set; }

        public int? GenreId { get; set; }

        public int? MediaTypeId { get; set; }

        public string _mediaName { get; set; }

        public string Composer { get; set; }

        public string Description { get; set; }

        public int? Rating { get; set; }

        public string MediaUrl { get; set; }

        public bool Approved { get; set; }
        

        public string MediaName
        {
            get => _mediaName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Media Name cannot be empty", nameof(value));
                }
                _mediaName = value;
            }
        }
    }
}