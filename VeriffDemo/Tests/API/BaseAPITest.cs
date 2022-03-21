using System;
using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using VeriffDemo.API;
using VeriffDemo.Tests.Utilities;

namespace VeriffDemo.Tests.API
{
    public class BaseAPITest : ExtentReportsHelpers
    {
        protected Client veriffSessionClient;

        public BaseAPITest()
        {
            veriffSessionClient = new Client();
        }

        [SetUp]
        public void SetUp()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void CleanUp()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome;
            var message = TestContext.CurrentContext.Result.Message;
            RecordTestOutcomeToExtent(test, outcome, message);

            extent.Flush();
        }

        public override void RecordTestOutcomeToExtent(ExtentTest test, ResultState outcome, string message)
        {
            if (outcome == ResultState.Success)
            {
                test.Pass("Test passed");
            }
            else if (outcome == ResultState.Failure)
            {
                test.Fail(message);
            }
            else if (outcome == ResultState.Error)
            {
                test.Error(message);
            }
            else if (outcome == ResultState.Inconclusive)
            {
                test.Skip(message);
            }
            else
            {
                test.Warning(message);
            }
        }
    }
}
