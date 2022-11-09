using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Assembly_Browser
{
    public class AssemblyBrowser : INotifyPropertyChanged
    {
        private string _path;
        private List<Node> _types;
        public List<Node> Types
        {
            get { return _types; }
            set
            {
                _types = value;
                OnPropertyChanged("Types");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}