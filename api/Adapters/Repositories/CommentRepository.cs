using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBcontext _Context;
        public CommentRepository(ApplicationDBcontext dBcontext)
        {
            _Context = dBcontext;
        }

        public async Task<Comment?> Createasync(Comment comment)
        {
            await _Context.comments.AddAsync(comment);
            await _Context.SaveChangesAsync();
            return comment;
        }

        public async Task<bool> Deleteasync(int id)
        {
            var comment = await _Context.comments.FindAsync(id);

            if (comment == null)
            {
                return false;
            }

            _Context.comments.Remove(comment);
            await _Context.SaveChangesAsync();

            return true;
        }

        public IQueryable<Comment> GetAll()
        {
            return _Context.comments.Include(a => a.AppUser).AsQueryable();
        }

        public async Task<Comment?> Getbyid(int id)
        {
            var comment = await _Context.comments.Include(a => a.AppUser).FirstOrDefaultAsync(c => c.ID == id);

            if (comment == null) return null;

            return comment;
        }
    }
}