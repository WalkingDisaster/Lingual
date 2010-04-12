using System;
using System.Runtime.Remoting.Contexts;

namespace Lingual.Fluent.Bdd
{
    public static class Given
    {
        public static ISpecificationPrerequisiteBuilder<T> a<T>()
            where T : new()
        {
            return CreateBuilder("Given a", () => new T());
        }

        public static ISpecificationPrerequisiteBuilder<T> a<T>(Func<T> getContext)
        {
            return CreateBuilder("Given a", getContext);
        }

        public static ISpecificationPrerequisiteBuilder<T> an<T>()
            where T : new()
        {
            return CreateBuilder("Given an", () => new T());
        }

        public static ISpecificationPrerequisiteBuilder<T> an<T>(Func<T> getContext)
        {
            return CreateBuilder("Given an", getContext);
        }

        public static ISpecificationPrerequisiteBuilder<T> CreateBuilder<T>(string text, Func<T> context)
        {
            return new SpecificationPrerequisteBuilder<T>(text, context);
        }
    }
}