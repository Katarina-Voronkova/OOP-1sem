using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
     class BASFileManager
    {
        private DirectoryInfo dir;
        private List <DirectoryInfo> list;
        public BASFileManager(string path) 
        {
            dir = new DirectoryInfo(path);
        }
        public void FileManager(string path) 
        {
            BASLog.Actwrite("FileManager");
            List<string> list = new List<string>();
            try
            {
                var folders = Directory.GetDirectories(path);
                foreach (var folder in folders)
                {
                    list.Add($"Папка: {folder}");
                    list.AddRange(GetRecurcFiles(folder));
                }
                var files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    list.Add($"Файл: {file}");
                }
                foreach (var item in list) 
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }


        #region qwe
        public static void CreateDirInspect()
        {
            BASLog.Actwrite("CreateDirInspect");
            string str = @"D:\l13";
            DirectoryInfo newdir = new DirectoryInfo(str);
            if (!newdir.Exists)
            {
                newdir.Create();
            }
            string pathA = "BASInspect";
            newdir.CreateSubdirectory(pathA);
        }

        public static void CreateDirFiles()
        {
            BASLog.Actwrite("CreateDirFiles");
            string path = @"D:\l13\BASInspect";
            var newdir = new DirectoryInfo(path);
            if (!newdir.Exists)
            {
                newdir.Create();
            }
            string pathA = @"BASFile";
            newdir.CreateSubdirectory(pathA);
        }

        private static List<string> GetRecurcFiles(string path)
        {
            List<string> list = new List<string>();
            try
            {
                var folders = Directory.GetDirectories(path);
                foreach (var folder in folders)
                {
                    list.Add($"Папка: {folder}");
                    list.AddRange(GetRecurcFiles(folder));
                }
                var files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    list.Add($"Файл: {file}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }

        public static void DiskInfo()
        {
            BASLog.Actwrite("DiskInfo");
            string pathDisk = @"D:\MyPy";
            List<string> list = GetRecurcFiles(pathDisk);

            string path = @"D:\l13\BASInspect\BASFile\NEWdirinfo.txt";
            Task.Run(async () => {
                using (var file = File.Open(path, FileMode.OpenOrCreate))
                {
                    var output = new StreamWriter(file);
                    foreach (var item in list)
                    {
                        await file.WriteAsync(Encoding.Default.GetBytes($"{item} \n"));
                    }
                    output.Close();
                }
            });
        }

        public static void NewFileDirInfo()
        {
            BASLog.Actwrite("NewFileDirInfo");
            string path = @"D:\l13\BASInspect\BASFile\dirinfo.txt";
            string newpath = @"D:\l13\BASInspect\BASFile\NEWdirinfo.txt";
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.CopyTo(newpath, true);
                Console.WriteLine("Старый файл будет удален!");
                Console.ReadKey();
                file.Delete();
            }
        }

        public static void CopyFiles()
        {
            BASLog.Actwrite("CopyFiles");
            string copypath = @"D:\l13\BASInspect\BASFile\";
            string path = @"D:\l13\BASInspect\";
            var folder = new DirectoryInfo(copypath);
            var folderFiles = new DirectoryInfo(path);
            var files = folder.GetFiles("*.txt");
            foreach (var item in files)
            {
                item.CopyTo(path + "\\" + item.Name, true);
            }
        }

        public static void MoveDirFiles()
        {
            BASLog.Actwrite("MoveDirFiles");
            string pathA = @"D:\l13\BASInspect\BASFile\";
            string pathB = @"D:\l13\BASInspect\BASFile\";
            var dirfiles = new DirectoryInfo(pathA);
            try
            {
                var ex = new DirectoryInfo(pathB);
                if (!dirfiles.Exists)
                    throw new Exception("Папка SIDInspect не создана!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                dirfiles.MoveTo(pathB);
            }
        }

        public static void CompressFiles()
        {
            BASLog.Actwrite("CompressFiles");
            string path = @"C:\Users\mi\Desktop\1\C#\12\SIDInspect\SIDFiles";
            string zippath = @"C:\Users\mi\Desktop\1\C#\12\SIDInspect\SIDFiles\SIDZip.zip";
            var folder = new DirectoryInfo(path);
            var files = folder.GetFiles();
            using (var zipfolder = ZipFile.Open(zippath, ZipArchiveMode.Create))
            {
                //var zipfolder = new DirectoryInfo(zippath);
                //zipfolder.Create();
                foreach (var file in files)
                {
                    //file.CopyTo(zippath, true);
                    zipfolder.CreateEntryFromFile(file.FullName, file.Name);
                    file.Delete();
                }
                zipfolder.Dispose();
            }

        }

        public static void DecompessFiles()
        {
            BASLog.Actwrite("DecompressFiles");
            string zippath = @"C:\Users\mi\Desktop\1\C#\12\SIDInspect\SIDFiles\SIDZip.zip";
            string path = @"C:\Users\mi\Desktop\1\C#\12";
            ZipFile.ExtractToDirectory(zippath, path);
        }
        #endregion
    }
}
