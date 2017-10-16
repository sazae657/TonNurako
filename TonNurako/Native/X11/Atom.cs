using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11 {
    public class Atom : IX11Interop, IEqualityComparer<Atom> {

        internal static class NativeMethods {
            // Atom: XInternAtom [{'type': 'Display*', 'name': 'display'}, {'type': 'char*', 'name': 'atom_name'}, {'type': 'Bool', 'name': 'only_if_exists'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XInternAtom_TNK", CharSet = CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true)]
            internal static extern IntPtr XInternAtom(IntPtr display, [MarshalAs(UnmanagedType.LPStr)] string atom_name, [MarshalAs(UnmanagedType.U1)] bool only_if_exists);

            // Status: XInternAtoms [{'type': 'Display*', 'name': 'display'}, {'type': 'char*', 'name': '*names'}, {'type': 'int', 'name': 'count'}, {'type': 'Bool', 'name': 'only_if_exists'}, {'type': 'Atom*', 'name': 'atoms_return'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XInternAtoms_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern int XInternAtoms(IntPtr display, [MarshalAs(UnmanagedType.LPStr)] string names, int count, [MarshalAs(UnmanagedType.U1)] bool only_if_exists, IntPtr atoms_return);

            // char*: XGetAtomName [{'type': 'Display*', 'name': 'display'}, {'type': 'Atom', 'name': 'atom'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetAtomName_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XGetAtomName(IntPtr display, IntPtr atom);

            // Status: XGetAtomNames [{'type': 'Display*', 'name': 'display'}, {'type': 'Atom*', 'name': 'atoms'}, {'type': 'int', 'name': 'count'}, {'type': 'char*', 'name': '*names_return'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetAtomNames_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern int XGetAtomNames(IntPtr display, IntPtr atoms, int count, [MarshalAs(UnmanagedType.LPStr)] string names_return);

        }

        public Atom() {
        }

        public Atom(IntPtr handle, Display dpy) {
            this.atom = handle;
            this.display = dpy;
        }

        public static Atom InternAtom(Display display, string name, bool only_if_exists) {
            var r = NativeMethods.XInternAtom(display.Handle, name, only_if_exists);
            if (r == IntPtr.Zero) {
                return null;
            }
            return (new Atom(r, display));
        }

        public bool Equals(Atom x, Atom y) {
            return (x.Handle == y.Handle &&
                    x.display.Handle == y.display.Handle);
        }

        public bool Equals(long atom) {
            return ((long)this.Handle == atom);
        }

        public int GetHashCode(Atom obj) {
            return (int)display.Handle ^ (int)atom;
        }

        public string Name => 
            Marshal.PtrToStringAnsi(NativeMethods.XGetAtomName(display.Handle, Handle));

        Display display;
        object obzekt = new object();

        IntPtr atom = IntPtr.Zero;
        public IntPtr Handle => atom;

    }
}
