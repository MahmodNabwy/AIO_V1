using AIO.Contracts.DTOs.Setter.InsuranceCondition;
using AIO.Core.Entities.Insurance_conditions;
using AIO.Core.IServices.Repositories.Insurance_Conditions;
using AIO.Core.IServices.Repositories.Suppliers;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.Insurance_Conditions
{
    public class InsuranceConditionsRepository : GenericRepository<Insurance_Condition>, IInsuranceConditionsRepository
    {
        private readonly AIODBContext _db;
         

        public InsuranceConditionsRepository(AIODBContext context) : base(context)
        {
            _db = context;            
        }
      
    }
}
