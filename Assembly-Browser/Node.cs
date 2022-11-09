using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Assembly_Browser
{
    public class Node : INotifyPropertyChanged
    {
        public string Name { get; set; }
        private List<string> _properties;
        private List<string> _fields;
        private List<string> _methods;

        public List<string> Properties
        {
            get => _properties;
            set
            {
                _properties = value;
                OnPropertyChanged("Properties");
            }
        }

        public List<string> Fields
        {
            get => _fields;
            set
            {
                _fields = value;
                OnPropertyChanged("Fields");
            }
        }

        public List<string> Methods
        {
            get => _methods;
            set
            {
                _methods = value;
                OnPropertyChanged("Methods");
            }
        }

        public Node(string name)
        {
            Name = name;
            Properties = new List<string>();
            Fields = new List<string>();
            Methods = new List<string>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}