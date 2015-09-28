// Copyright (c) Massive Pixel.  All Rights Reserved.  Licensed under the MIT License (MIT). See License.txt in the project root for license information.

using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace YAWL.Composition.Tests
{
    [TestClass]
    public class ObservableBoolPropertiesOperations
    {
        [TestMethod]
        public void TestOrBetweenDefaultValuesIsFalse()
        {
            var prop1 = new ObservableBoolProperty();
            var prop2 = new ObservableBoolProperty();
            var prop3 = prop1 || prop2;

            Assert.AreEqual(prop3, false);
        }

        [TestMethod]
        public void TestOrBetweenTrueAndFalseIsTrue()
        {
            var prop1 = new ObservableBoolProperty(true);
            var prop2 = new ObservableBoolProperty();
            var prop3 = prop1 || prop2;

            Assert.AreEqual(prop3, true);
        }

        [TestMethod]
        public void TestOrBetweenFalseAndTrueIsTrue()
        {
            var prop1 = new ObservableBoolProperty();
            var prop2 = new ObservableBoolProperty(true);
            var prop3 = prop1 || prop2;

            Assert.AreEqual(prop3, true);
        }


        [TestMethod]
        public void TestOrBetweenTrueAndTrueIsTrue()
        {
            var prop1 = new ObservableBoolProperty(true);
            var prop2 = new ObservableBoolProperty(true);
            var prop3 = prop1 || prop2;

            Assert.AreEqual(prop3, true);
        }

        [TestMethod]
        public void TestOrAfterChangingFirstToTrue()
        {
            var prop1 = new ObservableBoolProperty();
            var prop2 = new ObservableBoolProperty();
            var prop3 = prop1 || prop2;

            prop1.Value = true;

            Assert.AreEqual(prop3, true);
        }

        [TestMethod]
        public void TestOrAfterChangingSecondToTrue()
        {
            var prop1 = new ObservableBoolProperty();
            var prop2 = new ObservableBoolProperty();
            var prop3 = prop1 || prop2;

            prop2.Value = true;

            Assert.AreEqual(prop3, true);
        }
    }
}
