// Type: NUnit.Core.NUnitFramework
// Assembly: nunit.core, Version=2.5.4.10098, Culture=neutral, PublicKeyToken=96d09a1eb7f44a77
// Assembly location: D:\Projects\Lingual\lib\NUnit\net-2.0\lib\nunit.core.dll

using System;
using System.Reflection;

namespace NUnit.Core
{
    public class NUnitFramework
    {
        public const string IgnoreAttribute = "NUnit.Framework.IgnoreAttribute";
        public const string PlatformAttribute = "NUnit.Framework.PlatformAttribute";
        public const string CultureAttribute = "NUnit.Framework.CultureAttribute";
        public const string ExplicitAttribute = "NUnit.Framework.ExplicitAttribute";
        public const string CategoryAttribute = "NUnit.Framework.CategoryAttribute";
        public const string PropertyAttribute = "NUnit.Framework.PropertyAttribute";
        public const string DescriptionAttribute = "NUnit.Framework.DescriptionAttribute";
        public const string RequiredAddinAttribute = "NUnit.Framework.RequiredAddinAttribute";
        public const string TestFixtureAttribute = "NUnit.Framework.TestFixtureAttribute";
        public const string SetUpFixtureAttribute = "NUnit.Framework.SetUpFixtureAttribute";
        public const string TestAttribute = "NUnit.Framework.TestAttribute";
        public const string TestCaseAttribute = "NUnit.Framework.TestCaseAttribute";
        public const string TestCaseSourceAttribute = "NUnit.Framework.TestCaseSourceAttribute";
        public const string TheoryAttribute = "NUnit.Framework.TheoryAttribute";
        public static readonly string SetUpAttribute;
        public static readonly string TearDownAttribute;
        public static readonly string FixtureSetUpAttribute;
        public static readonly string FixtureTearDownAttribute;
        public static readonly string ExpectedExceptionAttribute;
        public static readonly string SuiteAttribute;
        public static readonly string AssertException;
        public static readonly string IgnoreException;
        public static readonly string InconclusiveException;
        public static readonly string SuccessException;
        public static readonly string AssertType;
        public static readonly string ExpectExceptionInterface;
        public static readonly string SuiteBuilderAttribute;
        public static readonly string SuiteBuilderInterface;
        public static readonly string TestCaseBuilderAttributeName;
        public static readonly string TestCaseBuilderInterfaceName;
        public static readonly string TestDecoratorAttributeName;
        public static readonly string TestDecoratorInterfaceName;
        public NUnitFramework();
        public static bool CheckSetUpTearDownMethods(Type fixtureType, string attributeName, ref string reason);
        public static string GetIgnoreReason(Attribute attribute);
        public static string GetDescription(Attribute attribute);
        public static void ApplyCommonAttributes(MemberInfo member, Test test);
        public static void ApplyCommonAttributes(Assembly assembly, Test test);
        public static void ApplyCommonAttributes(Attribute[] attributes, Test test);
        public static void ApplyExpectedExceptionAttribute(MethodInfo method, TestMethod testMethod);
        public static bool IsSuiteBuilder(Type type);
        public static bool IsTestCaseBuilder(Type type);
        public static bool IsTestDecorator(Type type);
        public static bool IsAddinAvailable(string name);
        public static ResultState GetResultState(Exception ex);

        #region Nested type: Assert

        public class Assert
        {
            public static void AreEqual(object expected, object actual);
            public static int GetAssertCount();
        }

        #endregion
    }
}
