using System;

namespace Lingual.Fluent.Bdd
{
    public interface ISpeceficationPrimaryAggregator<T>
    {
        ISpecificationAggregator<T> then(params Action<T>[] assertions);
        ISpecificationAggregator<T> should(params Action<T>[] assertions);
    }
}