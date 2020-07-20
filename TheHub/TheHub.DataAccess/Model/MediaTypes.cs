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

        public int MediaTypesId { get; set; }
        public string MediaTypesName { get; set; }

        public virtual ICollection<Media> Media { get; set; }
    }
}
