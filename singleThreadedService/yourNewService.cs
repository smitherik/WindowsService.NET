/*------------------------------------------------------------------------------
    Author     Erik Smith
    Created    2019-01-15
    Purpose    This is a skeleton project for a single threaded .NET framework 
               v4.5.2 windows service. Move of the framework is in place less 
               what ever logic/actions your service is going to be performing.
               The following is a list of all areas that need touched when 
               making use of this skeleton project. 

              * Right click on yourNewService.cs in the solution explorer and 
                select rename. 
              * Pick yes to rename all occurances. 
              * In the code below all strings that are captured with < > need
                to be updated by you. 
              * In the design view of the service ensure the 'ServiceName' 
                property is set to the new name of your service. 
              * In the design view for the ProjectInstaller update the 
                following properties to address your new service. 
                  * ServiceName - must match the name of your service cs file.
                  * Desctiption - as displayed in task scheduler.
                  * DisplayName - as displayed in task scheduler.
              * Update all OnSomething methods within the code below per the 
                comments within each method. 
-------------------------------------------------------------------------------
    Modification History
  
    01/15/2020  Erik W. Smith
    [1:eof]
        Initial development of skeleton project. 
-----------------------------------------------------------------------------*/

using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;
using System.Runtime.InteropServices;

namespace printingService
{
    public partial class yourNewService : ServiceBase
    {        
        private readonly string serviceNameWithinLog = "<Your Service Name>"; // name that will be registered within the logs
        private readonly string serviceLogToUse      = "<System>";            // possible values Application, System, or a custom event log
        private readonly int    pollingFrequency     = 60000;               // 60 seconds
        private          int    eventId              = 1;
        
        public enum ServiceState
        {
            SERVICE_STOPPED          = 0x00000001,
            SERVICE_START_PENDING    = 0x00000002,
            SERVICE_STOP_PENDING     = 0x00000003,
            SERVICE_RUNNING          = 0x00000004,
            SERVICE_CONTINUE_PENDINT = 0x00000005,
            SERVICE_PAUSE_PENDING    = 0x00000006,
            SERVICE_PAUSED           = 0x00000007,
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct ServiceStatus
        {
            public int          dwServiceType;
            public ServiceState dwCurrentState;
            public int          dwControlsAccepted;
            public int          dwWin32ExitCode;
            public int          dwServiceSpecificExitCode;
            public int          dwCheckPoint;
            public int          dwWaitHint;
        }
        
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus(System.IntPtr handle, ref ServiceStatus serviceStatus);
        
        public yourNewService()
        {
            InitializeComponent();
            // Register the service with the System event log
            eventLog = new EventLog();
            if (!EventLog.SourceExists(serviceNameWithinLog))
            {
                EventLog.CreateEventSource(
                    serviceNameWithinLog, serviceLogToUse);
            }
            eventLog.Source = serviceNameWithinLog; 
            eventLog.Log    = serviceLogToUse; 
            // Setup the mechnisim to be used for polling
            Timer timer    = new Timer();
            timer.Interval = pollingFrequency; 
            timer.Elapsed  += new ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        protected override void OnStart(string[] args)
        {
            ServiceStatus serviceStatus = new ServiceStatus
            {
                dwCurrentState = ServiceState.SERVICE_START_PENDING,
                dwWaitHint     = 100000
            };
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
            
            //--------------------------------------------------------------
            //
            //
            // Put code here for starting and configuring your service.
            eventLog.WriteEntry("<Update with service starting log entry>");
            //
            //
            //
            //--------------------------------------------------------------

            serviceStatus.dwCurrentState = ServiceState.SERVICE_RUNNING;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
        }

        protected override void OnStop()
        {
            ServiceStatus serviceStatus = new ServiceStatus
            {
                dwCurrentState = ServiceState.SERVICE_STOP_PENDING,
                dwWaitHint     = 100000
            };
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            //--------------------------------------------------------------
            //
            //
            // Put code here for stoping and cleaning up your service.
            eventLog.WriteEntry("<Update with service stoping log entry>");
            //
            //
            //
            //--------------------------------------------------------------

            serviceStatus.dwCurrentState = ServiceState.SERVICE_STOPPED;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
        }

        //--------------------------------------------------------------
        //
        //
        // The following three method overides included for if this service is ever used
        // as a template for creating other services. 
        /*
        protected override void OnContinue()
        {
            eventLog.WriteEntry("Update with service continuing log entry");
        }
        protected override void OnPause()
        {
            eventLog.WriteEntry("Update with service pausing log entry");
        }
        protected override void OnShutdown()
        {
            eventLog.WriteEntry("Update with system shuting down log entry");
        }
        */
        //
        //
        //
        //--------------------------------------------------------------

        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            //--------------------------------------------------------------
            //
            //
            /*
             * This is where you would add the functionality to the
             * new service you are creating. Please keep in mind that 
             * this service template executes all tasks on a single thread.
             */
            eventLog.WriteEntry("<Update with service actions performed log entry>", EventLogEntryType.Information, eventId++);
            //
            //
            //
            //--------------------------------------------------------------
        }
    }
}
