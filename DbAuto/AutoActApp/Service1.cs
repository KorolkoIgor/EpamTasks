using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Configuration;
using System.IO;
using BL;

namespace AutoActApp
{
    partial class Service1 : ServiceBase
    {
        private DataProcessor dataProcessor;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            dataProcessor = new DataProcessor(ConfigurationManager.AppSettings["Delimiter"].ToCharArray());
            FileSystemWatcher.Path = ConfigurationManager.AppSettings["WatchPath"];

            this.FileSystemWatcher.Created += this.FileSystemWatcher_Created;
        }


        protected override void OnStop()
        {
            this.FileSystemWatcher.Created -= this.FileSystemWatcher_Created;
        }
        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            dataProcessor.StartProcessing(e.FullPath);
        }
    }
}
