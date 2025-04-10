using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface ICommentRepository
    {
        IQueryable<Comment> GetAll();
        Task<Comment?> Getbyid(int id);
        Task<Comment?> Createasync(Comment comment);
        Task<bool> Deleteasync(int id);
    }
}