using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.IO;

namespace FE.InterfaceService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
        }

        void ti_intejesrv_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
        }

        protected override void OnStop()
        {
        }
    }
}
