using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace VeriffDemo.Tests.Utilities
{
    public abstract class ExtentReportsHelpers
    {
        // Variables & Constants
        public readonly ExtentReports extent = new ExtentReports();
        public ExtentTest test;

        // Actions
        public abstract void RecordTestOutcomeToExtent(ExtentTest test, ResultState outcome, string message);
    }
}
