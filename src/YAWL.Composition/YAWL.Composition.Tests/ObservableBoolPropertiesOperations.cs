// Copyright (c) Massive Pixel.  All Rights Reserved.  Licensed under the MIT License (MIT). See License.txt in the project root for license information.

using Xunit;

namespace YAWL.Composition.Tests
{
    public class ObservableBoolPropertiesOperations
    {
        [Fact]
        public void TestOrBetweenDefaultValuesIsFalse()
        {
            var prop1 = new ObservableBoolProperty();
            var prop2 = new ObservableBoolProperty();
            var prop3 = prop1 | prop2;

            Assert.Equal(prop3, false);
        }

        [Fact]
        public void TestOrBetweenTrueAndFalseIsTrue()
        {
            var prop1 = new ObservableBoolProperty(true);
            var prop2 = new ObservableBoolProperty();
            var prop3 = prop1 | prop2;

            Assert.Equal(prop3, true);
        }

        [Fact]
        public void TestOrBetweenFalseAndTrueIsTrue()
        {
            var prop1 = new ObservableBoolProperty();
            var prop2 = new ObservableBoolProperty(true);
            var prop3 = prop1 | prop2;

            Assert.Equal(prop3, true);
        }


        [Fact]
        public void TestOrBetweenTrueAndTrueIsTrue()
        {
            var prop1 = new ObservableBoolProperty(true);
            var prop2 = new ObservableBoolProperty(true);
            var prop3 = prop1 | prop2;

            Assert.Equal(prop3, true);
        }

        [Fact]
        public void TestOrAfterChangingFirstToTrue()
        {
            var prop1 = new ObservableBoolProperty();
            var prop2 = new ObservableBoolProperty();
            var prop3 = prop1 | prop2;

            prop1.Value = true;

            Assert.Equal(prop3, true);
        }

        [Fact]
        public void TestOrAfterChangingSecondToTrue()
        {
            var prop1 = new ObservableBoolProperty();
            var prop2 = new ObservableBoolProperty();
            var prop3 = prop1 | prop2;

            prop2.Value = true;

            Assert.Equal(prop3, true);
        }
    }
}
