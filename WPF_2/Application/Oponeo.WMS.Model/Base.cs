using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Oponeo.WMS.Model
{
    public class Base
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
