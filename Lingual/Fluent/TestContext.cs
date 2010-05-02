namespace Lingual.Fluent
{
    public class TestContext<TResult> : ITestContext<TResult>
    {
        public TResult Result { get; set; }
    }
}