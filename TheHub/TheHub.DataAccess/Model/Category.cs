using System;
using System.Collections.Generic;

namespace TheHub.DataAccess.Model
{
    public partial class Category
    {
        public Category()
        {
            Media = new HashSet<Media>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Media> Media { get; set; }
    }
}
