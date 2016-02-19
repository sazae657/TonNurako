using TonNurako.Native.X11;
using TonNurako.Native.Xt;
namespace TonNurako.Data
{
    /// <summary>
    /// KeySym
    /// </summary>
    public class KeySym {
        public int NativeKeySym {
            get; internal set;
        }

        public string KeySymStr {
            get; internal set;
        }

        private KeySym() {
            KeySymStr = "";
        }

        public static KeySym FromName(string _Name) {
            var r = new KeySym();

            r.NativeKeySym = X11Sports.XStringToKeysym(_Name);
            r.KeySymStr = X11Sports.XKeysymToString(r.NativeKeySym);

            System.Diagnostics.Debug.WriteLine($"KeySym.FromName<{_Name}> KS={r.NativeKeySym} ST={r.KeySymStr}");

            return r;
        }
        public static KeySym FromKeySym(int _KeySym) {
            var r = new KeySym();

            r.NativeKeySym = _KeySym;
            r.KeySymStr = X11Sports.XKeysymToString(r.NativeKeySym);
            System.Diagnostics.Debug.WriteLine($"KeySym.FromKeySym<{_KeySym}> KS={r.NativeKeySym} ST={r.KeySymStr}");

            return r;
        }

        public override string ToString() {
            return KeySymStr;
        }

    }

    public class Accelerators {
        internal Accelerators() {
        }

        internal System.IntPtr Binary {
            get; set;
        }

        public static Accelerators Compile(string source) {
            Accelerators r = new Accelerators();
            r.Binary = XtSports.XtParseAcceleratorTable(source);
            return r;
        }
    }

    public class Translations {
        internal Translations() {
        }

        internal System.IntPtr Binary {
            get; set;
        }

        public static Translations Compile(string source) {
            Translations r = new Translations();
            r.Binary = XtSports.XtParseTranslationTable(source);
            return r;
        }
    }
}
