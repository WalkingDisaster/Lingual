using System;

namespace Lingual.Fluent.Bdd
{
    public interface ISpeceficationPrimaryAggregator<TContext, TResult>
    {
        ISpecificationAggregator<TContext, TResult> then(params Action<TContext, TResult>[] assertions);
        ISpecificationAggregator<TContext, TResult> should(params Action<TContext, TResult>[] assertions);
    }
}