using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TonNurako.Inutility {
    public class Dumper {
        public delegate void Delegaty(string p);

        public static void DumpProperty(object obzekt, Delegaty delegaty) {
            var infoArray = obzekt.GetType().GetProperties();
            foreach (var info in infoArray) {
                var sv = "(NULL)";
                var v = info.GetValue(obzekt, null);
                if (null != v) {
                    sv = v.ToString();
                }
                delegaty($"{obzekt.GetType().Name}# {info.Name}={sv}");
            }
        }

        public static void DumpStruct(object obzekt, Delegaty delegaty) {
            if (null == obzekt) {
                throw new NullReferenceException("obzekt is NULL!!");
            }
            var infoArray = obzekt.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (var m in infoArray) {
                //Console.WriteLine($"{obzekt.GetType().Name}# {m.Name}");
                var v = m.GetValue(obzekt);
                var sv = "(NULL)";
                if (null != v) {
                    sv = v.ToString();
                }
                delegaty($"{obzekt.GetType().Name}# {m.Name}={sv}");
            }
        }
    }
}
