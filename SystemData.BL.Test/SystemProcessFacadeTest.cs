using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using SystemData.BL.Api;

namespace SystemData.BL.Test
{
    [TestClass]
    public class SystemProcessFacadeTest
    {
        private ISystemProcessFacade _systemFacade;

        [TestInitialize]
        public void Init(){
            _systemFacade = new SystemProcessFacade();
        }

        [TestMethod]
        public void StopProcessWrongProcessNumberShouldThrow()
        {
            var exceptionThrown = false;
            try
            {
                _systemFacade.StopProcess(-1);
            }
            catch(Exception ex)
            {
                Assert.IsNotNull(ex);
                Assert.IsTrue(ex is ArgumentException);
                exceptionThrown = true;
            }
            Assert.IsTrue(exceptionThrown);
        }

        [TestMethod]
        public void ShowProcessShouldReturn()
        {
            var processes = _systemFacade.GetAllRunningProcessNames();
            Assert.IsNotNull(processes);
            Assert.IsTrue(processes.Count() > 0);
        }
    }
}
