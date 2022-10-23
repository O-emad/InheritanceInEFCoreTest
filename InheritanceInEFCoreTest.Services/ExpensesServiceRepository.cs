
using InheritanceInEFCoreTest.Services;
using InheritanceInEFCoreTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InheritanceInEFCoreTest.Data;

namespace InheritanceInEFCoreTest.Services
{
    public class ExpensesServiceRepository : BaseServiceRepository<Expenses>, IExpensesServiceRepository
    {
        public ExpensesServiceRepository(WorkFlowContext context) : base(context)
        {
        }

        public override void Add(Expenses obj)
        {
            if (obj == null) throw new ArgumentNullException("Expenses: The expenses object to be added is null");
            if (obj.FromAccount is null && (obj.FromAccountId is null || obj.FromAccountId == Guid.Empty))
                throw new ArgumentNullException("Expenses: The expenses object doesn't contain accounts to perform transaction");
            if (!context.Accounts.Any(a => a.Id == obj.FromAccountId))
                throw new ArgumentNullException("Expenses: The expenses object contains invalid accounts,accounts couldn't be found");
            if (obj.Amount < 0) throw new ArgumentOutOfRangeException("Expenses->Amount: The expenses amount cannot be less than zero");
            using (var contextTransation = context.Database.BeginTransaction())
            {
                var account = context.Accounts.Where(a => a.Id == obj.FromAccountId).FirstOrDefault();
                if (account!.Balance >= obj.Amount)
                {
                    account.OutTransaction!.Add(obj);
                    account.Balance -= obj.Amount;
                    context.SaveChanges();
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Account->Balance: Selected account balance is less than the transaction amount");
                }

                contextTransation.Commit();
            }
        }
    }
}
