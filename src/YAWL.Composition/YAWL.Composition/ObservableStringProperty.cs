// Copyright (c) Massive Pixel.  All Rights Reserved.  Licensed under the MIT License (MIT). See License.txt in the project root for license information.

namespace YAWL.Composition
{
    public static class ObservableStringPropertyExtensions
    {
        public static ObservableBoolProperty IsNullOrEmpty(this ObservableProperty<string> prop)
        {
            var result = new ObservableBoolProperty(string.IsNullOrEmpty(prop.Value));

            prop.PropertyChanged += (_, __) =>
            {
                result.Value = string.IsNullOrEmpty(prop.Value);
            };

            return result;
        }
    }
}
