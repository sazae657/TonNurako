using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XShape {
    class Program {
        static void Main(string[] args) {
            TonNurako.Application.RegisterGlobals();
            // ごみボックス
            var unity = new TonNurako.Inutility.Unity();

            System.Drawing.Bitmap maskImage = Properties.Resources.fallback; 
            if (args.Length > 0) {
                maskImage = unity.Store(new System.Drawing.Bitmap(args[0]));
            }
            

            var loc = TonNurako.X11.X11Sports.SetLocale(TonNurako.X11.XLocale.LC_ALL, "");
            if (null == loc) {
                Console.WriteLine("Cannot set the locale.\n");
                return;
            }

            if (!TonNurako.X11.X11Sports.SupportsLocale()) {
                Console.WriteLine("Current locale is not supported");
                return;
            }

            TonNurako.X11.X11Sports.SetIOErrorHandler((d) => {
                Console.WriteLine("IOE");
                return -1;
            });
            TonNurako.X11.X11Sports.SetErrorHandler((d, e) => {
                Console.WriteLine("*** E ***");
                TonNurako.Inutility.Dumper.DumpStruct(e, (s) => {
                    Console.WriteLine($"XERR: {s}");
                });
                Console.WriteLine("******");
                return -1;
            });

            var dpy = TonNurako.X11.Display.Open(null);
            if (dpy.Handle == IntPtr.Zero) {
                Console.WriteLine("cannot open display");
                return;
            }

            var fs = unity.Store(TonNurako.X11.FontSet.CreateFontSet(dpy, "-*-fixed-medium-r-normal--14-*-*-*"));

            var rw = dpy.DefaultRootWindow;

            var atom = TonNurako.X11.Atom.InternAtom(dpy, "WM_DELETE_WINDOW", true);         

            var win = dpy.CreateSimpleWindow(
                rw, 0, 0, maskImage.Width, maskImage.Height, 0,
                TonNurako.X11.Color.AllocNamedColor(dpy, dpy.GetDefaultColormap(), "yellow"),
                TonNurako.X11.Color.AllocNamedColor(dpy, dpy.GetDefaultColormap(), "black"));

            win.SetWMProtocols(new TonNurako.X11.Atom[] { atom });
            win.SelectInput(TonNurako.X11.EventMask.StructureNotifyMask |
                TonNurako.X11.EventMask.ExposureMask |
                TonNurako.X11.EventMask.ButtonPressMask |
                TonNurako.X11.EventMask.KeyPressMask);

            var attr = new TonNurako.X11.XSetWindowAttributes();
            attr.backing_store = TonNurako.X11.BackingStoreHint.WhenMapped;
            win.ChangeWindowAttributes(TonNurako.X11.ChangeWindowAttributes.CWBackingStore, attr);

            win.StoreName("shapew");

            var rpr = TonNurako.X11.XTextProperty.TextListToTextProperty(
                dpy, new string[] { "たいとる" }, TonNurako.X11.XICCEncodingStyle.XCompoundTextStyle);
            win.SetWMName(rpr);

            var rpr2 = TonNurako.X11.XTextProperty.TextListToTextProperty(
                dpy, new string[] { "エイコン" }, TonNurako.X11.XICCEncodingStyle.XCompoundTextStyle);
            win.SetWMIconName(rpr2);


            // αﾁｬﾈﾙからﾏｽｸ生成
            var oim = TonNurako.XImageFormat.Xi.おやさい.ぉに変換(maskImage);
            var o = TonNurako.XImageFormat.Xi.おやさい.XBM配列に変換(maskImage.Width, maskImage.Height, TonNurako.XImageFormat.Xi.ぉ.画素.A, false, oim);
            var bitmap = unity.Store(TonNurako.X11.Pixmap.FromBitmapData(win, maskImage.Width, maskImage.Height, o));
            
            TonNurako.X11.Extension.Shape.CombineMask(dpy, win,
                TonNurako.X11.Extension.ShapeKind.ShapeBounding, 0, 0, bitmap, TonNurako.X11.Extension.ShapeOp.ShapeSet);

            // 背景設定
            var bg = unity.Store(TonNurako.GC.PixmapFactory.FromBitmap(win, maskImage));
            win.SetWindowBackgroundPixmap(bg);

            win.MapWindow();
            dpy.Flush();

            TonNurako.X11.GC gc = null;
            var ev = new TonNurako.X11.Event.XEventArg();
            while (true) {
                dpy.NextEvent(ev);
                Console.WriteLine($"NextEvent ev={ev.Type}");
                switch (ev.Type) {
                    case TonNurako.X11.Event.XEventType.CreateNotify:
                        break;
                    case TonNurako.X11.Event.XEventType.Expose:
                        if (null == gc) {
                            gc = unity.Store(TonNurako.X11.GC.Create(win));
                            gc.SetForeground(TonNurako.X11.Color.AllocNamedColor(dpy, dpy.GetDefaultColormap(), "Green"));
                        }

                        dpy.Flush();
                        break;

                    case TonNurako.X11.Event.XEventType.ClientMessage:
                        if (atom.Equals(ev.ClientMessage.data.l[0])) {
                            win.DestroyWindow();
                            break;
                        }
                        break;
                    case TonNurako.X11.Event.XEventType.DestroyNotify:
                        unity.Asset();
                        dpy.SetCloseDownMode(TonNurako.X11.CloseDownMode.DestroyAll);
                        dpy.Close();
                        return;

                    case TonNurako.X11.Event.XEventType.ButtonPress:
                        break;

                    case TonNurako.X11.Event.XEventType.KeyPress:
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
