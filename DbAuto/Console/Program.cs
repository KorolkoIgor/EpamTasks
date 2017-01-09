using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using BL;


namespace ConsoleWatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemWatcher watcher = new FileSystemWatcher(ConfigurationManager.AppSettings["WatchPath"]);
            FSNotifier fsn = new FSNotifier(ConfigurationManager.AppSettings["Delimiter"].ToCharArray());
            watcher.EnableRaisingEvents = true;
            watcher.Filter = "*.csv";
            watcher.IncludeSubdirectories = true;
            watcher.NotifyFilter = ((System.IO.NotifyFilters)((System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.DirectoryName)));
            watcher.Created += fsn.FileSystemWatcher_Created;
             Console.WriteLine(" Watcher joined!");
            Console.ReadLine();

            watcher.Created -= fsn.FileSystemWatcher_Created;
        }
    }

    class FSNotifier
    {
        public BL.DataProcessor dataProcessor;

        public FSNotifier(char[] delimiter)
        {
            dataProcessor = new DataProcessor(delimiter);
        }

        public void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            dataProcessor.StartProcessing(e.FullPath);
        }

    }
}
