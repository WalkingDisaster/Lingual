using System;
using System.Collections.Generic;

namespace Lingual.Fluent.Bdd
{
    public class SpecificationPrerequisteBuilder<TContext> : ISpecificationPrerequisiteBuilder<TContext>
    {
        private readonly FluentExecutionInformation<TContext> _executionInfo;

        public SpecificationPrerequisteBuilder(string text, Func<TContext> context)
        {
            _executionInfo = new FluentExecutionInformation<TContext>
                                 {
                                     Context = context
                                 };
            _executionInfo.ArrangeDescription.AppendFormat("{0} {1}", text, typeof(TContext).Name);
        }

        public ISpecificationPrerequisiteBuilder<TContext> that(params Action<TContext>[] conditions)
        {
            return AddConditions("that", conditions);
        }

        public ISpecificationPrerequisiteBuilder<TContext> which(params Action<TContext>[] conditions)
        {
            return AddConditions("which", conditions);
        }

        public ISpecificationPrerequisiteBuilder<TContext> but(params Action<TContext>[] conditions)
        {
            return AddConditions("but", conditions);
        }

        public ISpeceficationPrimaryAggregator<TContext, TResult> when<TResult>(Func<TContext, TResult> when)
        {
            return new SpecificationAggregator<TContext, TResult>(_executionInfo.Expand<TResult>(), when);
        }

        private ISpecificationPrerequisiteBuilder<TContext> AddConditions(string conjunction, IEnumerable<Action<TContext>> conditions)
        {
            foreach (var condition in conditions)
            {
                _executionInfo.ArrangeDescription.AppendFormat(" {0} {1}", conjunction, condition.Method.Name.Replace("_", " "));
                _executionInfo.Arrange.Add(condition);
            }
            return this;
        }
    }
}