# Oculus Quest 対応

### <b>INDEX</b>

* [MACアドレスの取得](#MACアドレスの取得)
* [ビルドの基本](#ビルドの基本)
* [提供元不明アプリの削除方法](#提供元不明アプリの削除方法)
* [PCと接続できない場合](#PCと接続できない場合)
* [OculusTouchのイロハ](#OculusTouchのイロハ)
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
更新日：2019年06月28日 MACアドレスの取得②を追加  


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
1. [Platform] を [Android] に変更し [SwitchPlatform] をクリック
1. [PlaySettings] を選択
1. [Publishing Settings] を次の通りに設定  
    1. [KeystoreManager...] を選択
    1. [Keystore...]-[CreateNew]-[Anywhere] を選択
    1. 名前を "**mubirou.keystore**" 等に変更
    1. [KeystoreManager] に戻り次の通りに設定し [AddKey] をクリック  
        * Password：XXXX
        * Confirm password：XXXX
        * Alias：mubirou（任意）
        * Password：XXXX
        * Confirm password：XXXX
1. [Player] を次の通りに設定  
    * Product Name：**saple001**（アプリ名･Quest上に表示）
1. [OtherSEttings] を次の通りに設定  
    * Package Name：**com.mubiorou.sample001**（これでアプリを識別･Quest上に表示）
    * Minimum API Level：Android 4.4 "KitKat"（API level 19）
1. [XRSettings] を次の通りに設定
    * Virtual Reality Supported：✔
    * [Virtual Reality SDKs]-[+]-[Oculus] を選択
1. 画質向上のために次の設定を行います  
    * [Edit]-[ProjectSettings]-[Quality] の上部の GUI で Android の Levels の [Default] を「Ultra」に変更
    * [Edit]-[ProjectSettings]-[Quality]-[ShadowDistance] を 150→40 程度に変更
1. [BuildAndRun] ボタンを押す  
    * 必要に応じて [PlayerSettings...] から上記で設定したパスワードの入力をする
1. **saple001.apk** と名前（任意）を付けて [保存] を選択
1. 途中 "Android device emulator-5554 is not responding!" 等々のダイアログが表示された場合 [Ok] を押す（下記のエラー対策をしてもよい）
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

実行環境：Ubuntu 18.04.2 LTS、Unity 2019.1.0f2 Personal、Oculus Quest
作成者：夢寐郎  
作成日：2019年06月07日  
更新日：2019年07月19日 KeyStore作成関連事項を追記


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


<a name="PCと接続できない場合"></a>
# <b>PCと接続できない場合</b>

### Oculus Quest の USB デバイス ID を調べる

1. 端末（ターミナル）で次の処理を行う  
    ```
    $ adb devices
    List of devices attached
    XXXXXXXXXXXXXX	no permissions .... ←認識に失敗している
    ```
    ```
    $ lsusb
    Bus 002 Device 002: ID XXXX:XXXX XXXX
    ……
    Bus 003 Device 076: ID 2833:0186  ←"2833"がOculusQuestのID（USBの抜差しで判明）
    ……
    ```
    ```
    $ sudo gedit /etc/udev/rules.d/51-android.rules →テキストエディタ起動（2.へ続く）
    ```

1. テキストエディタで次の行を記述し保存
    ```
    SUBSYSTEM=="usb", ATTR{idVendor}=="2833", MODE="0666", GROUP="plugdev"
    ```

1. Oculus Quest を USB 接続して確認（認識しない場合 OS を再起動）  

実行環境：Ubuntu 18.04.3 Oculus Quest 9.0  
作成者：夢寐郎  
作成日：2019年10月06日  


<a name="OculusTouchのイロハ"></a>
# <b>Oculus Touchのイロハ</b>

### Oculus Utilities for Unity のインポート

1. [ここ](https://developer.oculus.com/downloads/package/oculus-utilities-for-unity-5/) から "Oculus Utilities for Unity" をダウンロードし展開
1. Unity を起動
1. [Assets]-[ImportPackage]-[CustomPackge] から上記でダウンロードした [OclulusUtilities] 内の "**OculusUtilities.unitypackage**" を選択し [開く]-[Import]
1. Asset Store から "Oculus Integration" をインポート  
    または [Oculus](https://developer.oculus.com/downloads/package/unity-integration/) サイトから [Download the Oculus Integration] を選択

### カメラの変更

1. [Hierarchy]-[MainCamera] を削除
1. [Project]-[Assets]-[Oculus]-[VR]-[Prefabs]-[OVRCameraRig] を [Hierarchy] にドラッグ
1. [Inspector]-[Transform] の値を次の通りに変更  
    * X：0
    * Y：2.5
    * Z：-6

### オブジェクトの配置

1. [GameObject]-[CreateEmpty] を選択し、名前を "Main" に変更
1. [Assets]-[Create]-[C#Script] を選択し、名前を "Main" に変更（"Main.cs"の生成）
1. 上記の空の GameObject（Main）に C#（Main.cs）をアタッチ
1. 3D空間上に Oculus Touch の代わりに表示する左右のオブジェクトを生成
    1. [GameObject]-[3DObject]-[Cylinder] を選択し、名前を "OculusTouchR" とする
    1. [Inspector]-[Scale] の値を次の通りに変更  
        * X：0.05
        * Y：0.05
        * Z：0.05
    1. 同様に "OculusTouchL" も作成
    1. 位置は以下の床に隠れないように配置（任意）
1. [GameObject]-[3DObject]-[Plane]（床）を作成（設定は次の通り）
    * X：0
    * Y：0.1
    * Z：0

### スクリプティング＆実行

1. [Project]-[Assets]-[Main]（C#）の内容を変更する
    ```
    //Main.cs
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Main : MonoBehaviour {
        private GameObject _oculusTouchR;
        private GameObject _oculusTouchL;
        private GameObject _leftHandAnchor;
        private GameObject _rightHandAnchor;

        void Start() {
            _oculusTouchR = GameObject.Find("OculusTouchR");
            _oculusTouchL = GameObject.Find("OculusTouchL");
            GameObject _ovrCameraRig = GameObject.Find("OVRCameraRig");
            GameObject _trackingSpace = _ovrCameraRig.transform.Find("TrackingSpace").gameObject;
            _leftHandAnchor = _trackingSpace.transform.Find("LeftHandAnchor").gameObject;
            _rightHandAnchor = _trackingSpace.transform.Find("RightHandAnchor").gameObject;
        }

        void Update() {
            //position
            Vector3 _oculusTouchPosL = _leftHandAnchor.transform.position;
            Vector3 _oculusTouchPosR = _rightHandAnchor.transform.position;
            _oculusTouchL.transform.position = _oculusTouchPosL;
            _oculusTouchR.transform.position = _oculusTouchPosR;

            //rotation
            Quaternion _oculusTouchRotationL = _leftHandAnchor.transform.rotation;
            Quaternion _oculusTouchRotationR = _rightHandAnchor.transform.rotation;
            _oculusTouchL.transform.rotation = _oculusTouchRotationL;
            _oculusTouchR.transform.rotation = _oculusTouchRotationR;
        }
    }
    ```

1. [ビルド](#ビルドの基本) して実行

実行環境：Ubuntu 18.04.2 LTS、Unity 2019.1.0f2 Personal、Oculus Quest  
作成者：夢寐郎  
作成日：2019年07月22日  

© 2019 夢寐郎