using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Lingual.Proxy;
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
            var proxy = new ProxyBuilder(type.Name + "Proxy");
            var instance = Reflect.Construct(type);
            var result = new TestSuite(type) {Fixture = instance};

            Type deleteMe = null;
            
            foreach (var property in GetTestSourcePropertiesFrom(type))
            {
                var testSource = (ITestSource) property.GetValue(instance, null);
                if (!testSource.TestContext.HasTests)
                    continue;

                var proxyType =
                    proxy.CreateClass(string.Format("{0} {1}", testSource.TestContext.ArrangeDescription,
                                                    testSource.TestContext.ActDescription));

                var tests = new Dictionary<string, Action>();
                foreach (var testInformation in testSource.TestContext.Tests)
                {
                    proxyType.CreateMethodThatExecutionsAnActionDelegate(testInformation.AssertDescription);
                    tests.Add(testInformation.AssertDescription, testInformation.Test);
                }

                var testType = proxyType.CompleteType();
                var testInstance = Reflect.Construct(testType);
                var localFixture = new TestSuite(testType) { Fixture = testInstance };
                foreach (var methodAndFieldPair in proxyType.MethodAndFieldPairs)
                {
                    methodAndFieldPair.Field.SetValue(testInstance, tests[methodAndFieldPair.Method.Name]);
                    localFixture.Add(new NUnitTestMethod(methodAndFieldPair.Method));
                }
                deleteMe = testType;
                result.Add(localFixture);
            }
            proxy.SaveAssembly();
            return result;
        }

        private IEnumerable<PropertyInfo> GetTestSourcePropertiesFrom(Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(IsTestSource);
        }

        private bool IsTestSource(PropertyInfo property)
        {
            return property.PropertyType.IsAssignableFrom(typeof (ITestSource));
        }
    }
}
