using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TonNurako;
using TonNurako.Widgets;
using TonNurako.X11;
using TonNurako.Xt;

namespace Frogram {


    class Program : TonNurako.Widgets.Shell.TopLevel {

        public override void ShellCreated() {
        }

        static void Main(string[] args) {
            //System.Diagnostics.Debug.Listeners.Add(new System.Diagnostics.TextWriterTraceListener(Console.Out));

            var app = new TonNurako.ApplicationContext();
            TonNurako.Application.Run(app, new Program(), args);
        }
    }
}
