using System;

namespace FrameworkDesign.Framework.BindableProperty
{
    public class BindableProperty<T> where T : IEquatable<T>
    {
        private T mValue = default(T);

        public T Value
        {
            get => mValue;
            set
            {
                if (value.Equals(mValue)) return;

                mValue = value;
                OnValueChanged?.Invoke(value);
            }
        }

        public Action<T> OnValueChanged;
    }
}
