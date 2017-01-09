using System.IO;
using System.ComponentModel;
namespace AutoActApp
{
    partial class Service1
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        
        private void InitializeComponent()
        {
        this.FileSystemWatcher = new FileSystemWatcher();
            ((ISupportInitialize)(this.FileSystemWatcher)).BeginInit();
            // 
            // FileSystemWatcher
            // 
            this.FileSystemWatcher.EnableRaisingEvents = true;
            this.FileSystemWatcher.Filter = "*.csv";
            this.FileSystemWatcher.IncludeSubdirectories = true;
            this.FileSystemWatcher.NotifyFilter = ((NotifyFilters)((NotifyFilters.FileName | NotifyFilters.DirectoryName)));
            // 
            // DbAutoActualizationService
            // 
            this.ServiceName = "Service1";
            ((ISupportInitialize)(this.FileSystemWatcher)).EndInit();

        }





     

        #endregion
       
        private FileSystemWatcher FileSystemWatcher;
    }
}
