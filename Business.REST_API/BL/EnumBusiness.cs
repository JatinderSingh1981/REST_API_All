using AutoMapper;
using Microsoft.Extensions.Logging;
using Models.REST_API;
using Repository.REST_API;
using ViewModels.REST_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.REST_API;

namespace Business.REST_API
{
    public class EnumBusiness : IEnumBusiness
    {
        private readonly ILogger<EnumBusiness> _logger;

        public EnumBusiness(ILogger<EnumBusiness> logger)
        {
            _logger = logger;
        }
     
        public IEnumerable<T> GetList<T>() where T : Enumeration
        {
            //log here if needed
            return Enumeration.GetAll<T>();
        }
    }
}
