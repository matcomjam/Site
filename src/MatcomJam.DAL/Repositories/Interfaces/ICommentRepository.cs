using System;
using System.Collections.Generic;
using System.Text;
using CodeFirstDatabase;
using MatcomJamDAL.Models.MyModel;

namespace MatcomJamDAL.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetAllComments(Filter filter, int page = 1, int limit = 4);
        bool SaveComment(Comment comment);
        bool DeleteComment(int comment);
        Comment GetComment(int d);
        int GetCommentCount(Filter filter);
    }
}
