using System.Collections.ObjectModel;

namespace Assembly_Browser
{
    public class HierarchicalAssemblyUnit : IAssemblyUnit
    {
        public string Name { get; set; }

        public ObservableCollection<IAssemblyUnit> Children { get; set; } = new ObservableCollection<IAssemblyUnit>();
    }
}