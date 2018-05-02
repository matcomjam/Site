using System;
using System.Collections.Generic;
using System.Linq;
using CodeFirstDatabase;
using DAL.Repositories;
using MatcomJamDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MatcomJamDAL.Repositories
{
    class LanguageRepository: Repository<Language>, ILanguageRepository
    {
        public LanguageRepository(DbContext context) : base(context)
        {
        }
        private MJDbContext _appContext => (MJDbContext)_context;

        public IEnumerable<Language> GetAllLanguages()
        {
            return _appContext.Languages.OrderBy(l => l.Id).ToList();
        }

        public bool SaveLanguage(Language model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteLanguageById(int id)
        {
            throw new NotImplementedException();
        }

        public Language GetLanguage(int id)
        {
            throw new NotImplementedException();
        }

        public int GetLanguageCount()
        {
            throw new NotImplementedException();
        }
    }
}
