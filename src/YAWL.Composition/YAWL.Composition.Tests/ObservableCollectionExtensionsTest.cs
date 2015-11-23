// Copyright (c) Massive Pixel.  All Rights Reserved.  Licensed under the MIT License (MIT). See License.txt in the project root for license information.

using System.Collections.ObjectModel;
using System.Linq;
using Xunit;

namespace YAWL.Composition.Tests
{
    public class ObservableCollectionExtensionsTest
    {
        [Fact]
        public void TestNullCollectionReturnsDefaultValueForBool()
        {
            ObservableCollection<bool> collection = null;
            Assert.Equal(false, collection.Reduce(list => true));
        }

        [Fact]
        public void TestNullCollectionReturnsDefaultValueForString()
        {
            ObservableCollection<string> collection = null;
            Assert.Equal((string)null, collection.Reduce(list => string.Empty));
        }

        [Fact]
        public void TestCollectionReducerInitialValueForBooleanOr()
        {
            var collection1 = new ObservableCollection<bool> { true, false, true };
            var collection2 = new ObservableCollection<bool> { false, false, false };

            Assert.Equal(true, collection1.Reduce(bools => bools.Aggregate((a, b) => a | b)));
            Assert.Equal(false, collection2.Reduce(bools => bools.Aggregate((a, b) => a | b)));
        }

        [Fact]
        public void TestCollectionReducerInitialValueForBooleanAnd()
        {
            var collection1 = new ObservableCollection<bool> { true, false, true };
            var collection2 = new ObservableCollection<bool> { false, false, false };
            var collection3 = new ObservableCollection<bool> { true, true, true };

            Assert.Equal(false, collection1.Reduce(bools => bools.Aggregate((a, b) => a & b)));
            Assert.Equal(false, collection2.Reduce(bools => bools.Aggregate((a, b) => a & b)));
            Assert.Equal(true, collection3.Reduce(bools => bools.Aggregate((a, b) => a & b)));
        }

        [Fact]
        public void TestCollectionReducerInitialValueForBooleanCounter()
        {
            var collection1 = new ObservableCollection<bool> { false, false, false };
            var collection2 = new ObservableCollection<bool> { false, false, true };
            var collection3 = new ObservableCollection<bool> { true, false, true };
            var collection4 = new ObservableCollection<bool> { true, true, true };

            Assert.Equal(0, collection1.Reduce(bools => bools.Count(x => x)));
            Assert.Equal(1, collection2.Reduce(bools => bools.Count(x => x)));
            Assert.Equal(2, collection3.Reduce(bools => bools.Count(x => x)));
            Assert.Equal(3, collection4.Reduce(bools => bools.Count(x => x)));
        }
    }
}
