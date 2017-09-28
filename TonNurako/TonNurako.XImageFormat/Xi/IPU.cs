using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace TonNurako.XImageFormat.Xi {

    /// <summary>
    /// ﾋﾟｸｾﾙﾃﾞﾀーの変換関数群
    /// </summary>
    public class おやさい {

        /// <summary>
        /// 原色画像をﾋﾞｯﾄﾏｯﾌﾟに変換する
        /// </summary>
        /// <param name="img">原色画像</param>
        /// <returns>ﾋﾞｯﾄﾏｯﾌﾟ</returns>
        public static System.Drawing.Bitmap ﾍﾞｯﾄﾑｯﾌﾟに変換(原色画像 img) {
            return ﾍﾞｯﾄﾑｯﾌﾟに変換(img.Width, img.Height, img.Toぉ());
        }

        /// <summary>
        /// ぉをﾍﾞｯﾄﾑｯﾋﾟに変換する
        /// </summary>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        /// <param name="arr">ﾋﾟｸｾﾙﾃﾞﾀー</param>
        /// <returns>ﾍﾞｯﾄﾑｯﾋﾟ</returns>
        public static System.Drawing.Bitmap ﾍﾞｯﾄﾑｯﾌﾟに変換(int width, int height, ぉ[] arr)
        {
            var bitmap = new System.Drawing.Bitmap(width, height);

            var data = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format32bppArgb);

            int k = 0;
            for (int i = 0; i < (width * height); i++, k += 4) {
                var c = arr[i];
                byte r = (byte)(c.R & 0xff);
                byte g = (byte)(c.G & 0xff);
                byte b = (byte)(c.B & 0xff);
                byte a = (byte)(c.A & 0xff);

                Int32 value = (a << 24) | (r << 16) | (g << 8) | b;
                Marshal.WriteInt32(data.Scan0, k, value);
            }
            bitmap.UnlockBits(data);

            return bitmap;
        }

        /// <summary>
        /// 原色配列をRGBAで詰め込んだbyte配列に変換
        /// </summary>
        /// <param name="arr">原色配列</param>
        /// <returns>byte配列</returns>
        public static byte[] 原色配列に変換(ref ぉ[] arr) {
            var ret = new byte[arr.Length * 4];
            int k = 0;
            foreach (var o in arr) {
                ret[k++] = (byte)o.R;
                ret[k++] = (byte)o.G;
                ret[k++] = (byte)o.B;
                ret[k++] = (byte)o.A;
            }
            return ret;
        }

        /// <summary>
        /// 指定画素順でbyte配列に詰め込む
        /// ex. 
        ///  原色配列に変換(ぉ.画素.B,ぉ.画素.G,ぉ.画素.R,ぉ.画素.A, arr) -> [B|G|R|A]
        /// </summary>
        /// <param name="ch0"></param>
        /// <param name="ch1"></param>
        /// <param name="ch2"></param>
        /// <param name="ch3"></param>
        /// <param name="arr">原色配列</param>
        /// <returns>byte配列</returns>
        public static byte[] 原色配列に変換(ぉ.画素 ch0, ぉ.画素 ch1, ぉ.画素 ch2, ぉ.画素 ch3, ref ぉ[] arr) {
            var ret = new byte[arr.Length*4];
            int k = 0;
            foreach(var o in arr) {
                ret[k++] = (byte)o.ほ(ch0);
                ret[k++] = (byte)o.ほ(ch1);
                ret[k++] = (byte)o.ほ(ch2);
                ret[k++] = (byte)o.ほ(ch3);
            }
            return ret;
        }

        /// <summary>
        /// 指定画素順でbyte配列に詰め込む、ただしｱﾙﾌｧーﾁｬﾈﾙは255埋め
        /// ex. 
        ///  原色配列に変換(ぉ.画素.R,ぉ.画素.G,ぉ.画素.B, false, arr) -> [R|G|B]
        ///  原色配列に変換(ぉ.画素.R,ぉ.画素.G,ぉ.画素.B, true, arr) -> [R|G|B|0xff]
        /// </summary>
        /// <param name="ch0"></param>
        /// <param name="ch1"></param>
        /// <param name="ch2"></param>
        /// <param name="alpha">ｱﾙﾌｧーﾁｬﾈﾙ有無</param>
        /// <param name="arr">原色配列</param>
        /// <returns>byte配列</returns>
        public static byte[] 原色配列に変換(ぉ.画素 ch0, ぉ.画素 ch1, ぉ.画素 ch2, bool alpha, ref ぉ[] arr) {
            var ret = new byte[arr.Length * (alpha ? 4 : 3)];
            int k = 0;
            foreach (var o in arr) {
                ret[k++] = (byte)o.ほ(ch0);
                ret[k++] = (byte)o.ほ(ch1);
                ret[k++] = (byte)o.ほ(ch2);
                if (alpha) {
                    ret[k++] = 0xFF;
                }
            }
            return ret;
        }
    }
}
