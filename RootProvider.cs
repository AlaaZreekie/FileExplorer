using FileExplorerAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorerLibraryIO
{
    public class RootProvider : IRootProvider
    {
        public IEnumerable<FileExplorerAbstraction.IExplorer> GetRootExplorerObjects()
        {
            var drivers =  DriveInfo.GetDrives();

            foreach (var driver in drivers)
            {
                yield return 
                    new CompositeExplorer(new FolderExplorer(driver.RootDirectory));
            }
        }
    }
}