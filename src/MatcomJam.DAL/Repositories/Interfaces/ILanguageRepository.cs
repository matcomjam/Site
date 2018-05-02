using System.Collections.Generic;
using CodeFirstDatabase;
using DAL.Repositories.Interfaces;

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
