// Type: NUnit.Core.NUnitTestFixture
// Assembly: nunit.core, Version=2.5.4.10098, Culture=neutral, PublicKeyToken=96d09a1eb7f44a77
// Assembly location: D:\Projects\Lingual\lib\NUnit\nunit.core.dll

using System;

namespace NUnit.Core
{
    public class NUnitTestFixture : TestFixture
    {
        public NUnitTestFixture(Type fixtureType);
        public NUnitTestFixture(Type fixtureType, object[] arguments);
        protected override void DoOneTimeSetUp(TestResult suiteResult);
        protected override void DoOneTimeTearDown(TestResult suiteResult);
    }
}
