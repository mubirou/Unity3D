# OQtouch スタート（検証中）
Version Alpha 3.201910031905 対応  
© 2019 夢寐郎

## ◆ OQtouch の準備
1. [開発環境](https://github.com/mubirou/Unity3D/tree/master/oqtouch)を準備する  
	* [Unity Hub for Linux](https://forum.unity.com/threads/unity-hub-v2-0-0-release.677485/) を利用する場合、ダウンロード後に端末（ターミナル）で次の処理を行い、パーミッションを変更する必要があります
		```
		$ chmod 755 UnityHub.AppImage
		```
	* Unity Hub for Linux を使って Unity をインストールした後は、UnityHub.AppImage をゴミ箱に入れて OS を再起動、端末（ターミナル）で次の処理を行い、Unity を起動します
		```
		$ Unity/Editor/2020.1.0a7/Editor/Unity
		```
	* [Oculus Integration](https://assetstore.unity.com/packages/tools/integration/oculus-integration-82022) を Unity の [Window]-[Asset Store] からインストール（Oculus / **VR** のみ）

***

1. カメラの変更  
	1. [Hierarchy]-[MainCamera] を削除
	1. [Project]-[Assets]-[Oculus]-[VR]-[Prefabs]-[OVRCameraRig] を [Hierarchy] にドラッグ
	1. [OVRCameraRig] の [Inspector]-[Transform]-[Position] の値を次の通りに変更  
		* X：0
		* Y：2.5
		* Z：-6
	
1. GameManager オブジェクト（空の GameObject）の作成  
	1. [GameObject]-[Create Empty] を選択
	1. 名前を "GameObject"→"GameManager" に変更  

1. GameManager クラス（C# スクリプト）の作成
	1. [Project]-[Assets] フォルダを選択した状態で [Assets]-[Create]-[C# Script] を選択
	1. 名前を "NewBehaviourScript"→"GameManager" に変更

1. GameManager クラスのアタッチ
	1. [Hierarchy]-[GameManager]（GameObject）-[Inspector] を開く
	1. [Project]-[Assets]-[GameManager]（C# スクリプト）を上記の [Inspector] エリアにドラッグ＆ドロップ  

1. OQtouch クラスのアタッチ
	1. [OQtouch.cs](https://raw.githubusercontent.com/mubirou/Unity3D/master/oqtouch/OQtouch.cs) ファイルをプロジェクト内の Assets フォルダ内に保存
	1. [Project]-[Assets]-[OQtouch]（C# スクリプト）を上記の GameManager オブジェクト（空の GameObject）の [Inspector] エリアにドラッグ＆ドロップ  

1. 左右の Oculus Touch コントローラーの動きに連動する GameObject を作成し名前を、"OculusTouchL" および "OculusTouchR" とする

1. GameManager（C#）を変更  
	（易化のサンプルは OQtouch を使ったミニマル版）
	```
	//GameManager.cs
	using UnityEngine;

	public class GameManager : MonoBehaviour {
		void Start() {
			OQtouch _oqt = GetComponent<OQtouch>();
			_oqt.R = GameObject.Find("OculusTouchR");
		}
	}
	```
	参照  
	[GetComponent](https://docs.unity3d.com/ja/current/ScriptReference/GameObject.GetComponent.html)  
	[AddComponent](https://docs.unity3d.com/ja/current/ScriptReference/GameObject.AddComponent.html)  
	[GameObject.Find()](https://docs.unity3d.com/ja/current/ScriptReference/GameObject.Find.html)


## ◆ コンソールの準備（任意）
* 概要
    * Unity Editor の Console 的なものを VR 上に表示させます（デバッグ用）
    * Unity Editor の Console に出力する "Debug.Log()" の代わりに "Console.Log()" コマンドを使います
1. パッケージ（[Console.unitypackage](https://github.com/mubirou/Unity3D/blob/master/oqtouch/Console.unitypackage)）を [Download]
1. Unity Editor の [Assets]-[Import]-[Custom Package] から上記の Console.unitypackage を選択
1. [Project]-[Assets]-[Console（Prefab Asset）] を左手側の Oculus Touch コントローラー（左手側）の動きに連動する GameObject の入れ子にして、位置を微調整する
1. Console（Prefab Asset）を入れ子にした GameObject を Prefab 化
1. サンプルコード
    ```
    //GameManager.cs
    using UnityEngine;

    public class GameManager : MonoBehaviour {
        private Console _console;

        void Start() {
            OQtouch _oqt = GetComponent<OQtouch>();
            _oqt.L = GameObject.Find("OculusTouchL");
            _oqt.LIndexTriggerDown += LIndexTriggerDownHandler;

            //入れ子状態のConsoleをさがす
            _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>();
			//_console.Log("Start()内では使えない"); //要注意
		}

        private void LIndexTriggerDownHandler() {
            _console.Log("右人差し指トリガー↓");
        }
    }
    ```
    * 上記のサンプルコードのほかに、①コンソールに表示されている文字を消す **Console.Rest()** メソッドと、②コンソールの表示･非表示を調べる（設定可能） **Console.Enabled** プロパティがあります


<a name="LaserPointer"></a>

## ◆ レーザーポインタの準備（任意）
* [OQtouch.EnabledLaserL](https://github.com/mubirou/Unity3D/blob/master/oqtouch/doc/reference.md#EnabledLaserL)、[OQtouch.EnabledLaserR](https://github.com/mubirou/Unity3D/blob/master/oqtouch/doc/reference.md#EnabledLaserR) を使用する前に必要になります

1. マテリアルの作成
	1. [Window]-[General]-[Project]-[+]-[Material] を選択
	1. 名前を "New Material"→"ColorLine" 等に変更
	1. [Inspector]-[Shader] を [Oculus]-[Texture2D Blit] に変更
1. ラインレダラーの追加
	1. 左手側の Oculus Touch コントローラーの動きに連動する GameObject を選択し [Inspector] を開く
	1. [Add Component] ボタンを押して "**Line Rendere**" を検索し追加する
	1. [Materials]-[Element 0]-[⦿] から上記で作成した "ColorLine" を選択
	1. 右手側も同様に行う