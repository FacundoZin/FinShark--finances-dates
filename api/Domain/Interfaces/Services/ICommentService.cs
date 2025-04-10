using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using api.Common;
using api.DTOs.Comment;
using api.Helpers;
using api.Models;

namespace api.Services
{
    public interface ICommentService
    {
        Task<List<CommentDto>> GetAllCommentsAsync(CommentQueryObject commentQueryObject);
        Task<Result<CommentDto>> GetCommentByIdAsync(int id);
        Task<Result<CommentDto>> CreateCommentAsync(CreateCommentDto createCommentDto, string symbol, string username);
        Task<Result<bool>> DeleteCommentAsync(int id);

    }
}