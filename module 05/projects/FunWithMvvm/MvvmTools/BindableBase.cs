using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmTools
{
    public class BindableBase : INotifyPropertyChanged
    {
        private Dictionary<string, object> _propertyValues = new();
        public event PropertyChangedEventHandler? PropertyChanged;

        public T? Get<T>(T? defultValue = default, [CallerMemberName] string propertyName="")
        {
            lock(_propertyValues)
            {
                if (_propertyValues.ContainsKey(propertyName))
                {
                    return (T)_propertyValues[propertyName];
                }

                return defultValue;
            }
        }

        public bool Set<T>(T value, [CallerMemberName] string propertyName = "")
        {
            lock(_propertyValues)
            {
                var storage = Get<T>(propertyName: propertyName);

                if (!Equals(storage, value))
                {
                    _propertyValues[propertyName] = value!;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                    return true;
                }

                return false;
            }
        }
    }
}