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

        /// <summary>
        /// Adds a MediaType to the database
        /// </summary>
        /// <param name="mediatype">The MediaType</param>
        public void Add(MediaType mediatype)
        {
            var entity = new MediaTypes
            {
                MediaTypesName = mediatype.Name
            };
            _context.MediaTypes.Add(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes a MediaType from the database 
        /// </summary>
        /// <param name="id">The MediaType Id</param>
        public void Delete(int id)
        {
            var mediaType = _context.MediaTypes.Find(id);
            if(mediaType == null)
            {
                throw new ArgumentNullException();
            }
            _context.MediaTypes.Remove(mediaType);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets all the MediaTypes from the database
        /// </summary>
        /// <returns>The MediaTypes</returns>
        public IEnumerable<MediaType> GetAll()
        {
            var entity = _context.MediaTypes.ToList();
            return entity.Select(c => new MediaType
            {
                Id = c.MediaTypesId,
                Name = c.MediaTypesName
            });
        }

        /// <summary>
        /// Gets a MediaType by its Id
        /// </summary>
        /// <param name="id">The MediaType Id</param>
        /// <returns></returns>
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

        /// <summary>
        /// Updates a MediaType
        /// </summary>
        /// <param name="mediaType">The updated MediaType</param>
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
