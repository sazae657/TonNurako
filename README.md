# ﾄﾝﾇﾗｺ

＜ﾄﾝﾇﾗｺ＞.NetでX/Motifをなんとかしようというﾊﾞﾍﾞﾙの塔＜ﾄﾝﾇﾗｺ＞

ﾗｲｾﾝｽはOpenMotifに従いLGPLとします


![VSS](https://raw.githubusercontent.com/sazae657/TonNurako/master/ScreenShot.png)

[![Build Status](https://travis-ci.org/sazae657/TonNurako.svg?branch=master)](https://travis-ci.org/sazae657/TonNurako)


## ﾋﾞﾙﾄﾞ

### 必要なもの

* 広い心
* mono 5.x
* OpenMotif 2.3+
* Python2
* GNUMake

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
* msbuildを叩いたら *PrePareExtremeSports* もしくは *BuildExtremeSports* でｴﾗーになった場合

該当しない場合はこの手順をすっ飛ばして構いません
<details>
<summary>手順詳細</summary>
1. 依存ﾗｲﾌﾞﾗﾘーを自動検索させる場合
    TonNurako/TonNurakoExで *make audio* を叩いてください

    *AUDIO OK*と表示されれば成功です
    ```
    % make audio
    (中略)
    -- AUDIO OK --
    %
    ```

1. ﾊﾟｽを指定する場合

    TonNurako/TonNurakoEx/Config.mp3 を TonNurako/TonNurakoEx/Site.mp3にｺﾋﾟーしてﾊﾟｽを調整してください
    ```
    % cd TonNurakoEx
    % cp -i Config.mp3 Site.mp3
    % dtpad Site.mp3
    ```

1. Config.mp3編集するのが面倒くさい場合

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
</details>

## ﾄﾝﾇﾗｺ本体とﾃﾞﾓのﾋﾞﾙﾄﾞ
```
% msbuild
---
% ls bin/Debug/*Ton*
 bin/Debug/TonNurako.dll
 bin/Debug/TonNurako.dll.mdb
 bin/Debug/libTonNurako.extremesports
% ls bin/Debug/*.exe
 bin/Debug/Simple.exe
 bin/Debug/Widgets.exe
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
