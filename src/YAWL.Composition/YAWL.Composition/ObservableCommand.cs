// Copyright (c) Massive Pixel.  All Rights Reserved.  Licensed under the MIT License (MIT). See License.txt in the project root for license information.

using System;
using System.Windows.Input;

namespace YAWL.Composition
{
    public class ObservableCommand : ICommand
    {
        private readonly Action _action;
        private readonly ObservableBoolProperty _canExecuteProperty;

        public ObservableCommand(Action action, ObservableBoolProperty canExecuteProperty)
        {
            _action = action;
            _canExecuteProperty = canExecuteProperty;

            _canExecuteProperty.PropertyChanged += _canExecuteProperty_PropertyChanged;
        }

        private void _canExecuteProperty_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter) => _canExecuteProperty == null || _canExecuteProperty.Value;

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
                _action();
        }

        public event EventHandler CanExecuteChanged;
    }
}
