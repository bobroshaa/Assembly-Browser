using System.Collections.ObjectModel;

namespace Interfaces
{
    public interface IFileService
    {
        ObservableCollection<IAssemblyUnit> Open(string filename);
    }
}