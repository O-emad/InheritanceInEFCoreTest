using InheritanceInEFCoreTest.Data;
using InheritanceInEFCoreTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceInEFCoreTest.Services
{
    public class TransactionServiceRepository : BaseServiceRepository<Transaction>, ITransactionServiceRepository
    {
        public TransactionServiceRepository(WorkFlowContext context) : base(context)
        {
        }

        public override void Add(Transaction obj)
        {
            if (obj == null) throw new ArgumentNullException("Transaction: The transaction object to be added is null");
            if ((obj.ToAccount == null || obj.FromAccount == null) &&
               ((obj.ToAccountId == null || obj.ToAccountId == Guid.Empty) && (obj.FromAccountId == null || obj.FromAccountId == Guid.Empty))) 
                throw new ArgumentNullException("Transaction: The transaction object doesn't contain accounts to perform transaction");
            if (!(context.Accounts.Any(a => a.Id == obj.ToAccountId) && context.Accounts.Any(a=>a.Id == obj.FromAccountId))) 
                throw new ArgumentNullException("Transaction: The transaction object contains invalid accounts,accounts couldn't be found");
            if (obj.Amount < 0) throw new ArgumentOutOfRangeException("Transaction->Amount: The transaction amount cannot be less than zero");
            using (var contextTransaction = context.Database.BeginTransaction())
            {
                var fromAccount = context.Accounts.FirstOrDefault(a => a.Id == obj.FromAccountId);
                
                if (fromAccount!.Balance >= obj.Amount) {
                    var toAccount = context.Accounts.FirstOrDefault(a => a.Id == obj.ToAccountId);
                    fromAccount.Balance -= obj.Amount;
                    toAccount!.Balance +=obj.Amount;
                    context.SaveChanges();
                    context.Transactions.Add(obj);
                    context.SaveChanges();
                    contextTransaction.Commit();
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Account->Balance: Selected account balance is less than the transaction amount");
                }
            }
        }
    }
}
