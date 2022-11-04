using System.Collections.Generic;

namespace Assembly_Browser
{
    public interface IFileService
    {
        List<Node> Open(string filename);
    }
}