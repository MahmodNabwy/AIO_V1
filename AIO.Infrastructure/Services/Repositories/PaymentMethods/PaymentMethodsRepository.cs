
using AIO.Core.Entities.PaymentMethods;
using AIO.Core.IServices.Repositories.PaymentMethods;
using AIO.Core.IServices.Repositories.Suppliers;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.PaymentMethods
{
    public class PaymentMethodsRepository : GenericRepository<PaymentMethod>, IPaymentMethodsRepository
    {
        private readonly AIODBContext _db;
        public PaymentMethodsRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }
    }
}
