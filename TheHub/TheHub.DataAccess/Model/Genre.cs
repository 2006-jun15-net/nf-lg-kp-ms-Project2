using System;
using System.Collections.Generic;

namespace TheHub.DataAccess.Model
{
    public partial class Genre
    {
        public Genre()
        {
            Media = new HashSet<Media>();
        }

        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public virtual ICollection<Media> Media { get; set; }
    }
}
