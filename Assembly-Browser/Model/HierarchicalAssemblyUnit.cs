using System.Collections.ObjectModel;
using Interfaces;

namespace Model
{
    public class HierarchicalAssemblyUnit : IAssemblyUnit
    {
        public string Name { get; set; }

        public ObservableCollection<IAssemblyUnit> Children { get; set; } = new ObservableCollection<IAssemblyUnit>();
    }
}