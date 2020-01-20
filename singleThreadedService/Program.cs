/*------------------------------------------------------------------------------
    Author     Erik Smith
    Created    2019-01-15
    Purpose    This is a skeleton project for a single threaded .NET framework 
               v4.5.2 windows service. 
               
               See yourNewService.cs
-------------------------------------------------------------------------------
    Modification History
  
    01/15/2020  Erik W. Smith
    [1:eof]
        Initial development of skeleton project. 
-----------------------------------------------------------------------------*/

using System.ServiceProcess;

namespace printingService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new yourNewService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
