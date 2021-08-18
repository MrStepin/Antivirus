using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antivirus
{
    public class ScanFolder
    {
        public delegate void FileHandler();
        public delegate void FileWithFileNameHandler(string fileName);
        public event FileHandler Notify;
        public event FileWithFileNameHandler NotifyWithFileName;

        public string[] GetFiles (string directoryPath)
        {
            return Directory.GetFiles(directoryPath);
        }

        public void findFile(string[] files, string filePathAndName)
        {
            foreach (string fileFromArray in files)
                if (filePathAndName == fileFromArray)
                {
                    Notify?.Invoke();
                    NotifyWithFileName?.Invoke(filePathAndName);
                }
        }
    }
}
