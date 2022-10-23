using InheritanceInEFCoreTest.Data;
using InheritanceInEFCoreTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceInEFCoreTest.Services
{
    public class InvoiceServiceRepository : BaseServiceRepository<Invoice>, IInvoiceServiceRepository
    {
        public InvoiceServiceRepository(WorkFlowContext context) : base(context)
        {
        }

        public override void Add(Invoice obj)
        {
            if (obj == null) throw new ArgumentNullException("Invoice: The invoice object to be added is null");
            if (obj.ToAccount is null && (obj.ToAccountId is null || obj.ToAccountId == Guid.Empty))
                throw new ArgumentNullException("Invoice: The invoice object doesn't contain accounts to perform transaction");
            if (!context.Accounts.Any(a => a.Id == obj.ToAccountId))
                throw new ArgumentNullException("Invoice: The invoice object contains invalid accounts,accounts couldn't be found");
            if (obj.Amount < 0) throw new ArgumentOutOfRangeException("Invoice->Amount: The invoice amount cannot be less than zero");
            using (var contextTransation = context.Database.BeginTransaction())
            {
                var account = context.Accounts.Where(a => a.Id == obj.ToAccountId).FirstOrDefault();
                    account!.InTransaction!.Add(obj);
                    account.Balance += obj.Amount;
                    context.SaveChanges();
                contextTransation.Commit();
            }
        }
    }
}
