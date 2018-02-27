//// ======================================
// Author: Ebenezer Monney
// Email:  info@ebenmonney.com
// Copyright (c) 2017 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork
    {
        IProblemRepository Problems { get; }
        IContestRepository Contests { get; }
        ISolutionRepository Submissions { get; }
        IBlogRepository Blogs { get; }


        //ICustomerRepository Customers { get; }
        //IProductRepository Products { get; }
        //IOrdersRepository Orders { get; }


        int SaveChanges();
    }
}
