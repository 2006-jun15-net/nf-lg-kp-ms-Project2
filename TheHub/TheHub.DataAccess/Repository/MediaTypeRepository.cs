using System;
using System.Collections.Generic;
using System.Linq;
using TheHub.DataAccess.Model;
using TheHub.Library.Interfaces;
using TheHub.Library.Model;
using MediaType = TheHub.Library.Model.MediaType;

namespace TheHub.DataAccess.Repository
{
    public class MediaTypeRepository : IMediaTypeRepo
    {
        private readonly Project2Context _context;

        public MediaTypeRepository(Project2Context context)
        {
            _context = context;
        }

        public void Add(MediaType mediatype)
        {
            var entity = new MediaTypes
            {
                Name = mediatype.Name
            };
            _context.MediaType.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.MediaType.Remove(_context.MediaType.Find(id));
            _context.SaveChanges();
        }

        public IEnumerable<MediaType> GetAll()
        {
            var entity = _context.MediaType;
            return entity.Select(c => new MediaType
            {
                Id = c.MediaTypeId,
                Name = c.Name
            });
        }

        public MediaType GetById(int id)
        {
            var entity = _context.MediaType.Find(id);
            return new MediaType
            {
                Id = entity.MediaTypeId,
                Name = entity.Name
            };
        }

        public void Update(MediaType mediaType)
        {
            var entity = _context.MediaType.Find(mediaType.Id);
            entity.Name = mediaType.Name;
            _context.SaveChanges();
        }
    }
}
