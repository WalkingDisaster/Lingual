using System;
using System.Collections.Generic;
using System.Linq;

namespace Lingual.Fluent.Bdd
{
    public class SpecificationAggregator<TContext, TResult> : ISpecificationAggregator<TContext, TResult>
    {
        private readonly FluentExecutionInformation<TContext, TResult> _executionInfo;

        public SpecificationAggregator(FluentExecutionInformation<TContext, TResult> executionInfo, Func<TContext, TResult> when)
        {
            _executionInfo = executionInfo;
            _executionInfo.Act = when;
            _executionInfo.ActDescription = string.Format("when {0}", when.Method.Name.Replace("_", " "));
        }

        public ISpecificationAggregator<TContext, TResult> then(params Action<TContext, TResult>[] assertions)
        {
            return AddAssertions("then", assertions);
        }

        public ISpecificationAggregator<TContext, TResult> should(params Action<TContext, TResult>[] assertions)
        {
            return AddAssertions("should", assertions);
        }
        
        public TestContext TestContext
        {
            get
            {
                return new TestContext
                           {
                               ArrangeDescription = _executionInfo.ArrangeDescription.ToString(),
                               ActDescription = _executionInfo.ActDescription,
                               Tests = GetTestsFor(_executionInfo.Assertions)
                           };
            }
        }

        private ISpecificationAggregator<TContext, TResult> AddAssertions(string conjunction, IEnumerable<Action<TContext, TResult>> assertions)
        {
            _executionInfo.Assertions.AddRange(assertions.Select(
                a => new Assertion<TContext, TResult>
                         {
                             Description = string.Format("{0} {1}", conjunction, a.Method.Name.Replace("_", " ")),
                             Assert = a
                         }));
            return this;
        }

        private IEnumerable<TestInformation> GetTestsFor(IEnumerable<Assertion<TContext, TResult>> assertions)
        {
            return assertions.Select(CreateTest);
        }

        private TestInformation CreateTest(Assertion<TContext, TResult> assertion)
        {
            return new TestInformation
                       {
                           AssertDescription = assertion.Description,
                           SortableName = assertion.Description,
                           Test = CreateTestFor(assertion.Assert)
                       };
        }

        private Action CreateTestFor(Action<TContext, TResult> assert)
        {
            return () =>
                       {
                           var context = _executionInfo.Context();
                           foreach (var arrange in _executionInfo.Arrange)
                           {
                               arrange(context);
                           }
                           var result = _executionInfo.Act(context);
                           assert(context, result);
                       };
        }
    }
}