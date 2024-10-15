using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorerLibrary
{
    //TODO create fileBuilder later ...
    public class FolderExplorer : IExplorer
    {
        private DirectoryInfo _folder;
        private List<IExplorer> _children;
        public FolderExplorer(DirectoryInfo folder)
        {
            _folder = folder;
        }
        public string Name
        {
            get
            {
                return _folder.Name;
            }
        }

        public DateTime CreationDate
        {
            get
            {
                return _folder.CreationTime;
            }
        }

        public DateTime LastModified
        {
            get
            {
                return _folder.LastWriteTime;
            }
        }

        public long Size
        {
            get
            {
                long size = 0;
                foreach (var item in Children)
                {
                    size += item.Size;
                }

                return size;
            }
        }

        public IEnumerable<IExplorer> Children
        {
            get
            {
                foreach (DirectoryInfo item in _folder.GetDirectories())
                {
                    yield return new FolderExplorer(item);
                }

                foreach (FileInfo item in _folder.GetFiles())
                {
                    yield return new FileExplorer(item);
                }
            }
        }

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