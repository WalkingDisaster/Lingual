using System;

namespace Lingual.Fluent.Bdd
{
    public class Assertion<TContext, TResult>
    {
        public string Description { get; set; }
        public Action<TContext, TResult> Assert { get; set; }
    }
}