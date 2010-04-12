using System;
using System.Collections.Generic;

namespace Lingual.Fluent.Bdd
{
    public class SpecificationPrerequisteBuilder<T> : ISpecificationPrerequisiteBuilder<T>
    {
        private readonly FluentExecutionInformation<T> _executionInfo;

        public SpecificationPrerequisteBuilder(string text, Func<T> context)
        {
            _executionInfo = new FluentExecutionInformation<T>
                                 {
                                     Context = context
                                 };
            _executionInfo.ArrangeDescription.AppendFormat("{0} {1}", text, typeof(T).Name);
        }

        public ISpecificationPrerequisiteBuilder<T> that(params Action<T>[] conditions)
        {
            return AddConditions("that", conditions);
        }

        public ISpecificationPrerequisiteBuilder<T> which(params Action<T>[] conditions)
        {
            return AddConditions("which", conditions);
        }

        public ISpecificationPrerequisiteBuilder<T> but(params Action<T>[] conditions)
        {
            return AddConditions("but", conditions);
        }

        public ISpeceficationPrimaryAggregator<TResult> when<TResult>(Func<T, TResult> when)
        {
            return new SpecificationAggregator<T, TResult>(_executionInfo.Expand<TResult>(), when);
        }

        private ISpecificationPrerequisiteBuilder<T> AddConditions(string conjunction, IEnumerable<Action<T>> conditions)
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