using System;

namespace Lingual.Fluent.Bdd
{
    public class Assertion<TResult>
    {
        public string Description { get; set; }
        public Action<TResult> Assert { get; set; }
    }
}