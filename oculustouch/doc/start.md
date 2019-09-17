# OTouch スタート
Version Alpha 1.201909170944 対応  
© 2019 夢寐郎

## ◆OTouch の準備（必須）
1. [開発環境](https://github.com/mubirou/Unity3D/tree/master/oculustouch)を準備する
1. GameManager オブジェクトの作成  
	1. [GameObject]-[Create Empty] を選択（空の GameObject の作成）
	1. 名前を "GameObject"→"GameManager" に変更  

1. GameManager クラスの作成
	1. [Assets]-[Create]-[C# Script] を選択（ C# スクリプトを作成）
	1. 名前を "NewBehaviourScript"→"GameManager" に変更

1. GameManager クラスのアタッチ
	1. [Hierarchy]-[GameManager]（GameObject）-[Inspector] を開く
	1. [Project]-[Assets]-[GameManager]（C# スクリプト）を上記の [Inspector] エリアにドラッグ＆ドロップ  

1. OTouch クラスのアタッチ
	1. [OTouch.cs](https://raw.githubusercontent.com/mubirou/Unity3D/master/oculustouch/OTouch.cs) ファイルをプロジェクト内の Assets フォルダ内に保存
	1. [Project]-[Assets]-[OTouch]（C# スクリプト）を上記の [Inspector] エリアにドラッグ＆ドロップ  

1. OTouch を使ったミニマルな GameManager（C# スクリプト）
	```
	//GameManager.cs
	using UnityEngine;

	public class GameManager : MonoBehaviour {
		void Start() {
			OTouch _otouch = GetComponent<OTouch>();
			_otouch.R = GameObject.Find("OculusTouchR");
		}
	}
	```
	参照  
	[GetComponent](https://docs.unity3d.com/ja/current/ScriptReference/GameObject.GetComponent.html)  
	[AddComponent](https://docs.unity3d.com/ja/current/ScriptReference/GameObject.AddComponent.html)  
	[GameObject.Find()](https://docs.unity3d.com/ja/current/ScriptReference/GameObject.Find.html)


## ◆コンソールの準備（推奨）
* 概要
    * Unity Editor の Console 的なものを VR 上に表示させます（デバッグ用）
    * Unity Editor の Console に出力する "Debug.Log()" の代わりに "Console.Log()" コマンドを使います
1. パッケージ（[Console.unitypackage](https://github.com/mubirou/Unity3D/blob/master/oculustouch/Console.unitypackage)）を [Download]
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
            OTouch _otouch = GetComponent<OTouch>();
            _otouch.L = GameObject.Find("OculusTouchL");
            _otouch.LIndexTriggerDown += LIndexTriggerDownHandler;

            //入れ子状態のConsoleをさがす
            _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>();
        }

        private void LIndexTriggerDownHandler() {
            _console.Log("右人差し指トリガー↓");
        }
    }
    ```
    * 上記のサンプルコードのほかに、①コンソールに表示されている文字を消す **Console.Rest()** メソッドと、②コンソールの表示･非表示を調べる（設定可能） **Console.Enabled** プロパティがあります