using System.Collections.Generic;
using CodeFirstDatabase;
using MatcomJamDAL.Models.MyModel;

namespace MatcomJamDAL.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetAllComments(int blogId);
        bool SaveComment(Comment comment);
        bool DeleteComment(int comment);
        Comment GetComment(int d);
        int GetCommentCount(Filter filter);
    }
}
