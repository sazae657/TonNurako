## ﾄﾝﾇﾗｺ

.NetでMotifが使えればいいな・・・

ﾗｲｾﾝｽはOpenMotifに従いLGPLとします

ﾄﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺ

![VSS](https://raw.githubusercontent.com/sazae657/TonNurako/master/ScreenShot.png)

## ﾋﾞﾙﾄﾞ

### 必要なもの

* 広い心
* mono
* OpenMotif 2.3
* libXpmのﾍｯﾀﾞー
* Python2

*Mac OSXで動かす場合は32bit版のﾗｲﾌﾞﾗﾘーを用意するかmono64のｲﾝｽﾄーﾙが必要な模様です

## ｿーｽを取ってくる
```
% git clone https://github.com/sazae657/TonNurako.git
% cd TonNurako
```

## TonNurako.extremesportsのﾋﾞﾙﾄﾞ

必要に応じてConfig.mp3のﾊﾟｽを調整してください
```
% cd TonNurakoEx
% dtpad Config.mp3
```

この辺を環境に合わせて調整してください
```
# Motifのﾍｯﾀﾞーとﾗｲﾌﾞﾗﾘーのﾊﾟｽ
MOTF_HEADER_PATH=/usr/dt/include
MOTF_LIBRARY_PATH=/usr/dt/lib

# X11のﾍｯﾀﾞーとﾗｲﾌﾞﾗﾘーのﾊﾟｽ
X11_HEADER_PATH=/usr/X11R6/include
X11_LIBRARY_PATH=/usr/X11R6/lib

```

ﾋﾞﾙﾄﾞ出来る事の確認
```
% make clean all
```

## ﾄﾝﾇﾗｺ本体とﾃﾞﾓのﾋﾞﾙﾄﾞ
```
% cd ..
% xbuild
% ls mono bin/Debug/Widgets.exe
 mono bin/Debug/Widgets.exe
%
```

## ﾃﾞﾓの実行
```
% mono bin/Debug/Widgets.exe
```

Visual Studio Codeがあればﾃﾞﾊﾞｯｸﾞﾎﾞﾀﾝから実行できます

ﾄﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺ

### ｳｲﾝﾄﾞｳにﾎﾞﾀﾝが出来るだけのｻﾝﾌﾟﾙ

```
using TonNurako.Widgets;
using TonNurako.Widgets.Xm;

namespace Simple
{
    class Program : Window
    {
        public override void ShellCreated() {
            var button = new PushButton();
            button.LabelString = "TonNurako!!";
            this.Children.Add(button);
        }

        static void Main(string[] args) {
            TonNurako.Application.Run(
                new TonNurako.ApplicationContext(), new Program());
        }
    }
}

```

```
% mcs /t:exe /r:TonNurako.dll Hoge.cs
% MONO_PATH=<path-to TonNurako.dll> mono Hoge.exe
```
ﾄﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺ
