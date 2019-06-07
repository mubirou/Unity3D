# Oculus Quest 対応

### <b>INDEX</b>

* [MACアドレスの取得](#MACアドレスの取得)
* [XXX](#)
***


<a name="MACアドレスの取得"></a>
# <b>MACアドレスの取得</b>

### MACアドレスの取得

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
    XXXXXXXXXXXXXX device ←ケーブルを抜差してこれが Quest であることを突き止める

    $ adb -s XXXXXXXXXXXXXX shell ip addr show wlan0
    ……
    link/ether XX:XX:XX:XX:XX:XX brd ff:ff:ff:ff:ff:ff
    ↑XX:XX:XX:XX:XX:XX が Quest の MAC アドレス
    ```

実行環境：Ubuntu 18.0.4 LTS、Oculus Quest  
作成者：夢寐郎  
作成日：2019年06月07日  

© 2019 夢寐郎