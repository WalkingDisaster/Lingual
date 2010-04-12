using Lingual.Tests.Domain;

namespace Lingual.Tests.Fluent.Bdd
{
    public class FakeWatchListService : IWatchListService
    {
        public bool Answer { get; set; }
        public bool IsOnWatchList(long accountNumber)
        {
            return Answer;
        }
    }
}