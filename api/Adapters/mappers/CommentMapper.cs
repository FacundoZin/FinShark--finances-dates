using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using api.DTOs.Comment;
using api.Models;

namespace api.mappers
{
    public static class CommentMapper
    {
        public static CommentDto toCommentdto(this Comment commentmodel)
        {
            return new CommentDto
            {
                ID = commentmodel.ID,
                Title = commentmodel.Title,
                Content = commentmodel.Content,
                CreatedOn = commentmodel.CreatedOn,
                Createdby = commentmodel.AppUser.UserName,
                StockID = commentmodel.StockID
            };
        }

        public static Comment tocommentfromCreateCommentdto(this CreateCommentDto createCommentDto, int stockid, string UserID)
        {
            return new Comment
            {
                Title = createCommentDto.Title,
                Content = createCommentDto.Content,
                StockID = stockid,
                AppUserID = UserID
            };
        }

    }
}