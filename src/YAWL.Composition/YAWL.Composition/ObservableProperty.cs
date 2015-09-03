using System.Collections.Generic;
using System.ComponentModel;

namespace YAWL.Composition
{
    public class ObservableProperty<T> : INotifyPropertyChanged, INotifyPropertyChanging
    {
        protected static PropertyChangingEventArgs ValueChanging => new PropertyChangingEventArgs(nameof(Value));
        protected static PropertyChangedEventArgs ValueChanged => new PropertyChangedEventArgs(nameof(Value));

        private T value;
        public T Value
        {
            get { return value; }
            set
            {
                if (!EqualityComparer<T>.Default.Equals(value, this.value))
                {
                    OnPropertyChanging(ValueChanging);
                    this.value = value;
                    OnPropertyChanged(ValueChanged);
                }
            }
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs eventArgs)
        {
            PropertyChanged?.Invoke(this, eventArgs);

        }
        #endregion

        #region INotifyPropertyChanging implementation
        public event PropertyChangingEventHandler PropertyChanging;

        protected virtual void OnPropertyChanging(PropertyChangingEventArgs eventArgs)
        {
            PropertyChanging?.Invoke(this, eventArgs);

        }
        #endregion

        public ObservableProperty(T value = default(T))
        {
            this.value = value;
        }

        public static implicit operator T(ObservableProperty<T> property)
        {
            return property.value;
        }
    }
}
