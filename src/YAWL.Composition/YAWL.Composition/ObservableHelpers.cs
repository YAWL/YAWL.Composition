// Copyright (c) Massive Pixel.  All Rights Reserved.  Licensed under the MIT License (MIT). See License.txt in the project root for license information.

using System;
using System.ComponentModel;

namespace YAWL.Composition
{
    public static class ObservableHelpers
    {
        public static ObservableProperty<TResult> Map<T, TResult>(this ObservableProperty<T> property,
            Func<T, TResult> map)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));
            if (map == null)
                throw new ArgumentNullException(nameof(map));

            var result = new ObservableProperty<TResult>(map(property.Value));

            property.PropertyChanged += (sender, args) =>
            {
                result.Value = map(property.Value);
            };

            return result;
        }

        public static ObservableProperty<TResult> Combine<T1, T2, TResult>(this ObservableProperty<T1> property1,
            ObservableProperty<T2> property2, Func<T1, T2, TResult> combine)
        {
            var result = new ObservableProperty<TResult>(combine(property1.Value, property2.Value));

            PropertyChangedEventHandler handler = (sender, args) =>
            {
                result.Value = combine(property1.Value, property2.Value);
            };

            property1.PropertyChanged += handler;
            property2.PropertyChanged += handler;

            return result;
        }
    }
}
