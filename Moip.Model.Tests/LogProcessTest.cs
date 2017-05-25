using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moip.Model.Tests
{
    [TestClass]
    public class LogProcessTest
    {
        private LogProcess logProcess { get; set; }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void LogProcess_Intanciando_Com_Nulo()
        {
            logProcess = new LogProcess(null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void LogProcess_Intanciando_Com_Vazio()
        {
            logProcess = new LogProcess("");
        }
        
    }
}
