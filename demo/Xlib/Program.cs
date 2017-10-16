using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Xlib {
    class Program {
        static void DumpProperty(object obzekt) {
            var infoArray = obzekt.GetType().GetProperties();
            foreach (var info in infoArray) {
                var sv = "(NULL)";
                var v = info.GetValue(obzekt, null);
                if (null != v) {
                    sv = v.ToString();
                }
                Console.WriteLine($"P: {obzekt.GetType().Name}# {info.Name}={sv}");
            }
        }

        static void DumpStruct(object obzekt) {
            if (null == obzekt) {
                throw new NullReferenceException("obzekt is NULL!!");
            }
            var infoArray = obzekt.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (var m in infoArray) {
                var v = m.GetValue(obzekt);
                var sv = "(NULL)";
                if (null != v) {
                    sv = v.ToString();
                }
                Console.WriteLine($"S: {obzekt.GetType().Name}# {m.Name}={sv}");
            }
        }

        static void Main(string[] args) {
            TonNurako.Application.RegisterGlobals();

            var loc = TonNurako.X11.X11Sports.SetLocale(TonNurako.X11.XLocale.LC_ALL, "");
            if (null == loc) {
                Console.WriteLine("Cannot set the locale.\n");
                return;
            }
            Console.WriteLine($"SetLocale=>{loc}");
            TonNurako.X11.X11Sports.PrintWCS_TNK("PrintWCS_TNK");

            if (!TonNurako.X11.X11Sports.XSupportsLocale()) {
                Console.WriteLine("Current locale is not supported");
                return;
            }

            loc = TonNurako.X11.X11Sports.SetLocaleModifiers("");
            if (null == loc) {
                Console.WriteLine("XSetLocaleModifiers failed");
                return;
            }
            Console.WriteLine($"SetLocale=>{loc}");

            TonNurako.X11.X11Sports.XSetIOErrorHandler((d) => {
                Console.WriteLine("IOE");
                DumpProperty(d);
                return -1;
            });

            var dpy = TonNurako.X11.Display.Open(null);
            if (dpy.Handle == IntPtr.Zero) {
                Console.WriteLine("cannot open display");
                return;
            }
            Console.WriteLine($"*** EventMaskOfScreen={dpy.DefaultScreenOfDisplay.EventMaskOfScreen}");
            DumpProperty(dpy.DefaultScreenOfDisplay);
            DumpProperty(dpy);

            TonNurako.X11.X11Sports.XSetErrorHandler((d, e) => {
                Console.WriteLine("*** E ***");
                DumpProperty(d);
                DumpProperty(e);
                Console.WriteLine("******");
                return -1;
            });

            var fs = TonNurako.X11.FontSet.CreateFontSet(dpy, "-*-fixed-medium-r-normal--14-*-*-*");
            int fi = 0;
            foreach (var fk in TonNurako.X11.FontSet.ListFonts(dpy, "*", 10)) {
                Console.WriteLine($"ListFonts[{fi++}]: {fk}");
            }

            var fe = fs.XExtentsOfFontSet();
            TonNurako.Inutility.DumpProperty(fe.MaxInkExtent, (s) => Console.WriteLine($"MaxInkExtent: {s}"));
            TonNurako.Inutility.DumpProperty(fe.MaxLogicalExtent, (s) => Console.WriteLine($"MaxLogicalExtent: {s}"));

            var rc1 = new TonNurako.X11.TextExtents();
            fs.TextExtents("ゆゆ式", rc1);
            DumpStruct(rc1.OverallLnk);
            DumpStruct(rc1.OverallLogical);

            var rc2 = new TonNurako.X11.TextExtents();
            fs.TextExtentsMultiByte("ゆゆ式", rc2);
            DumpStruct(rc2.OverallLnk);
            DumpStruct(rc2.OverallLogical);

            var rw = dpy.DefaultRootWindow;
            rw.SelectInput(TonNurako.X11.EventMask.SubstructureRedirectMask|TonNurako.X11.EventMask.SubstructureNotifyMask);
            dpy.Sync(false);

            var c = TonNurako.X11.XClassHint.Alloc();
            c.Dispose();

            var vis = dpy.DefaultVisual;
            DumpProperty(vis);

            var atom = TonNurako.X11.Atom.InternAtom(dpy, "WM_DELETE_WINDOW", true);
            Console.WriteLine($"atom={atom.Handle}");

            var win = dpy.CreateSimpleWindow(
                rw, 0, 0, 800, 800, 10,
                TonNurako.X11.Color.AllocNamedColor(dpy, dpy.GetDefaultColormap(), "yellow"),
                TonNurako.X11.Color.AllocNamedColor(dpy, dpy.GetDefaultColormap(), "black"));
            win.SetWMProtocols(new TonNurako.X11.Atom[] { atom });
            win.SelectInput(TonNurako.X11.EventMask.StructureNotifyMask |
                TonNurako.X11.EventMask.ExposureMask|
                TonNurako.X11.EventMask.ButtonPressMask|
                TonNurako.X11.EventMask.KeyPressMask );

            var attr = new TonNurako.X11.XSetWindowAttributes();
            attr.backing_store = TonNurako.X11.BackingStoreHint.WhenMapped;
            win.ChangeWindowAttributes(TonNurako.X11.ChangeWindowAttributes.CWBackingStore, attr);

            win.MapWindow();
            dpy.Flush();

            var green = TonNurako.X11.Color.AllocNamedColor(dpy, dpy.GetDefaultColormap(), "Green");
            TonNurako.X11.GC gc = null;

            var ev = new TonNurako.X11.Event.XEventArg();
            while (true) {
                dpy.NextEvent(ev);
                Console.WriteLine($"NextEvent ev={ev.Type}");
                switch (ev.Type) {
                    case TonNurako.X11.Event.XEventType.Expose:
                        DumpStruct(ev.Expose);
                        if (null == gc) {
                            gc = TonNurako.X11.GC.Create(win);
                            gc.SetForeground(TonNurako.X11.Color.AllocNamedColor(dpy, dpy.GetDefaultColormap(), "Green"));
                        }
                        const int N = 16;
                        var geom = win.GetGeometry();

                        var x = new int[N];
                        var y = new int[N];
                        for (int i = 0; i < N; i++) {
                            x[i] = (int)(geom.Width / 2 * Math.Cos(2 * Math.PI * i / N)) + geom.Width / 2;
                            y[i] = (int)(geom.Height / 2 * Math.Sin(2 * Math.PI * i / N)) + geom.Height / 2;
                        }
                        for (int i = 0; i < N; i++) {
                            for (int j = i + 1; j < N; j++) {
                                gc.DrawLine(x[i], y[i], x[j], y[j]);
                            }
                        }

                        gc.DrawString(fs, 30, 30, "W ゆゆ式！");
                        gc.DrawStringMultiByte(fs, 30, 60, "M ゆゆ式！");

                        dpy.Flush();
                        break;

                    case TonNurako.X11.Event.XEventType.ClientMessage:
                        DumpStruct(ev.ClientMessage);
                        if (atom.Equals(ev.ClientMessage.data.l[0])) {
                            win.DestroyWindow();
                            break;
                        }
                        break;
                    case TonNurako.X11.Event.XEventType.DestroyNotify:
                        DumpStruct(ev.DestroyWindow);
                        if (null != gc) {
                            gc.Dispose();
                        }
                        fs.Dispose();
                        dpy.SetCloseDownMode(TonNurako.X11.CloseDownMode.DestroyAll);
                        dpy.Close();
                        return;

                    case TonNurako.X11.Event.XEventType.ButtonPress:
                        DumpStruct(ev.Button);
                        break;

                    case TonNurako.X11.Event.XEventType.KeyPress:
                        DumpStruct(ev.Key);
                        Console.WriteLine($"KS=     {dpy.KeycodeToKeysym(ev.Key.keycode,0,0)}");
                        Console.WriteLine($"KS=>KC  {dpy.KeysymToKeycode(dpy.KeycodeToKeysym(ev.Key.keycode, 0, 0))}");
                        Console.WriteLine($"KS=>STR {dpy.KeysymToString(dpy.KeycodeToKeysym(ev.Key.keycode, 0, 0))}");
                        Console.WriteLine($"STR=>KS {dpy.StringToKeysym(dpy.KeysymToString(dpy.KeycodeToKeysym(ev.Key.keycode, 0, 0)))}");
                        var ks = dpy.KeycodeToKeysym(ev.Key.keycode, 0, 0);
                        if (ks == TonNurako.X11.KeySym.XK_Escape) {
                            win.DestroyWindow();
                        }
                        break;

                    /*
                     case TonNurako.X11.Event.XEventType.ConfigureNotify:
                        break;

                     case TonNurako.X11.Event.XEventType.MappingNotify:
                         break;
                     case TonNurako.X11.Event.XEventType.UnmapNotify:
                         break;
                     case TonNurako.X11.Event.XEventType.ReparentNotify:
                         break;*/
                    default:
                        break;
                }
            }
        }
    }
}
