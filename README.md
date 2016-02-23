## ﾄﾝﾇﾗｺ

ﾄﾝﾇﾗｺ ﾄﾝﾇﾗｺ ﾄﾝﾇﾗｺ ﾄﾝﾇﾗｺ ﾄﾝﾇﾗｺﾄﾝﾇﾗｺ ﾄﾝﾇﾗｺ ﾄﾝﾇﾗｺ ﾄﾝﾇﾗｺ ﾄﾝﾇﾗｺ ﾄﾝﾇﾗｺ

ﾄﾝﾇﾗｺﾄﾝﾇﾗｺ ﾄﾝﾇﾗｺﾄﾝﾇﾗｺ ﾄﾝﾇﾗｺﾄﾝﾇﾗｺ ﾄﾝﾇﾗｺﾄﾝﾇﾗｺ ﾄﾝﾇﾗｺﾄﾝﾇﾗｺ ﾄﾝﾇﾗｺﾄﾝﾇﾗｺ ﾄﾝﾇﾗｺﾄﾝﾇﾗｺ ﾄﾝﾇﾗｺﾄﾝﾇﾗｺ ﾄﾝﾇﾗｺ ﾄﾝﾇﾗｺ ﾄﾝﾇﾗｺ



ﾗｲｾﾝｽはOpenMotifに従いLGPLとします


ﾄﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺ

![VSS](https://raw.githubusercontent.com/sazae657/TonNurako/master/ScreenShot.png)

## ﾋﾞﾙﾄﾞ

### 必要なもの

* 広い心
* mono
* OpenMotif 2.3+
* libXpm
* Python2

*Mac OSXで動かす場合は32bit版のﾗｲﾌﾞﾗﾘーを用意するかmono64のｲﾝｽﾄーﾙが必要な模様です

## ｿーｽを取ってくる
```
% git clone https://github.com/sazae657/TonNurako.git
% cd TonNurako
```

## TonNurako.extremesportsのﾋﾞﾙﾄﾞ準備

以下のｼｽﾃﾑでは事前に準備が必要です

* X11やMotifが一般的でない場所にｲﾝｽﾄーﾙされている場合
* 一部の不自由ｼｽﾃﾑで検疫ﾌｫﾙﾀﾞーにMotifが移動されてしまっている場合

該当しない場合はこの手順をすっ飛ばして構いません

#### 1. ﾊﾟｽを直指定する場合
 
TonNurako/TonNurakoEx/Config.mp3のﾊﾟｽを調整してください
```
% cd TonNurakoEx
% dtpad Config.mp3
```

#### 2. Config.mp3編集するのが面倒くさい場合

TonNurako/TonNurakoEx/import.app フォルダー直下にX11とXmへのｼﾝﾎﾞﾘｯｸﾘﾝｸを作成してください

```
# 例: Motifがｳｲﾙｽ並の扱いを受けて検疫ﾌｫﾙﾀﾞーに移動されてしまっている不自由ｼｽﾃﾑの場合

% cd TonNurako/TonNurakoEx/import.app
% ln -sv /Library/SystemMigration/History/Migration-{UUID}/QuarantineRoot/usr/include/X11 .
% ln -sv /Library/SystemMigration/History/Migration-{UUID}/QuarantineRoot/usr/include/Xm .
% ln -sv /Library/SystemMigration/History/Migration-{UUID}/QuarantineRoot/usr/lib .
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
