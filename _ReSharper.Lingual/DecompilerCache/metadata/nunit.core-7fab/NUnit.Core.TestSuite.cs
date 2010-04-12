// Type: NUnit.Core.TestSuite
// Assembly: nunit.core, Version=2.5.4.10098, Culture=neutral, PublicKeyToken=96d09a1eb7f44a77
// Assembly location: D:\Projects\Lingual\lib\NUnit\nunit.core.dll

using System;
using System.Collections;
using System.Reflection;

namespace NUnit.Core
{
    [Serializable]
    public class TestSuite : Test
    {
        protected MethodInfo[] fixtureSetUpMethods;
        protected MethodInfo[] fixtureTearDownMethods;
        protected bool maintainTestOrder;
        protected MethodInfo[] setUpMethods;
        protected MethodInfo[] tearDownMethods;
        public TestSuite(string name);
        public TestSuite(string parentSuiteName, string name);
        public TestSuite(Type fixtureType);
        public TestSuite(Type fixtureType, object[] arguments);
        public override IList Tests { get; }
        public override bool IsSuite { get; }
        public override int TestCount { get; }
        public override Type FixtureType { get; }
        public override object Fixture { get; set; }
        public override string TestType { get; }
        public void Sort();
        public void Sort(IComparer comparer);
        public void Add(Test test);
        public void Add(object fixture);
        public MethodInfo[] GetSetUpMethods();
        public MethodInfo[] GetTearDownMethods();
        public override int CountTestCases(ITestFilter filter);
        public override TestResult Run(EventListener listener, ITestFilter filter);
        public void Run(TestResult suiteResult, EventListener listener, ITestFilter filter);
        protected virtual void DoOneTimeSetUp(TestResult suiteResult);
        protected virtual void CreateUserFixture();
        protected virtual void DoOneTimeTearDown(TestResult suiteResult);
        protected virtual bool IsAssertException(Exception ex);
        protected virtual bool IsIgnoreException(Exception ex);
    }
}
