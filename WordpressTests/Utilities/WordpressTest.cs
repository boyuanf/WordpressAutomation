﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;

namespace WordpressTests
{
    [TestClass]
    public class WordpressTest
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
            PostCreator.Initialize();

            LoginPage.GoTo();
            LoginPage.LoginAs("boyuanf").WithPassword("password").Login();
        }

        [TestCleanup]
        public void Cleanup()
        {
            PostCreator.Cleanup();
            Driver.Clean();
        }
    }
}
