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
        public static System.Timers.Timer ti_intejesrv = new System.Timers.Timer(); //Intervalo de ejecución del servicio.
        public static int i = 0;
        public static BaseDatos BD = new BaseDatos("BASPRVNAM", "BASCADCON"); //Conexión a la base de datos

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ti_intejesrv.Interval = 5000;
            ti_intejesrv.Elapsed += new System.Timers.ElapsedEventHandler(ti_intejesrv_Elapsed);
            ti_intejesrv.Enabled = true;
            ti_intejesrv.Start();
        }

        void ti_intejesrv_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ti_intejesrv.Enabled = false;
        }

        private void ExecuteProcess()
        {
            i++;
            EventLog.WriteEntry("Inicio del proceso de Facturación N° " + i.ToString() + " - FECHA INICIO: " + DateTime.Now.ToString());
            ti_intejesrv.Enabled = true;
        }

        protected override void OnStop()
        {
            EventLog.WriteEntry("Finalizo el servicio de Facturación");
        }
    }
}
