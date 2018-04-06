using System;
using System.Collections.Generic;
using System.Text;
using CodeFirstDatabase;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using MatcomJamDAL.Models.MyModel;
using MatcomJamDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MatcomJamDAL.Repositories
{
    class CommentRepository : Repository<Blog>, ICommentRepository
    {
        public CommentRepository(DbContext context) : base(context)
        {
        }
        
        private MJDbContext _appContext => (MJDbContext)_context;

        public IEnumerable<Comment> GetAllComments(Filter filter, int page = 1, int limit = 4)
        {
            throw new NotImplementedException();
        }

        public bool SaveComment(Comment model)
        {
            var comment = _appContext.Comments.Find(model.Id);
            if (comment == null)
            {
                comment = new Comment
                {
                    UserId = model.UserId,
                    BlogId = model.BlogId,
                    Description = model.Description
                };
                try
                {
                    _appContext.Comments.Add(comment);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            else
            {
                comment.Description = model.Description;
            }
            return _appContext.SaveChanges() >= 1;
        }

        public bool DeleteComment(int comment)
        {
            throw new NotImplementedException();
        }

        public Comment GetComment(int d)
        {
            throw new NotImplementedException();
        }

        public int GetCommentCount(Filter filter)
        {
            throw new NotImplementedException();
        }
    }
}
