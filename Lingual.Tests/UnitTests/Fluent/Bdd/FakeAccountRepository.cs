using System.Collections.Generic;
using Lingual.Tests.Domain;

namespace Lingual.Tests.Fluent.Bdd
{
    public class FakeAccountRepository : IRepository<Account>
    {
        public Dictionary<long, Account> Accounts = new Dictionary<long, Account>();

        public Account Get(long id)
        {
            if (!Accounts.ContainsKey(id))
                return null;
            return Accounts[id];
        }
    }
}