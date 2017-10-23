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
            //var t = Translations.ParseTranslationTable("<Message>WM_PROTOCOLS: quit()");
            //TonNurako.Inutility.Dumper.DumpProperty(t, (s)=> Console.WriteLine($"{s}"));

            //var k = TonNurako.Xt.Core.CoreWidgetClass.GetDefaultSuperClass();
            //TonNurako.Inutility.Dumper.DumpProperty(k, (s) => Console.WriteLine($"{s}"));

            var c = new TonNurako.Xt.Core.CoreWidgetClass();
            c.SuperClass = TonNurako.Xt.Core.CoreWidgetClass.GetDefaultSuperClass();
            c.ClassName = "EyesTnk";
            c.ClassPartInitialize = (w) => Console.WriteLine("ClassPartInitialize");

            c.ClassInitialize = ()=> Console.WriteLine("ClassInitialize");
            c.ClassPartInitialize = (w)=> Console.WriteLine("ClassPartInitialize");
            c.Initialize = (r,n,a) => Console.WriteLine("Initialize");
            c.InitializeHook = (w,a)=> Console.WriteLine("InitializeHook");
            c.Realize = (w, m, a) => Console.WriteLine("Realize");
            c.Destroy = (w) => Console.WriteLine("Destroy");
            c.Resize = (w) => Console.WriteLine("Resize");
            c.Expose = (w,x,r) => Console.WriteLine("Expose");
            c.SetValues = (o, r,x, n) => Console.WriteLine("SetValues");
            c.SetValuesHook = (w,a) => Console.WriteLine("SetValuesHook");
            c.SetValuesAlmost = (w,x,g) => { Console.WriteLine("SetValuesAlmost"); return null; };
            c.GetValuesHook = (w,a) => Console.WriteLine("GetValuesHook");
            c.AcceptFocus = (w, t) => { Console.WriteLine("GetValuesHook"); return false; };
            c.QueryGeometry = (w, r) => { Console.WriteLine("QueryGeometry"); return null; };
            c.DisplayAccelerator = (w,s)  => Console.WriteLine("DisplayAccelerator");

            var wgt = TonNurako.Xt.Widget.CreateManagedWidget("EyesTnk", c, this);
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
