using System;
using TheHub.Library.Model;

namespace TheHub.Library.Interfaces
{
    public interface ICommentRepo
    {
        Comment GetById(int id);

        Comment GetByReviewerId(int id);

        void Add(Comment comment);

        void Update(Comment comment);

        void Delete(int id);
    }
}
