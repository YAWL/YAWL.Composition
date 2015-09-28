﻿using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using StringProperty = YAWL.Composition.ObservableProperty<string>;

namespace YAWL.Composition.Tests
{
    [TestClass]
    public class ObservableStringPropertyTest
    {
        [TestMethod]
        public void TestNewString()
        {
            Assert.AreEqual(null, new StringProperty());
        }

        [TestMethod]
        public void TestNonNullParameter()
        {
            Assert.AreEqual(string.Empty, new StringProperty(string.Empty));
        }

        [TestMethod]
        public void TestNonTrivialParameter()
        {
            const string test = "some random string";
            Assert.AreEqual(test, new StringProperty(test));
        }
    }
}
