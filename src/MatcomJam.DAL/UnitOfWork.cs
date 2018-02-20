// ======================================
// Author: Ebenezer Monney
// Email:  info@ebenmonney.com
// Copyright (c) 2017 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstDatabase;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using MatcomJamDAL.Repositories;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly MJDbContext _context;

        private IProblemRepository _problems;
        private IContestRepository _contests;
        private ISolutionRepository _submissions;
        private IBlogRepository _blogs;

        //ICustomerRepository _customers;
        //IProductRepository _products;
        //IOrdersRepository _orders;
        
        public UnitOfWork(MJDbContext context)
        {
            _context = context;
        }
        //public ICustomerRepository Customers
        //{
        //    get
        //    {
        //        if (_customers == null)
        //            _customers = new CustomerRepository(_context);

        //        return _customers;
        //    }
        //}



        //public IProductRepository Products
        //{
        //    get
        //    {
        //        if (_products == null)
        //            _products = new ProductRepository(_context);

        //        return _products;
        //    }
        //}



        //public IOrdersRepository Orders
        //{
        //    get
        //    {
        //        if (_orders == null)
        //            _orders = new OrdersRepository(_context);

        //        return _orders;
        //    }
        //}


        public IProblemRepository Problems => _problems ?? (_problems = new ProblemRepository(_context));

        public IContestRepository Contests => _contests ?? (_contests = new ContestRepository(_context));
        public ISolutionRepository Submissions => _submissions ?? (_submissions = new SolutionRepository(_context));
        public IBlogRepository Blogs => _blogs ?? (_blogs = new BlogRepository(_context));

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
