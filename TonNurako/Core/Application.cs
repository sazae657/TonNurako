//
// ﾄﾝﾇﾗｺ
//
//　ﾄﾝﾇﾗｹーｼｮﾝ
//
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using TonNurako.Data;
using TonNurako.Native;

namespace TonNurako {
    /// <summary>
    /// ｱﾌﾟﾘｹーｼｮﾝｺﾝﾃｷｽﾄの実行諸々
    /// </summary>
    sealed public class Application
    {
		/// <summary>
        /// ｸﾞﾛーﾊﾞﾙｺﾝﾃｷｽﾄ(使わない)
        /// </summary>
		private static ApplicationContext GlobalContext {
            [MethodImpl(MethodImplOptions.Synchronized)] get;
            set;
        }

		//最終ﾘﾀーﾝｺーﾄﾞ
		private static int retVal = 0;

		//"名前"払い出し用ｶｳﾝﾀ
		private static int widgetCount = 0;

        /// <summary>
        /// 実行
        /// </summary>
        /// <param name="_Ctx">ﾄﾝﾇﾗｺﾝﾃｷｽﾄ</param>
        /// <param name="_Shell">ｼｪﾙ</param>
        /// <returns></returns>
        public static int Run(ApplicationContext _Ctx, Widgets.IShell _Shell) {
            return Run(_Ctx, _Shell, new string[]{});
        }

        /// <summary>
        /// 実行
        /// </summary>
        /// <param name="_Ctx">ﾄﾝﾇﾗｺﾝﾃｷｽﾄ</param>
        /// <param name="_Shell">ｼｪﾙ</param>
        /// <param name="_Args">引数(Xtに渡されちゃうよ)</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static int Run(ApplicationContext _Ctx, Widgets.IShell _Shell, string[] _Args) {
            GlobalContext = _Ctx;

            Native.Xt.XtSports.Register("Xt");
            Native.Motif.XmSports.Register("Xm");
            Native.X11.X11Sports.Register("X11");

            if (_Ctx.Name == "") {
                Assembly running = Assembly.GetEntryAssembly();
                // 名無しｺﾝﾃｷｽﾄは無理なのでﾌｧｲﾙ名から強制命名
                _Ctx.Name = System.IO.Path.GetFileNameWithoutExtension(running.Location);
            }

            var rs = new List<string>();
            foreach(var v in _Ctx.FallbackResource) {
                rs.Add($"{v.Key}: {v.Value}");
            }

            _Ctx.NativeContext = new ExtremeSports.TnkAppContext();
            ExtremeSports.TnkCode code =
                (ExtremeSports.TnkCode)ExtremeSports.XtInitialize(out _Ctx.NativeContext, _Ctx.Name, _Args, rs.ToArray());
            if (ExtremeSports.TnkCode.Ok != code) {
                throw new Exception(code.ToString());
            }

            //名前ｶｳﾝﾀーの初期化
			widgetCount = 0;

            _Ctx.Shell = _Shell;
            _Shell.Create(_Ctx, _Args);
            _Shell.Realize();

            ExtremeSports.AppMainLoop(_Ctx.NativeContext.context);

            Native.Motif.XmSports.Unregister();
            Native.Xt.XtSports.Unregister();
            Native.X11.X11Sports.Unregister();

            return retVal;
        }

		/// <summary>
		/// それなりにﾕﾆーｸな"名前"を払い出す
		/// </summary>
		/// <returns>それなりにﾕﾆーｸな"名前"</returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
		public static string CreateTempName( string key )
		{
            if (null != GlobalContext) {
                return GlobalContext.CreateTempName(key);
            }
            return $"TNK_{key}{widgetCount++:d4}";
		}

		/// <summary>
		/// ｱﾌﾟﾘｹーｼｮﾝの終了
		/// </summary>
		public static void Exit(ApplicationContext _Ctx)
		{
			//全ｳｲｼﾞｪｯﾄを優しく殺す
			ExtremeSports.AppSetExitFlag(_Ctx.NativeContext.context);
		}

    }
}
