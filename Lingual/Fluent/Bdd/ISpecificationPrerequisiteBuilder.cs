using System;

namespace Lingual.Fluent.Bdd
{
    public interface ISpecificationPrerequisiteBuilder<TContext>
    {
        ISpecificationPrerequisiteBuilder<TContext> that(params Action<TContext>[] conditions);
        ISpecificationPrerequisiteBuilder<TContext> which(params Action<TContext>[] conditions);
        ISpecificationPrerequisiteBuilder<TContext> but(params Action<TContext>[] conditions);
        ISpeceficationPrimaryAggregator<TResult> when<TResult>(Func<TContext, TResult> when);
    }
}