using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Assembly_Browser
{
    public class AssemblyBrowser : INotifyPropertyChanged
    {
        private string _path;

        public string Path
        {
            get { return _path;}
            set
            {
                _path = value;
                OnPropertyChanged("Path");
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