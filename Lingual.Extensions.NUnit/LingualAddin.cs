using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Core;
using NUnit.Core.Extensibility;

namespace Lingual.Extensions.NUnit
{
    [NUnitAddin(Name = "Lingual", Description = "Test builder for flient interfaces.")]
    public class LingualAddin : IAddin, ISuiteBuilder
    {
        public bool Install(IExtensionHost host)
        {
            var suiteBuilders = host.GetExtensionPoint("SuiteBuilders");
            suiteBuilders.Install(this);
            return true;
        }

        public bool CanBuildFrom(Type type)
        {
            return GetTestSourcePropertiesFrom(type).Any();
        }

        public Test BuildFrom(Type type)
        {
            var instance = Reflect.Construct(type);
            var result = new TestSuite(type) {Fixture = instance};
            
            foreach (var property in GetTestSourcePropertiesFrom(type))
            {
                var testSource = (ITestSource) property.GetValue(instance, null);
                if (!testSource.TestContext.HasTests)
                    continue;

                var suite = new TestSuite(string.Format("{0} {1}", testSource.TestContext.ArrangeDescription,
                                                        testSource.TestContext.ActDescription));
                foreach (var testInformation in testSource.TestContext.Tests)
                {
                    suite.Add(new LingualTest(testInformation));
                }
                result.Add(suite);
            }
            return result;
        }

        private static IEnumerable<PropertyInfo> GetTestSourcePropertiesFrom(IReflect type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(IsTestSource);
        }

        private static bool IsTestSource(PropertyInfo property)
        {
            return typeof (ITestSource).IsAssignableFrom(property.PropertyType);
        }
    }
}
