﻿using System;
using System.Collections.Generic;
using System.Linq;
using CodeFirstDatabase;
using DAL.Repositories;
using MatcomJamDAL.Models.MyModel;
using MatcomJamDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MatcomJamDAL.Repositories
{
    class CodeRepository : Repository<Code>, ICodeRepository
    {
        public CodeRepository(DbContext context) : base(context)
        {
        }

        private MJDbContext _appContext => (MJDbContext)_context;

        public IEnumerable<Code> GetAllCodes(Filter filter)
        {
            return _appContext.Codes.ToList();
        }

        private static object obj = new Object();
        public Code GetNextPendingCode()
        {
            lock (obj)
            {
                var code = _appContext.Codes.Where(c => c.Status == "PENDING").OrderBy(c => c.CreatedDate).ToList()[0];
                code.Status = "RUNNIG";
                SaveCode(code);
                return code;
            }

        }

        public bool SaveCode(Code model)
        {
            var code = _appContext.Codes.Find(model.Id);
            if (code == null)
            {
                code = new Code
                {
                    Id = model.Id,
                    file = model.file,
                    FileName = model.FileName,
                    Text = model.Text,
                    Status = model.Status,
                    ProblemId = model.ProblemId,
                    LanguageId = model.LanguageId,
                    UserId = model.UserId
                };
                try
                {
                    _appContext.Codes.Add(code);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            else
            {
                code.Status = model.Status;
            }
            return _appContext.SaveChanges() >= 1;
        }

        public bool DeleteCode(int codeId)
        {
            throw new NotImplementedException();
        }

        public Code GetCode(int d)
        {
            throw new NotImplementedException();
        }

        public int GetCodeCount()
        {
            throw new NotImplementedException();
        }
    }
}
