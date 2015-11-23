// Copyright (c) Massive Pixel.  All Rights Reserved.  Licensed under the MIT License (MIT). See License.txt in the project root for license information.

using System.ComponentModel;

namespace YAWL.Composition
{
    public class ObservableBoolProperty : ObservableProperty<bool>
    {
        public ObservableBoolProperty(bool value = false)
            : base(value)
        {
        }

        public static ObservableBoolProperty operator |(ObservableBoolProperty left, ObservableProperty<bool> right)
        {
            var result = new ObservableBoolProperty(left.Value || right.Value);

            PropertyChangedEventHandler handler = (sender, args) => result.Value = left.Value || right.Value;

            left.PropertyChanged += handler;
            right.PropertyChanged += handler;

            return result;
        }

        public static ObservableBoolProperty operator &(ObservableBoolProperty left, ObservableBoolProperty right)
        {
            var result = new ObservableBoolProperty(left.Value && right.Value);

            PropertyChangedEventHandler handler = (sender, args) => result.Value = left.Value && right.Value;

            left.PropertyChanged += handler;
            right.PropertyChanged += handler;

            return result;
        }

        public static ObservableBoolProperty operator !(ObservableBoolProperty prop)
        {
            var result = new ObservableBoolProperty(!prop.Value);

            prop.PropertyChanged += (sender, args) =>
            {
                result.Value = !prop.Value;
            };
            return result;
        }

        public static bool operator true(ObservableBoolProperty property)
        {
            return property.Value;
        }

        public static bool operator false(ObservableBoolProperty property)
        {
            return property.Value == false;
        }
    }
}
