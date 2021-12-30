using System;
using System.IO;
using System.Reflection;

namespace lab13
{
    static class BASDiskInfo
    {
        public static void DiskInfo(DriveInfo[] drives)
        {
            BASLog.Actwrite("DiskInfo");
            string output = "";
            foreach (DriveInfo drive in drives)
            {   
                output+= $"\nНазвание: {drive.Name}\n";
                output+=$"Тип: {drive.DriveType}\n";
                output+=$"Имя файловой системы: {drive.DriveFormat}\n";
                if (drive.IsReady)
                {
                    output+=$"Объем диска: {drive.TotalSize / 1073741824} ГБ\n";
                    output+=$"Свободное пространство: {drive.TotalFreeSpace / 1073741824} ГБ\n";
                    output+=$"Метка: {drive.VolumeLabel}\n";
                }
                Console.WriteLine(output);
            }
            BASLog.Writer(output);
        }
    }

    static class BASFileInfo
    {
        public static void FileInfo(FileInfo file) 
        {
            BASLog.Actwrite("FileInfo");
            string output = "";
            if (file.Exists)
            {
                output += $"\nФайл: '{file.Name}',\nрасшиерние: {file.Extension}, \nразмер: {file.Length}\n";
                output += $"Полный путь: {file.DirectoryName}\n";
                output += $"Дата создания:{file.CreationTime}\n";
                output += $"Дата последнего изменения { file.LastWriteTime }\n";
            }
            Console.WriteLine(output);
            BASLog.Writer(output);
        }
    }

    static class BASDirInfo 
    {
        public static void DirInfo(DirectoryInfo dir)
        {
            BASLog.Actwrite("DirInfo");
            string output = "";
            if (dir.Exists)
            {
                
                output+=$"\nПапка: {dir.Name}\n";
                output+=$"Кол-во файлов: {dir.GetFiles().Length}\n";
                output+=$"Дата создания: {dir.CreationTime}\n";
                output+=$"Кол-во поддиректорий: {dir.GetDirectories().Length}\n";
                output+=$"Список родительских директорий: {dir.Parent}\n";
            }
            Console.WriteLine(output);
        }
    }
}
