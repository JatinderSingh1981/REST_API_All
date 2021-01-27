using Common.REST_API;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.REST_API
{
    public interface IEnumBusiness
    {
        IEnumerable<T> GetList<T>() where T : Enumeration;
    }
}