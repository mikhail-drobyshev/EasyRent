using System;
using Applications.BLL.Base.Services;

namespace BLL.LHVService
{
    public interface ILhvService: IBaseService
    {
        string GetConsent(string bearer);
    }
}