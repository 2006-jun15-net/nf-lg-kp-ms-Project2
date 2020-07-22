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
                MediaTypesName = mediatype.Name
            };
            _context.MediaTypes.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.MediaTypes.Remove(_context.MediaTypes.Find(id));
            _context.SaveChanges();
        }

        public IEnumerable<MediaType> GetAll()
        {
            var entity = _context.MediaTypes.ToList();
            return entity.Select(c => new MediaType
            {
                Id = c.MediaTypesId,
                Name = c.MediaTypesName
            });
        }

        public MediaType GetById(int id)
        {
            var entity = _context.MediaTypes.Find(id);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            return new MediaType
            {
                Id = entity.MediaTypesId,
                Name = entity.MediaTypesName
            };
        }

        public void Update(MediaType mediaType)
        {
            var entity = _context.MediaTypes.Find(mediaType.Id);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            entity.MediaTypesName = mediaType.Name;
            _context.SaveChanges();
        }
    }
}
