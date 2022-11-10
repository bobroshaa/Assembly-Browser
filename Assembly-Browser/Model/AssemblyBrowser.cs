using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Interfaces;
using Microsoft.Win32;

namespace Model
{
    public class AssemblyBrowser : INotifyPropertyChanged
    {
        
        private ObservableCollection<IAssemblyUnit> _namespaces = new ObservableCollection<IAssemblyUnit>();
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
        public ObservableCollection<IAssemblyUnit> Namespaces
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