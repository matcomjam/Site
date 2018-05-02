//// ======================================
// Author: Ebenezer Monney
// Email:  info@ebenmonney.com
// Copyright (c) 2017 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

using DAL.Repositories.Interfaces;
using MatcomJamDAL.Repositories.Interfaces;

namespace DAL
{
    public interface IUnitOfWork
    {
        IProblemRepository Problems { get; }
        IContestRepository Contests { get; }
        ISolutionRepository Submissions { get; }
        IBlogRepository Blogs { get; }
        ICommentRepository Comments { get; }
        ICodeRepository Codes { get; }
        ILanguageRepository Languages { get; }
        ISyncServerRepository SyncServers { get; }

        int SaveChanges();
    }
}
