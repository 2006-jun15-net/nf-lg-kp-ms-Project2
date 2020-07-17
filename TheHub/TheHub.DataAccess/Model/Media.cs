using System;
using System.Collections.Generic;

namespace TheHub.DataAccess.Model
{
    public partial class Media
    {
        public Media()
        {
            Reviews = new HashSet<Reviews>();
        }

        public int MediaId { get; set; }
        public int? Rating { get; set; }
        public string MediaName { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public string MediaUrl { get; set; }
        public int? GenreId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
