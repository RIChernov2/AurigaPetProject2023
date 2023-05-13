using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AurigaPetProject2023.UIviaWPF.Entities
{
    public class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // метод для пеерподписи свойств viewmodel на model
        protected virtual void OnMyModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.PropertyName)) OnPropertyChanged(e.PropertyName);
        }
    }
}
