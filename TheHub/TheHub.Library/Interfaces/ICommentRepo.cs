﻿using System;
using System.Collections.Generic;
using TheHub.Library.Model;

namespace TheHub.Library.Interfaces
{
    public interface ICommentRepo
    {
        Comment GetById(int id);
        List<Comment> GetByReviewId(int id);
        void Add(Comment comment);
        void DeleteById(int id);
        void Update(Comment comment);
    }
}
