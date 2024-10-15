using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorerLibrary
{
    public class FileExplorer : IExplorer
    {
        private FileInfo _file;
        public FileExplorer(FileInfo file)
        {
            _file = file;
        }
        public string Name
        {
            get
            {
                return _file.Name;
            }
        }

        public DateTime CreationDate
        {
            get
            {
                return _file.CreationTime;
            }
        }

        public DateTime LastModified
        {
            get
            {
                return _file.LastWriteTime;
            }
        }

        public long Size
        {
            get
            {
                return _file.Length;
            }
        }

        public IEnumerable<IExplorer> Children => throw new NotImplementedException();

        public void AddChild(IExplorer explorer)
        {
            throw new NotImplementedException();
        }

        public IExplorer GetChild(string name)
        {
            throw new NotImplementedException();
        }

        public void RemoveChild(IExplorer explorer)
        {
            throw new NotImplementedException();
        }
    }
}