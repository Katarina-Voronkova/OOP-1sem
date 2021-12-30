using System;
using System.IO;

namespace lab13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            BASDiskInfo.DiskInfo(drives);

            string path = @"D:\2 курс\ООП\13_Потоки_файловая система.pdf";
            FileInfo file = new FileInfo(path); 
            BASFileInfo.FileInfo(file);

            string dirPath = file.DirectoryName;    
            DirectoryInfo dir = new DirectoryInfo(dirPath);

            BASFileManager drive = new BASFileManager(@"D:\MyPy");
            drive.FileManager(@"D:\MyPy");
            BASFileManager.CreateDirInspect();
            BASFileManager.CreateDirFiles();
            BASFileManager.NewFileDirInfo();
            BASFileManager.DiskInfo();
 


        }
    }
}
//1073741824