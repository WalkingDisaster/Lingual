namespace Lingual.Fluent
{
    public interface ITestContext<TResult>
    {
        public TResult Result { get; set; }
    }
}