using System;
using System.Collections.Generic;
using System.Text;
using MatcomJamDAL.Models.MyModel;

namespace MatcomJamDAL.Repositories.Interfaces
{
    public interface ICodeRepository
    {
        IEnumerable<Code> GetAllCodes(Filter filter);
        bool SaveCode(Code code);
        bool DeleteCode(int codeId);
        Code GetCode(int d);
        int GetCodeCount();
    }
}
