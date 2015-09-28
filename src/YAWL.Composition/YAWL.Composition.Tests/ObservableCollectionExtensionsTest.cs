// Copyright (c) Massive Pixel.  All Rights Reserved.  Licensed under the MIT License (MIT). See License.txt in the project root for license information.

using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace YAWL.Composition.Tests
{
    [TestClass]
    public class ObservableCollectionExtensionsTest
    {
        [TestMethod]
        public void TestNullCollectionReturnsDefaultValueForBool()
        {
            ObservableCollection<bool> collection = null;
            Assert.AreEqual(false, collection.Reduce(list => true));
        }

        [TestMethod]
        public void TestNullCollectionReturnsDefaultValueForString()
        {
            ObservableCollection<string> collection = null;
            Assert.AreEqual((string)null, collection.Reduce(list => string.Empty));
        }

        [TestMethod]
        public void TestCollectionReducerInitialValueForBooleanOr()
        {
            var collection1 = new ObservableCollection<bool> { true, false, true };
            var collection2 = new ObservableCollection<bool> { false, false, false };

            Assert.AreEqual(true, collection1.Reduce(bools => bools.Aggregate((a, b) => a | b)));
            Assert.AreEqual(false, collection2.Reduce(bools => bools.Aggregate((a, b) => a | b)));
        }

        [TestMethod]
        public void TestCollectionReducerInitialValueForBooleanAnd()
        {
            var collection1 = new ObservableCollection<bool> { true, false, true };
            var collection2 = new ObservableCollection<bool> { false, false, false };
            var collection3 = new ObservableCollection<bool> { true, true, true };

            Assert.AreEqual(false, collection1.Reduce(bools => bools.Aggregate((a, b) => a & b)));
            Assert.AreEqual(false, collection2.Reduce(bools => bools.Aggregate((a, b) => a & b)));
            Assert.AreEqual(true, collection3.Reduce(bools => bools.Aggregate((a, b) => a & b)));
        }

        [TestMethod]
        public void TestCollectionReducerInitialValueForBooleanCounter()
        {
            var collection1 = new ObservableCollection<bool> { false, false, false };
            var collection2 = new ObservableCollection<bool> { false, false, true };
            var collection3 = new ObservableCollection<bool> { true, false, true };
            var collection4 = new ObservableCollection<bool> { true, true, true };

            Assert.AreEqual(0, collection1.Reduce(bools => bools.Count(x => x)));
            Assert.AreEqual(1, collection2.Reduce(bools => bools.Count(x => x)));
            Assert.AreEqual(2, collection3.Reduce(bools => bools.Count(x => x)));
            Assert.AreEqual(3, collection4.Reduce(bools => bools.Count(x => x)));
        }
    }
}
