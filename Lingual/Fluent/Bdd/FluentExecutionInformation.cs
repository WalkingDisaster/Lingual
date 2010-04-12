using System;
using System.Collections.Generic;
using System.Text;

namespace Lingual.Fluent.Bdd
{
    public class FluentExecutionInformation<TContext, TResult> : FluentExecutionInformation<TContext>
    {
        public Func<TContext, TResult> Act { get; set; }
        public string ActDescription { get; set; }
        public List<Assertion<TResult>> Assertions { get; private set; }

        public FluentExecutionInformation()
        {
            Assertions = new List<Assertion<TResult>>();
        }
    }

    public class FluentExecutionInformation<TContext>
    {
        public StringBuilder ArrangeDescription { get; private set; }
        public List<Action<TContext>> Arrange { get; private set; }
        public Func<TContext> Context { get; set; }

        public FluentExecutionInformation()
        {
            ArrangeDescription = new StringBuilder();
            Arrange = new List<Action<TContext>>();
        }

        public FluentExecutionInformation<TContext, TResult> Expand<TResult>()
        {
            return new FluentExecutionInformation<TContext, TResult>
                       {
                           ArrangeDescription = ArrangeDescription,
                           Arrange = Arrange,
                           Context = Context
                       };
        }
    }
}