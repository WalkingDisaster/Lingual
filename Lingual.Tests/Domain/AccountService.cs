using System;

namespace Lingual.Tests.Domain
{
    public class AccountService
    {
        private readonly IRepository<Account> _repository;
        private readonly IWatchListService _watchListService;

        public AccountService(IRepository<Account> repository, IWatchListService watchListService)
        {
            _repository = repository;
            _watchListService = watchListService;
        }

        public Account GetAccount(long accountId)
        {
            var account = _repository.Get(accountId);
            if (account == null)
                return null;
            if (_watchListService.IsOnWatchList(account.Id))
            {
                account.Status = AccountStatuses.Frozen;
                account.LastActivityDate = DateTime.Today;
                account.TotalBalance = 0;
            }
            return account;
        }
    }
}