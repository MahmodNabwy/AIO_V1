﻿using AIO.Contracts.IServices.Repositories.Auth.SecurityQuestions;
using AIO.Core.Entities.SecurityQuestions;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;

namespace AIO.Infrastructure.Services.Repositories
{
    internal class SecurityQuestionRepository : GenericRepository<SecurityQuestion>, ISecurityQuestionRepository
    {
        private readonly AIODBContext _db;
        public SecurityQuestionRepository(AIODBContext context) : base(context)
        {
            _db = context;
        }


    }
}
