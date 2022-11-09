using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Assembly_Browser
{
    public class AssemblyBrowser : INotifyPropertyChanged
    {
        private ObservableCollection<IAssemblyUnit> _types;
        public ObservableCollection<IAssemblyUnit> Types
        {
            get => _types;
            set
            {
                _types = value;
                OnPropertyChanged("Types");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}