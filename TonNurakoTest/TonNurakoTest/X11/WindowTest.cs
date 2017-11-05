using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TonNurako.Inutility;
using TonNurako.X11;
using Xunit;

namespace TonNurakoTest.X11 {
    public class WindowTest : AbstractDisplayTest {

        Window window;
        delegate void NopDelegaty();
        Unity unity = new Unity();

        public WindowTest() {
        }

        public override void Dispose() {
            unity.Asset();
            if (null != window) {
                window.DestroyWindow();
                window = null;
            }
            base.Dispose();
        }

        [Fact]
        void StandardWindwTest() {
            CreateWindow(
               BeforeCreateWindow: ()=>{
                },
                BeforeMapWindow:()=>{
                    var attr = new TonNurako.X11.XSetWindowAttributes();
                    attr.backing_store = TonNurako.X11.BackingStoreHint.WhenMapped;
                    Assert.Equal(XStatus.True, window.ChangeWindowAttributes(TonNurako.X11.ChangeWindowAttributes.CWBackingStore, attr));
                    Assert.Empty(window.GetWMProtocols());
                },
                AfterMapWindow: ()=>{}
            );
            window.DestroyWindow();
            window = null;
        }
        [Fact]
        void StdProps() {
            CreateWindow(
               BeforeCreateWindow: ()=>{
                },
                BeforeMapWindow:() =>{ },
                AfterMapWindow: () =>{
                    Assert.Equal(XStatus.True, window.StoreName("UNKO"));
                    Assert.Equal("UNKO", window.FetchName());

                    Assert.Equal(XStatus.True, window.SetIconName("UNKO"));
                    Assert.Equal("UNKO", window.GetIconName());

                    var color = Color.AllocNamedColor(display, display.DefaultColormap, "green");
                    Assert.NotNull(color);

                    Assert.Equal(XStatus.True, window.SetWindowBackground(color));
                    Assert.Equal(XStatus.True, window.SetWindowBorder(color));

                    var pm = new Pixmap(display, window, 100, 100, display.DefaultDepth);
                    Assert.Equal(XStatus.True, window.SetWindowBackgroundPixmap(pm));
                    Assert.Equal(XStatus.True, window.SetWindowBorderPixmap(pm));
                    unity.Store(pm);

                    Assert.Equal(XStatus.True, window.MoveWindow(0, 0));
                    Assert.Equal(XStatus.True, window.ResizeWindow(10, 10));
                    Assert.Equal(XStatus.True, window.MoveResizeWindow(10,10, 20, 20));
                    Assert.Equal(XStatus.True, window.SetWindowBorderWidth(10));
                    Assert.NotNull(window.GetWindowAttributes());
                    Assert.NotNull(window.GetGeometry());
                }
            );
            window.DestroyWindow();
            window = null;
        }

        [Fact]
        void Protocols() {
            var atom = TonNurako.X11.Atom.InternAtom(display, "WM_DELETE_WINDOW", false);
            Assert.NotNull(atom);
            Assert.Equal("WM_DELETE_WINDOW", atom.Name);

            var atom1 = TonNurako.X11.Atom.InternAtom(display, "WM_DELETE_WINDOW", false);
            Assert.NotNull(atom1);
            Assert.True(atom.Equals(atom1));

            var atom2 = TonNurako.X11.Atom.InternAtom(display, "俺様の考えた最強のﾌﾟﾛﾄｺﾙ", false);
            Assert.NotNull(atom2);
            Assert.False(atom.Equals(atom2));
            Assert.Equal("俺様の考えた最強のﾌﾟﾛﾄｺﾙ", atom2.Name);

            var ass = TonNurako.X11.Atom.InternAtoms(display, new[]{"WM_DELETE_WINDOW", "WM_CLOSE", "WM_FOREACH"}, false);
            Assert.NotNull(ass);

            CreateWindow(
               BeforeCreateWindow: ()=>{
                },
                BeforeMapWindow:()=>{
                    var attr = new TonNurako.X11.XSetWindowAttributes();
                    attr.backing_store = TonNurako.X11.BackingStoreHint.WhenMapped;
                    Assert.Equal(XStatus.True, window.ChangeWindowAttributes(TonNurako.X11.ChangeWindowAttributes.CWBackingStore, attr));

                    Assert.Empty(window.GetWMProtocols());

                    Assert.Equal(XStatus.True, window.SetWMProtocols(new TonNurako.X11.Atom[] { atom, atom2 }));
                    Assert.NotEmpty(window.GetWMProtocols());

                    using(var rpr = TonNurako.X11.XTextProperty.TextListToTextProperty(
                        display, new string[] { "たいとる" }, TonNurako.X11.XICCEncodingStyle.XCompoundTextStyle)) {
                        Assert.NotNull(rpr);
                        window.SetWMName(rpr);
                    }
                    using(var rpr = TonNurako.X11.XTextProperty.TextListToTextProperty(
                        display, new string[] { "エイコン" }, TonNurako.X11.XICCEncodingStyle.XCompoundTextStyle)) {
                        Assert.NotNull(rpr);
                        window.SetWMIconName(rpr);
                    }

                    using(var prpr = window.GetWMName()) {
                        Assert.NotNull(prpr);
                        var r = prpr.TextPropertyToTextList(display);
                        Assert.NotNull(r);
                        Assert.Single(r);
                    }
                    using(var prpr = window.GetWMIconName()) {
                        Assert.NotNull(prpr);
                        var r = prpr.TextPropertyToTextList(display);
                        Assert.NotNull(r);
                        Assert.Single(r);
                    }

                },
                AfterMapWindow: ()=>{}
            );
            window.DestroyWindow();
            window = null;
        }

        void CreateWindow(
            NopDelegaty BeforeCreateWindow, NopDelegaty BeforeMapWindow, NopDelegaty AfterMapWindow) {
            var visual = this.display.DefaultVisual;
            Assert.NotNull(visual);

            var wsa = new TonNurako.X11.XSetWindowAttributes();
            wsa.background_pixel = this.display.WhitePixel;
            var wam = TonNurako.X11.ChangeWindowAttributes.CWBackPixel;

            BeforeCreateWindow();

            this.window = this.display.CreateWindow(
                this.display.DefaultRootWindow, 50, 50, 50, 50, 0,
                this.display.DefaultDepth, TonNurako.X11.WindowClass.InputOutput, visual, wam, wsa);
            Assert.NotNull(this.window);

            BeforeMapWindow();

            Assert.Equal(XStatus.True, this.window.MapWindow());
            Assert.Equal(XStatus.True, display.Flush());

            AfterMapWindow();
        }


    }
}
