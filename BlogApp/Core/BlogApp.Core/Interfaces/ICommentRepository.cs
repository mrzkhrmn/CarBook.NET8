﻿using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<IReadOnlyList<Comment>> GetCommentsByPostIdAsync(int postId);
    }
}
