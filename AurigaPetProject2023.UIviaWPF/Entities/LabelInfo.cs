using System.Windows;
using System.Windows.Media;

namespace AurigaPetProject2023.UIviaWPF.Entities
{
    public class LabelInfo: BaseModel
    {
        public Visibility Visibility
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
                OnPropertyChanged(nameof(Visibility));
            }
        }
        private Visibility _visibility;

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }
        private string _text;

        public Brush Color
        {
            get { return _color; }
            set
            {
                _color = value;
                OnPropertyChanged(nameof(Color));
            }
        }
        private Brush _color;
    }
}
