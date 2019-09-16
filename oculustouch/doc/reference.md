# OTouch リファレンスマニュアル
Version Alpha1（2019年09月13日リリース） 対応  
© 2019 夢寐郎

***

## ◇OTouch の準備（必須）
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

***

## ◇コンソールの準備（推奨）
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

***

## ◆ OTouch クラスのメソッド一覧
* [AddTargetObjects()](#AddTargetObjects) : 
* [RemoveTargetObjects()](#RemoveTargetObjects) : 


## ◆ OTouch クラスのプロパティ一覧
* [IsLHandTriggerDown](#IsLHandTriggerDown) : 
* [IsLIndexTriggerDown](#IsLIndexTriggerDown) : 「左人差し指トリガーを押している」か否かを調べる
* [IsRHandTriggerDown](#IsRHandTriggerDown) : 
* [IsRIndexTriggerDown](#IsRIndexTriggerDown) : 
* [L](#L) : 左手側の Oculus Touch コントローラーの動きに連動する GameObject を指定
* [LHandTrigger](#LHandTrigger) : 
* [LIndexTrigger](#LIndexTrigger) : 
* [LThumbstickRotate](#LThumbstickRotate) : 
* [R](#R) : 右手側の Oculus Touch コントローラーの動きに連動する GameObject を指定
* [LHandTrigger](#LHandTrigger) : 
* [RHandTrigger](#RHandTrigger) : 
* [RIndexTrigger](#RIndexTrigger) : 
* [RThumbstickRotate](#RThumbstickRotate) : 
* [TargetObjects](#TargetObjects) : 


## ◆ OTouch クラスのイベント一覧
* [ADown](#) : 
* [ARawTouch](#) : 
* [AUp](#) : 
* [BDown](#) : 
* [BRawTouch](#) : 
* [BUp](#) : 
* [LHandTriggerDown](#LHandTriggerDown) : 「左中指トリガーを押した時」のイベントハンドラの登録や削除
* [LHandTriggerUp](#LHandTriggerUp) : 「左中指トリガーを押した後、離した時」のイベントハンドラの登録や削除
* [LIndexTriggerDown](#LIndexTriggerDown) : 「左人差し指トリガーを押した時」のイベントハンドラの登録や削除
* [LIndexTriggerRawNearTouch](#) : 
* [LIndexTriggerRawTouch](#) : 
* [LIndexTriggerUp](#LIndexTriggerUp) : 「左人差し指トリガーを押した後、離した時」のイベントハンドラの登録や削除
* [LLaserDown](#) : 
* [LLaserOut](#) : 
* [LLaserOver](#) : 
* [LLaserUp](#) : 
* [LLsserUpOutside](#) : 
* [LThumbstickDown](#) : 
* [LThumbstickDownDown](#) : 
* [LThumbstickDownUp](#) : 
* [LThumbstickLeftDown](#) : 
* [LThumbstickLeftUp](#) : 
* [LThumbstickRawTouch](#) : 
* [LThumbstickRightDown](#) : 
* [LThumbstickRightUp](#) : 
* [LThumbstickUp](#) : 
* [LThumbstickUpUp](#) : 
* [LThumbstickUpDown](#) : 
* [RHandTriggerDown](#RHandTriggerDown) : 「右中指トリガーを押した時」のイベントハンドラの登録や削除
* [RHandTriggerUp](#RHandTriggerUp) : 「右中指トリガーを押した後、離した時」のイベントハンドラの登録や削除
* [RIndexTriggerDown](#RIndexTriggerDown) : 「右人差し指トリガーを押した時」のイベントハンドラの登録や削除
* [RIndexTriggerRawNearTouch](#) : 
* [RIndexTriggerRawTouch](#) : 
* [RIndexTriggerUp](#RIndexTriggerUp) : 「右人差し指トリガーを押した後、離した時」のイベントハンドラの登録や削除
* [RLaserDown](#) : 
* [RLaserOut](#) : 
* [RLaserOver](#) : 
* [RLaserUp](#) : 
* [RLsserUpOutside](#) : 
* [RThumbstickDown](#) : 
* [RThumbstickDownDown](#) : 
* [RThumbstickDownUp](#) : 
* [RThumbstickLeftDown](#) : 
* [RThumbstickLeftUp](#) : 
* [RThumbstickRawTouch](#) : 
* [RThumbstickRightDown](#) : 
* [RThumbstickRightUp](#) : 
* [RThumbstickUp](#) : 
* [RThumbstickUpUp](#) : 
* [RThumbstickUpDown](#) : 
* [StartDown](#) : 
* [StartUp](#) : 
* [XDown](#) : 
* [XRawTouch](#) : 
* [XUp](#) : 
* [YDown](#) : 
* [YRawTouch](#) : 
* [YUp](#) : 

***

<a name="IsLIndexTriggerDown"></a>

# OTouch.IsLIndexTriggerDown

### ◆構文
<em>otouch</em>.IsLIndexTriggerDown

### ◆説明
プロパティ。
「左人差し指トリガーを押している」か否かを示すブール値（読み取り専用）。

### ◆例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private OTouch _otouch;
    private Console _console; //DEBUG用

    void Start() {
        _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    void Update() {
        if (_otouch.IsLIndexTriggerDown) {
            _console.Log("左人差し指トリガー↓"); //DEBUG用
        }
    }
}
```

### ◆参照
[OTouch.IsRIndexTriggerDown](#IsRIndexTriggerDown)  
[OTouch.LIndexTriggerDown](#LIndexTriggerDown)  

***

<a name="L"></a>

# OTouch.L

### ◆構文
<em>otouch</em>.L

### ◆説明
プロパティ。
Oculus Touch コントローラー（左手側）の動きに連動する GameObject を指定したり、調べることができます。

### ◆例文
```
OTouch _otouch = GetComponent<OTouch>();
_otouch.L = GameObject.Find("OculusTouchL");
```

### ◆参照
[OTouch.R](#R)

***

<a name="LHandTriggerDown"></a>

# OTouch.LHandTriggerDown

### ◆構文
<em>otouch</em>.LHandTriggerDown += <em>SomeMethodHandler</em>  
<em>otouch</em>.LHandTriggerDown -= <em>SomeMethodHandler</em>

### ◆説明
「左中指トリガーを押した時」のイベントハンドラの登録や削除を行うことができます。

### ◆例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.LHandTriggerDown += LHandTriggerDownHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void LHandTriggerDownHandler() { // イベントハンドラ
        //ここに「左中指トリガーを押した時」の処理を記述
        _console.Log("左中指トリガー↓"); //DEBUG用
    }
}
```

### ◆参照
[OTouch.RHandTriggerDown](#RHandTriggerDown)  
[OTouch.LHandTriggerUp](#LHandTriggerUp)  

***

<a name="LHandTriggerUp"></a>

# OTouch.LHandTriggerUp

### ◆構文
<em>otouch</em>.LHandTriggerUp += <em>SomeMethodHandler</em>  
<em>otouch</em>.LHandTriggerUp -= <em>SomeMethodHandler</em>

### ◆説明
「左中指トリガーを押した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◆例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.LHandTriggerUp += LHandTriggerUpHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void LHandTriggerUpHandler() { // イベントハンドラ
        //ここに「左中指トリガーを押した後、離した時」の処理を記述
        _console.Log("左中指トリガー↑"); //DEBUG用
    }
}
```

### ◆参照
[OTouch.RHandTriggerUp](#RHandTriggerUp)  
[OTouch.LHandTriggerDown](#LHandTriggerDown)  

***

<a name="LIndexTriggerDown"></a>

# OTouch.LIndexTriggerDown

### ◆構文
<em>otouch</em>.LIndexTriggerDown += <em>SomeMethodHandler</em>  
<em>otouch</em>.LIndexTriggerDown -= <em>SomeMethodHandler</em>

### ◆説明
「左人差し指トリガーを押した時」のイベントハンドラの登録や削除を行うことができます。

### ◆例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.LIndexTriggerDown += LIndexTriggerDownHandler; //イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void LIndexTriggerDownHandler() { //イベントハンドラ
        //ここに「左人差し指トリガーを押した時」の処理を記述
        _console.Log("左人差し指トリガー↓"); //DEBUG用
    }
}
```

### ◆参照
[OTouch.RIndexTriggerDown](#RIndexTriggerDown)  
[OTouch.LIndexTriggerUp](#LIndexTriggerUp)  

***

<a name="LIndexTriggerUp"></a>

# OTouch.LIndexTriggerUp

### ◆構文
<em>otouch</em>.LIndexTriggerUp += <em>SomeMethodHandler</em>  
<em>otouch</em>.LIndexTriggerUp -= <em>SomeMethodHandler</em>

### ◆説明
「左人差し指トリガーを押した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◆例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.LIndexTriggerUp += LIndexTriggerUpHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void LIndexTriggerUpHandler() { // イベントハンドラ
        //ここに「左人差し指トリガーを押した後、離した時」の処理を記述
        _console.Log("右人差し指トリガー↑"); //DEBUG用
    }
}
```

### ◆参照
[OTouch.RIndexTriggerUp](#RIndexTriggerUp)  
[OTouch.LIndexTriggerDown](#LIndexTriggerDown)  

***

<a name="R"></a>

# OTouch.R

### ◆構文
<em>otouch</em>.R

### ◆説明
プロパティ。
Oculus Touch コントローラー（右手側）の動きに連動する GameObject を指定したり、調べることができます。

### ◆例文
```
OTouch _otouch = GetComponent<OTouch>();
_otouch.R = GameObject.Find("OculusTouchR");
```

### ◆参照
[OTouch.L](#L)

***

<a name="RHandTriggerDown"></a>

# OTouch.RHandTriggerDown

### ◆構文
<em>otouch</em>.RHandTriggerDown += <em>SomeMethodHandler</em>  
<em>otouch</em>.RHandTriggerDown -= <em>SomeMethodHandler</em>

### ◆説明
「右中指トリガーを押した時」のイベントハンドラの登録や削除を行うことができます。

### ◆例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.R = GameObject.Find("OculusTouchR");
        _otouch.RHandTriggerDown += RHandTriggerDownHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void RHandTriggerDownHandler() { // イベントハンドラ
        //ここに「右中指トリガーを押した時」の処理を記述
        _console.Log("右中指トリガー↓"); //DEBUG用
    }
}
```

### ◆参照
[OTouch.LHandTriggerDown](#LHandTriggerDown)  
[OTouch.RHandTriggerUp](#RHandTriggerUp)  

***

<a name="RHandTriggerUp"></a>

# OTouch.RHandTriggerUp

### ◆構文
<em>otouch</em>.RHandTriggerUp += <em>SomeMethodHandler</em>  
<em>otouch</em>.RHandTriggerUp -= <em>SomeMethodHandler</em>

### ◆説明
「右中指トリガーを押した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◆例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.R = GameObject.Find("OculusTouchR");
        _otouch.RHandTriggerUp += RHandTriggerUpHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void RHandTriggerUpHandler() { // イベントハンドラ
        //ここに「右中指トリガーを押した後、離した時」の処理を記述
        _console.Log("右中指トリガー↑"); //DEBUG用
    }
}
```

### ◆参照
[OTouch.LHandTriggerUp](#LHandTriggerUp)  
[OTouch.RHandTriggerDown](#RHandTriggerDown)  

***

<a name="RIndexTriggerDown"></a>

# OTouch.RIndexTriggerDown

### ◆構文
<em>otouch</em>.RIndexTriggerDown += <em>SomeMethodHandler</em>  
<em>otouch</em>.RIndexTriggerDown -= <em>SomeMethodHandler</em>

### ◆説明
「右人差し指トリガーを押した時」のイベントハンドラの登録や削除を行うことができます。

### ◆例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.R = GameObject.Find("OculusTouchR");
        _otouch.RIndexTriggerDown += RIndexTriggerDownHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void RIndexTriggerDownHandler() { // イベントハンドラ
        //ここに「右人差し指トリガーを押した時」の処理を記述
        _console.Log("右人差し指トリガー↓"); //DEBUG用
    }
}
```

### ◆参照
[OTouch.LIndexTriggerDown](#LIndexTriggerDown)  
[OTouch.RIndexTriggerUp](#RIndexTriggerUp)  

***

<a name="RIndexTriggerUp"></a>

# OTouch.RIndexTriggerUp

### ◆構文
<em>otouch</em>.RIndexTriggerUp += <em>SomeMethodHandler</em>  
<em>otouch</em>.RIndexTriggerUp -= <em>SomeMethodHandler</em>

### ◆説明
「右人差し指トリガーを押した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◆例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OTouch _otouch = GetComponent<OTouch>();
        _otouch.L = GameObject.Find("OculusTouchL");
        _otouch.R = GameObject.Find("OculusTouchR");
        _otouch.RIndexTriggerUp += RIndexTriggerUpHandler; // イベントハンドラの登録
        _console = _otouch.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void RIndexTriggerUpHandler() { // イベントハンドラ
        //ここに「右人差し指トリガーを押した後、離した時」の処理を記述
        _console.Log("右人差し指トリガー↑"); //DEBUG用
    }
}
```

### ◆参照
[OTouch.LIndexTriggerUp](#LIndexTriggerUp)  
[OTouch.RIndexTriggerDown](#RIndexTriggerDown)  

***

<a name="XXXX"></a>

# XXXX

### ◆構文
XXXX

### ◆引数
XXXX  

### ◆説明
XXXX

### ◆例文
```
//GameManager.cs
```

### ◆参照
XXXX