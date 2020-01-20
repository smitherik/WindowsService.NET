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
using System.ComponentModel;

namespace printingService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}
