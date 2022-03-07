using Microsoft.VisualStudio.TestTools.UnitTesting;
using Showrunner;
using System;

namespace Showrunner_Tests
{
    [TestClass]
    public class UpdaterTests
    {
        [TestMethod]
        public void getVersionName_returnAString()
        {
            Assert.IsInstanceOfType(Updater.getVersionName(), typeof(string));
        }

        [TestMethod]
        public void getVersionID_returnAnInteger()
        {
            Assert.IsInstanceOfType(Updater.getVersionID(), typeof(int));
        }

        [TestMethod]
        public void checkForUpdate_doesntCauseError()
        {
            try
            {
                Updater.checkForUpdate();
            } catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
