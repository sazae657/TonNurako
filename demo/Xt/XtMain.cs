using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TonNurako;
using TonNurako.Xt;

namespace Frogram {
    class Program : TonNurako.Widgets.Shell.TopLevel {

        public override void ShellCreated() {
            base.ShellCreated();
        }


        static void Main(string[] args) {
            System.Diagnostics.Debug.Listeners.Add(new System.Diagnostics.TextWriterTraceListener(Console.Out));

            var app = new TonNurako.ApplicationContext();
            var prog = new Program();
            prog.Name = "name";
            TonNurako.Application.Run(app, prog);
        }
    }
}
