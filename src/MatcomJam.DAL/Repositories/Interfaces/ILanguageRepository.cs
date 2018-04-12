using System;
using System.Collections.Generic;
using System.Text;
using CodeFirstDatabase;
using DAL.Repositories.Interfaces;
using MatcomJamDAL.Models.MyModel;

namespace MatcomJamDAL.Repositories.Interfaces
{
    public interface ILanguageRepository: IRepository<Language>
    {
        IEnumerable<Language> GetAllLanguages();
        bool SaveLanguage(Language model);
        bool DeleteLanguageById(int id);
        Language GetLanguage(int id);
        int GetLanguageCount();
    }
}
