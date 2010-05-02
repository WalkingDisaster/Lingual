namespace Lingual.Fluent.Bdd
{
    public interface ISpecificationContext
    {
        
    }

    public interface ISpecificationContext<TResult> : ISpecificationContext, ITestContext<TResult>
    {
        
    }
}