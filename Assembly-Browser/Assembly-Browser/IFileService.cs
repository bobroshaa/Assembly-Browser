using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Assembly_Browser
{
    public interface IFileService
    {
        ObservableCollection<IAssemblyUnit> Open(string filename);
    }
}