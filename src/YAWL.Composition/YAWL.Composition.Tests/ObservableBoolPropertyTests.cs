// Copyright (c) Massive Pixel.  All Rights Reserved.  Licensed under the MIT License (MIT). See License.txt in the project root for license information.

using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace YAWL.Composition.Tests
{
    [TestClass]
    public class ObservableBoolPropertyPropertyTests
    {
        [TestMethod]
        public void TestDefaultConstructorSetsToFalse()
        {
            var prop = new ObservableBoolProperty();

            Assert.AreEqual(prop, false);
        }

        [TestMethod]
        public void TestConstructorParameter()
        {
            var prop = new ObservableBoolProperty(true);

            Assert.AreEqual(prop, true);
        }

        [TestMethod]
        public void TestChangeAfterConstruction()
        {
            var prop = new ObservableBoolProperty();
            prop.Value = true;

            Assert.AreEqual(prop, true);
        }
    }
}
