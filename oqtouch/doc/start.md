# OQtouch スタート
Version Alpha 3.201910031905 対応  
© 2019 夢寐郎

## ◆ OQtouch の準備
1. [開発環境](https://github.com/mubirou/Unity3D/tree/master/oqtouch)を準備する  
	* [Unity Hub for Linux](https://forum.unity.com/threads/unity-hub-v2-0-0-release.677485/) を利用する場合、ダウンロード後…
	```
	$ chmod 755 UnityHub.AppImage
	```
	でパーミッション変更をすることで起動できるようになります
1. GameManager オブジェクトの作成  
	1. [GameObject]-[Create Empty] を選択（空の GameObject の作成）
	1. 名前を "GameObject"→"GameManager" に変更  

1. GameManager クラスの作成
	1. [Assets]-[Create]-[C# Script] を選択（ C# スクリプトを作成）
	1. 名前を "NewBehaviourScript"→"GameManager" に変更

1. GameManager クラスのアタッチ
	1. [Hierarchy]-[GameManager]（GameObject）-[Inspector] を開く
	1. [Project]-[Assets]-[GameManager]（C# スクリプト）を上記の [Inspector] エリアにドラッグ＆ドロップ  

1. OQtouch クラスのアタッチ
	1. [OQtouch.cs](https://raw.githubusercontent.com/mubirou/Unity3D/master/oqtouch/OQtouch.cs) ファイルをプロジェクト内の Assets フォルダ内に保存
	1. [Project]-[Assets]-[OQtouch]（C# スクリプト）を上記の [Inspector] エリアにドラッグ＆ドロップ  

1. OQtouch を使ったミニマルな GameManager（C# スクリプト）
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
	1. [MAterials]-[Element 0]-[⦿] から上記で作成した "ColorLine" を選択
	1. 右手側も同様に行う