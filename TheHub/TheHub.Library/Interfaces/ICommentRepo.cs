using System;
using System.Collections.Generic;
using TheHub.Library.Model;

namespace TheHub.Library.Interfaces
{
    public interface ICommentRepo
    {
        Comment GetById(int id);
        IEnumerable<Comment> GetByReviewId(int id);
        int Add(Comment comment);
        void DeleteById(int id);
        void Update(Comment comment);
    }
}
