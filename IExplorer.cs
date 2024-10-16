using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorerLibrary
{
    public interface IExplorer
    {
        public string Name { get; }
        public DateTime CreationDate { get; }
        public DateTime LastModified { get; }
        public long Size { get; }
        public IEnumerable<IExplorer> Children { get; }
        public void AddChild(IExplorer explorer);
        public void RemoveChild(IExplorer explorer);
        public IExplorer GetChild(string name);
        public void Refresh();
    }
}