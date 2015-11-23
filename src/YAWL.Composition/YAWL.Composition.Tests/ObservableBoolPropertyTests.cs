// Copyright (c) Massive Pixel.  All Rights Reserved.  Licensed under the MIT License (MIT). See License.txt in the project root for license information.

using Xunit;

namespace YAWL.Composition.Tests
{
    public class ObservableBoolPropertyPropertyTests
    {
        [Fact]
        public void TestDefaultConstructorSetsToFalse()
        {
            var prop = new ObservableBoolProperty();

            Assert.Equal(prop, false);
        }

        [Fact]
        public void TestConstructorParameter()
        {
            var prop = new ObservableBoolProperty(true);

            Assert.Equal(prop, true);
        }

        [Fact]
        public void TestChangeAfterConstruction()
        {
            var prop = new ObservableBoolProperty();
            prop.Value = true;

            Assert.Equal(prop, true);
        }
    }
}
