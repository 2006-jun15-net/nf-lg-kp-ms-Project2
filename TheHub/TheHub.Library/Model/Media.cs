namespace TheHub.Library.Model
{
    public abstract class Media
    {
        public abstract int MediaId { get; set; }

        public abstract int GenreId { get; set; }

        public abstract int CategoryId { get; set; }

        public abstract string MediaName { get; set; }
        public abstract string Description { get; set; }

        public abstract int Rating { get; set; }

        public abstract string MediaUrl { get; set; }
    }
}