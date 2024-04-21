using CodeChallenge.Features;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;

namespace CodeChallenge.Hooks
{
    [TestClass]
    public class Base
    {
        private static CommonVars commonInstance = CommonVars.instance;

        public TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }// gets called after assemblyInitialize
        }

        //######################################################################################################################
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contextInstance"></param>
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext contextInstance)
        {
            DateTime timeNow = DateTime.Now;

        }//AssemblyInitialize

        //######################################################################################################################
        /// <summary>
        /// 
        /// </summary>
        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {

        }//AssemblyCleanup

        //######################################################################################################################
        /// <summary>
        /// 
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            // =========================================================================
            // Initialize CommonVars & BaseInvokeMethodSetup
            // =========================================================================
            CommonVars tmpobj = CommonVars.instance;
            DateTime timeNow = DateTime.Now;

            commonInstance.unqTestNumber = timeNow.ToString("ddMMyy") + timeNow.ToString("hhmmss");

        }//TestInitialize

        //######################################################################################################################
        /// <summary>
        /// 
        /// </summary>
        [TestCleanup]
        public void TestFinalize()
        {
            if (commonInstance.webDriver != null)
            {
                commonInstance.webDriver.Close();
                commonInstance.webDriver.Quit();
            }

        }

    }
}
