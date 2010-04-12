// Type: NUnit.Core.TestFixture
// Assembly: nunit.core, Version=2.5.4.10098, Culture=neutral, PublicKeyToken=96d09a1eb7f44a77
// Assembly location: D:\Projects\Lingual\lib\NUnit\nunit.core.dll

using System;

namespace NUnit.Core
{
    public class TestFixture : TestSuite
    {
        public TestFixture(Type fixtureType);
        public TestFixture(Type fixtureType, object[] arguments);
        public override string TestType { get; }
        public override TestResult Run(EventListener listener, ITestFilter filter);
    }
}
