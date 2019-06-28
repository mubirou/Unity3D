# Oculus Quest 対応

### <b>INDEX</b>

* [MACアドレスの取得](#MACアドレスの取得)
* [ビルドの基本](#ビルドの基本)
* [提供元不明アプリの削除方法](#提供元不明アプリの削除方法)
* [Facebookのハンドルネーム登録](#Facebookのハンドルネーム登録)
* [OculusTouchの基本](#OculusTouchの基本)
***


<a name="MACアドレスの取得"></a>
# <b>MACアドレスの取得</b>

### MACアドレスの取得①

1. Oculus デベロッパー登録をする  
    https://dashboard.oculus.com/

1. Oculus Quest を開発モードにする  
    1. スマホ上の [Oculusアプリ](https://bit.ly/2KuxKEu) を起動
    1. [設定] を選び「近くにあります」という表示される "Oculus Quest XXX…" を選択し接続
    1. [設定]-[その他の設定]-[開発者モード] を ON にする

1. コンピュータ（Ubuntu）と Oculus Quest を USB 接続  
    （Oculus Quest 画面に英語で「このコンピュータを信頼するか？」という主旨の表示）

1. Ubuntu の端末上で次の処理を行う  
    ```
    $ adb version ←インストールされているか確認
    …
    $ adb devices  ←コンピュータに接続されているデバイスを確認
    List of devices attached
    XXXXXXXXXXXXXX device ←ケーブルを抜差してQuestであることを突き止める

    $ adb -s XXXXXXXXXXXXXX shell ip addr show wlan0
    ……
    link/ether XX:XX:XX:XX:XX:XX brd ff:ff:ff:ff:ff:ff
    ↑XX:XX:XX:XX:XX:XX がQuestのMACアドレス
    ```

### MACアドレスの取得②

1. Play ストアから [Oculus](https://play.google.com/store/apps/details?id=com.oculus.twilight) アプリをダウンロード
1. [Oculus] アプリを起動→[⚙設定]→対象の Oculus Quest を選択し接続
1. 接続済みの Oculus Quest をタップ→ [...その他の設定]→[このヘッドセットについて] を選択
1. [MACアドレス] に表示される XX:XX:XX:XX:XX:XX がQuestのMACアドレス

実行環境：Ubuntu 18.04.2 LTS、Oculus Quest、Android 9.0.1、Oculus 25.0  
作成者：夢寐郎  
作成日：2019年06月07日  
更新日：2019年06月28日  


<a name="ビルドの基本"></a>
# <b>ビルドの基本</b>

### ビルドの手順

1. Oculus Quest を開発モードにする  
    1. スマホ上の [Oculusアプリ](https://bit.ly/2KuxKEu) を起動
    1. [設定] を選び「近くにあります」という表示される "Oculus Quest XXX…" を選択し接続
    1. [設定]-[その他の設定]-[開発者モード] を ON にする
1. コンピュータ（Ubuntu）と Oculus Quest を USB 接続  
    （Oculus Quest 画面に英語で「このコンピュータを信頼するか？」という主旨の表示）
1. Unity のメニューから [File]-[BuildSettings] を選ぶ
1. [AddOpenScnes] を押してビルドするシーンを登録
1. [Platform] を [Android] に変更
1. [PlaySettings] を選択
1. [OtherSEttings] を次の通りに設定  
    * Package Name：com.mubiorou.sample001（名前は任意）
    * Minimum API Level：Android 4.4 "KitKat"（API level 19）
1. [XRSettings] を次の通りに設定
    * Virtual Reality Supported：✔
    * [Virtual Reality SDKs]-[+]-[Oculus] を選択
1. [BuildAndRun] ボタンを押す
1. Oclusu Quest の [ホーム画面]-[ライブラリ]-[提供元不明のアプリ] から上記でビルドされたアプリを選択し起動  

### emulator-5554 shell getprop エラー対策

* Unityで [BuildAndRun] を実行する際、<b>"emulator-5554 shell getprop"</b> と Console に表示され、PC と USB 接続した Android 端末（Oculus Quest）にビルドできないことがあります。その場合、Unity を起動した状態、および PC と Android 端末と接続した状態で、Ubuntu の「端末」で次の通りに処理します。尚、Android SDK のパスは、Unity の [Edit]-[Preferencese]-[ExternalTools] の Android SDK のパスを参照します。

```
$ adb devices   ←現在接続されているエミュレータを確認
List of devices attached
XXXXXXXXXXXXXXXX  device   ←Android端末（Oculus Quest）
emulator-5554  offline   ←これが余計でエラーが発生

$ /home/（ユーザ名）/Android/Sdk/platform-tools/adb kill-server
```

尚、adb を再起動する場合は次の通りにします。

```
$ /home/（ユーザ名）/Android/Sdk/platform-tools/adb start-server
```

実行環境：Ubuntu 18.04.2 LTS、Unity 2018.3.0f2 Personal、Oculus Quest  
作成者：夢寐郎  
作成日：2019年06月07日  
更新日：2019年06月12日 エラー対策


<a name="提供元不明アプリの削除方法"></a>
# <b>提供元不明アプリの削除方法</b>

### 提供元不明アプリの削除方法

1. Oculus Quest 上のメニューから [ナビゲーション]-[ライブラリ]-[提供元不明アプリ] から削除したいアプリを確認（アプリ毎に Unity で設定した次の情報が表示されます）  
    * Procut Name
    * Package Name  

1. Ubuntu の端末上でパッケージを探す  
    ```
    $ adb shell pm list package
    ……
    package:com.mubirou.XXXXXX ←Unityで設定したpackage Name

1. 引き続き端末上でパッケージを削除
    ```
    $ adb uninstall com.mubirou.XXXXXX ←上記で探したパッケージを指定
    ```

1. Oculus Quest 上のメニューから [ナビゲーション]-[ライブラリ]-[提供元不明アプリ] を再表示し、削除されているのを確認


実行環境：Ubuntu 18.04.2 LTS、Unity 2018.3.0f2 Personal、Oculus Quest  
作成者：夢寐郎  
作成日：2019年06月17日  


<a name="OculusTouchの基本"></a>
# <b>Oculus Touchの基本</b>

### この項目は書きかけです

### パッケージのインポート

1. [ここ](https://developer.oculus.com/downloads/package/oculus-utilities-for-unity-5/) から "Oculus Utilities for Unity" をダウンロードし展開
1. Unity を起動
1. [Assets]-[ImportPackage]-[CustomPackge] から上記でダウンロードした "OculusUtilities.unitypackage" を選択しインポート

1. Asset Store から "Oculus Integration" をインポート  
    または [Oculus](https://developer.oculus.com/downloads/package/unity-integration/) サイトから [Download the Oculus Integration] を選択


1. Unity の [Window]-[AssetStore] を開く
1. [SignIn] から
1. [OculusIntegration](https://assetstore.unity.com/packages/tools/integration/oculus-integration-82022) を検索し [Download]
1. 

実行環境：Ubuntu 18.04.2 LTS、Unity 2019.1.0f2 Personal、Oculus Quest  
作成者：夢寐郎  
作成日：2019年06月XX日  

© 2019 夢寐郎