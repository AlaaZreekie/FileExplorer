using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileExplorerAbstraction.Bridge;

namespace FileExplorerLibraryIO
{
    //TODO create fileBuilder later ...
    public class FolderExplorer : IExplorer
    {
        private DirectoryInfo _folder;
        private List<IExplorer> _children = null!;
        private long _size = 0;
        //private bool _isDraft = false;

        public FolderExplorer(DirectoryInfo folder)
        {
            _folder = folder;
        }

        public void Invalidate()
        {
            _children = null!;
            _size = 0;
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
                if (_size == 0)
                {
                    foreach (var item in Children)
                    {
                        _size += item.Size;
                    }
                }

                return _size;
            }
        }

        public IEnumerable<IExplorer> Children
        {
            get
            {
                GetChildren();
                return _children.AsEnumerable();
                /*_children = new List<IExplorer>();
                foreach (DirectoryInfo item in _folder.GetDirectories())
                {
                    _children.Add(new FolderExplorer(item));
                    yield return new FolderExplorer(item);
                }

                foreach (FileInfo item in _folder.GetFiles())
                {
                    _children.Add(new FileExplorer(item));
                    yield return new FileExplorer(item);
                }*/
            }
        }

        public bool IsLeaf { get; set; }

        public void AddChild(IExplorer explorer)
        {
            throw new NotImplementedException();
        }

        public IExplorer GetChild(string name)
        {
            GetChildren();
            return _children.Where(c => c.Name == name).FirstOrDefault()!;

            /*
             * return (from c in _children
                    where c.Name == name
                    orderby c.Name
                    descending                    
                    select c *//*new B(c.id, c.name)*//*).FirstOrDefault();
             */
            /*foreach (IExplorer item in _children)
            {
                if(item.Name == name)
                    return item;
            }

            return null!;*/
        }

        public void RemoveChild(IExplorer explorer)
        {
            throw new NotImplementedException();
        }

        public void Refresh()
        {
            Invalidate();
        }

        private void GetChildren()
        {
            if (_children is not null)
               { return; }
            
            
            _children = new List<IExplorer>();
            foreach (DirectoryInfo item in _folder.GetDirectories())
            {
                _children.Add(new FolderExplorer(item));
              
            }

            foreach (FileInfo item in _folder.GetFiles())
            {
                _children.Add(new FileExplorer(item));
            }
            
        }
    }
}