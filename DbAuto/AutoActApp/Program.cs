using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;
using System.Reflection;
using System.Configuration.Install;

namespace AutoActApp
{
    class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
         static void Main(string[] args)
               {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new Service1() 
            };
            ServiceBase.Run(ServicesToRun);
        }
        
    }
}
