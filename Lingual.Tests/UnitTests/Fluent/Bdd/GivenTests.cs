using System;
using Lingual.Fluent.Bdd;
using Lingual.Tests.Domain;
using NUnit.Framework;

namespace Lingual.Tests.Fluent.Bdd
{
    public abstract class AccountServiceTestBuilder
    {
        protected void contains_an_account(AccountContext context)
        {
            context.AccountId = 1234;
            context.Account = new Account
            {
                Id = context.AccountId
            };
            context.Repository.Accounts.Add(context.AccountId, context.Account);
        }

        protected void has_a_positive_balance(AccountContext context)
        {
            context.Account.TotalBalance = 100;
        }

        protected void has_had_activity_in_the_last_year(AccountContext context)
        {
            context.Account.LastActivityDate = DateTime.Today.Subtract(TimeSpan.FromDays(5));
        }

        protected void is_on_a_watch_list(AccountContext context)
        {
            context.WatchListService.Answer = true;
        }

        protected Account getting_the_account(AccountContext context)
        {
            return context.AccountService.GetAccount(context.AccountId);
        }
    }

    public class AccountServiceTests : AccountServiceTestBuilder
    {
        public ITestSource MyTest
        {
            get
            {
                return Given.an<AccountContext>()
                    .that(contains_an_account)
                    .which(has_a_positive_balance,
                           has_had_activity_in_the_last_year)
                    .but(is_on_a_watch_list)
                    .when(getting_the_account)
                    .then(the_account_status_should_be_frozen,
                          the_account_should_have_a_zero_balance,
                          the_account_should_have_an_activity_date_of_today);
            }
        }

        protected void the_account_status_should_be_frozen(Account account)
        {
            Assert.AreEqual(AccountStatuses.Frozen, account.Status);
        }

        protected void the_account_should_have_a_zero_balance(Account account)
        {
            Assert.AreEqual(0m, account.TotalBalance);
        }

        protected void the_account_should_have_an_activity_date_of_today(Account account)
        {
            Assert.AreEqual(DateTime.Today, account.LastActivityDate);
        }
    }

    public class AccountContext
    {
        public AccountContext()
        {
            Repository = new FakeAccountRepository();
            WatchListService = new FakeWatchListService();
            AccountService = new AccountService(Repository, WatchListService);
        }

        public long AccountId { get; set; }
        public Account Account { get; set; }
        public FakeAccountRepository Repository { get; private set; }
        public FakeWatchListService WatchListService { get; private set; }
        public AccountService AccountService { get; set; }
    }
}