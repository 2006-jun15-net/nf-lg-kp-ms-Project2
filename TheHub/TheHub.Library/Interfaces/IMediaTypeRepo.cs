using System;
using System.Collections.Generic;
using TheHub.Library.Model;

namespace TheHub.Library.Interfaces
{
    public interface IMediaTypeRepo
    {
        MediaType GetById(int id);

        IEnumerable<MediaType> GetAll();

        void Add(MediaType mediaType);

        void Update(MediaType mediaType);

        void Delete(int id);
    }
}
