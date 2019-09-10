# OTouch リファレンスマニュアル
Version Alpha1（2019年09月06日リリース） 対応  
© 2019 夢寐郎

# 入門
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
			_otouch.L = GameObject.Find("OculusTouchL");
			_otouch.R = GameObject.Find("OculusTouchR");
		}
	}
	```
	参照  
	[GetComponent](https://docs.unity3d.com/ja/current/ScriptReference/GameObject.GetComponent.html)、[AddComponent](https://docs.unity3d.com/ja/current/ScriptReference/GameObject.AddComponent.html)、[GameObject.Find()](https://docs.unity3d.com/ja/current/ScriptReference/GameObject.Find.html)


# メソッド一覧
* [AddTargetObjects()](#AddTargetObjects) : 
* [RemoveTargetObjects()](#RemoveTargetObjects) : 


# プロパティ
* [IsLHandTriggerDown](#IsLHandTriggerDown) : 
* [IsLIndexTriggerDown](#IsLIndexTriggerDown) : 
* [IsRHandTriggerDown](#IsRHandTriggerDown) : 
* [IsRIndexTriggerDown](#IsRIndexTriggerDown) : 
* [L](#L) : 
* [LHandTrigger](#LHandTrigger) : 
* [LIndexTrigger](#LIndexTrigger) : 
* [LThumbstickRotate](#LThumbstickRotate) : 
* [R](#R) : 
* [RHandTrigger](#RHandTrigger) : 
* [RIndexTrigger](#RIndexTrigger) : 
* [RThumbstickRotate](#RThumbstickRotate) : 
* [TargetObjects](#TargetObjects) : 


# イベント
* [ADown](#) : 
* [ARawTouch](#) : 
* [AUp](#) : 
* [BDown](#) : 
* [BRawTouch](#) : 
* [BUp](#) : 
* [LHandTriggerDown](#) : 
* [LHandTriggerUp](#) : 
* [LIndexTriggerDown](#) : 
* [LIndexTriggerRawNearTouch](#) : 
* [LIndexTriggerRawTouch](#) : 
* [LIndexTriggerUp](#) : 
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
* [RHandTriggerDown](#) : 
* [RHandTriggerUp](#) : 
* [RIndexTriggerDown](#) : 
* [RIndexTriggerRawNearTouch](#) : 
* [RIndexTriggerRawTouch](#) : 
* [RIndexTriggerUp](#) : 
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

<a name="L"></a>

# OculusTouch.L

### ◆構文
<em>oculusTouch</em>.L

### ◆説明
プロパティ。
Oculus Touch コントローラー（左手側）の動きに連動する GameObject を指定したり、調べることができます。

### ◆例文
```
OTouch _otouch = GetComponent<OTouch>();
_otouch.L = GameObject.Find("OculusTouchL");
_otouch.R = GameObject.Find("OculusTouchR");
```

### ◆参照
[OculusTouch.R](#R)


<a name="R"></a>

# OculusTouch.R

### ◆構文
<em>oculusTouch</em>.R

### ◆説明
プロパティ。
Oculus Touch コントローラー（右手側）の動きに連動する GameObject を指定したり、調べることができます。

### ◆例文
```
OTouch _otouch = GetComponent<OTouch>();
_otouch.L = GameObject.Find("OculusTouchL");
_otouch.R = GameObject.Find("OculusTouchR");
```

### ◆参照
[OculusTouch.L](#L)


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