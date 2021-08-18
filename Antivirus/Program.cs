using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antivirus
{
    class Program
    {
        static void Main(string[] args)
        {
            ScanFolder scanFolder = new ScanFolder();

            string pathToFile = "C:\\Users\\Stas\\Desktop\\test";

            string nameOfFile = "C:\\Users\\Stas\\Desktop\\test\\virus.txt";

            scanFolder.NotifyWithFileName += DeleteFile;

            scanFolder.NotifyWithFileName += WriteOnConsole;

            scanFolder.Notify += SendEmail;

            string [] filesFromFolder = scanFolder.GetFiles(pathToFile);

            scanFolder.findFile(filesFromFolder, nameOfFile);

            Console.ReadLine();
        }
        private static void DeleteFile(string nameOfFile)
        {
            File.Delete(nameOfFile);
        }

        private static void WriteOnConsole(string nameOfFile)
        {
            Console.WriteLine($"Found Virus: {nameOfFile}");
        }

        private static void SendEmail()
        {
            Console.WriteLine("Notification sent to email.");
        }
    }
}
