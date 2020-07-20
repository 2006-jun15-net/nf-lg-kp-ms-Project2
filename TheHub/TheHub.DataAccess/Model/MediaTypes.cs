using System;
using System.Collections.Generic;

namespace TheHub.DataAccess.Model
{
    public partial class MediaTypes
    {
        public MediaTypes()
        {
            Media = new HashSet<Media>();
        }

        public int MediaTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Media> Media { get; set; }
    }
}
