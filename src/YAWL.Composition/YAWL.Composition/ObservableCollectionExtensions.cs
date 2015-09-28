// Copyright (c) Massive Pixel.  All Rights Reserved.  Licensed under the MIT License (MIT). See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace YAWL.Composition
{
    public static class ObservableCollectionExtensions
    {
        public static ObservableProperty<TReturn> Reduce<TInput, TReturn>(
            this ObservableCollection<TInput> collection,
            Func<IEnumerable<TInput>, TReturn> reducer)
        {
            if (collection == null)
                return new ObservableProperty<TReturn>();

            var initialValue = reducer == null ? default(TReturn) : reducer(collection);

            var prop = new ObservableProperty<TReturn>(initialValue);

            NotifyCollectionChangedEventHandler handler;
            handler = (sender, args) =>
            {
                prop.Value = reducer != null ? reducer(collection) : default(TReturn);
            };
            collection.CollectionChanged += handler;

            return prop;
        }
    }
}
