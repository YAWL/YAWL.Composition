// Copyright (c) Massive Pixel.  All Rights Reserved.  Licensed under the MIT License (MIT). See License.txt in the project root for license information.

using Xunit;
using StringProperty = YAWL.Composition.ObservableProperty<string>;

namespace YAWL.Composition.Tests
{
    public class ObservableStringPropertyTest
    {
        [Fact]
        public void TestNewString()
        {
            Assert.Equal<string>(null, new StringProperty());
        }

        [Fact]
        public void TestNonNullParameter()
        {
            Assert.Equal(string.Empty, new StringProperty(string.Empty));
        }

        [Fact]
        public void TestNonTrivialParameter()
        {
            const string test = "some random string";
            Assert.Equal(test, new StringProperty(test));
        }
    }
}
