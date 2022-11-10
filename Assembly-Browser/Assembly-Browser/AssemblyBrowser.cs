using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Assembly_Browser
{
    public class AssemblyBrowser : INotifyPropertyChanged
    {
        private ObservableCollection<HierarchicalAssemblyUnit> _namespaces = new ObservableCollection<HierarchicalAssemblyUnit>();
        //private ObservableCollection<IAssemblyUnit> _types;
        //private ObservableCollection<string> _namespace = new ObservableCollection<string>();

        /*public ObservableCollection<string> Namespace
        {
            get => _namespace;
            set
            {
                _namespace = value;
                OnPropertyChanged("Namespace");
            }
        }*/
        public ObservableCollection<HierarchicalAssemblyUnit> Namespaces
        {
            get => _namespaces;
            set
            {
                _namespaces = value;
                OnPropertyChanged("Namespaces");
            }
        }
        /*public ObservableCollection<IAssemblyUnit> Types
        {
            get => _types;
            set
            {
                _types = value;
                OnPropertyChanged("Types");
            }
        }*/
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}