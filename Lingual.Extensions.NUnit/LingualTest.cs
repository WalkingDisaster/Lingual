using System;
using System.Diagnostics;
using System.Threading;
using NUnit.Core;

namespace Lingual.Extensions.NUnit
{
    public class LingualTest : Test
    {
        private static readonly Logger Log = InternalTrace.GetLogger(typeof(LingualTest));
        private readonly Action _test;

        public LingualTest(TestInformation testInformation)
            : base(new TestName {FullName = testInformation.SortableName, Name = testInformation.AssertDescription})
        {
            _test = testInformation.Test;
        }

        public override string TestType
        {
            get { return "Lingual Test"; }
        }

        public override object Fixture { get; set; }

        public override TestResult Run(EventListener listener, ITestFilter filter)
        {
            using (new global::NUnit.Core.TestContext())
            {
                var testResult = new TestResult(this);
                Log.Debug("Test Starting: " + TestName.FullName);
                listener.TestStarted(TestName);
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                switch (RunState)
                {
                    case RunState.Runnable:
                    case RunState.Explicit:
                        DoTest(_test, testResult);
                        break;
                    case RunState.NotRunnable:
                        testResult.Invalid(IgnoreReason);
                        break;
                    case RunState.Ignored:
                        testResult.Ignore(IgnoreReason);
                        break;
                    default:
                        testResult.Skip(IgnoreReason);
                        break;

                }

                stopwatch.Stop();
                testResult.Time = stopwatch.Elapsed.Seconds;

                listener.TestFinished(testResult);
                return testResult;
            }
        }

        private static void DoTest(Action test, TestResult testResult)
        {
            try
            {
                test();
                testResult.Success();
            }
            catch(ThreadAbortException e)
            {
                Thread.ResetAbort();
                HandleException(e, testResult);
            }
            catch (Exception e)
            {
                HandleException(e, testResult);
            }
        }

        private static void HandleException(Exception e, TestResult testResult)
        {
            if (e is NUnitException)
                e = e.InnerException;

            testResult.SetResult(NUnitFramework.GetResultState(e), e);
        }
     }
}