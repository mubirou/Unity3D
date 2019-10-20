# OQtouch リファレンスマニュアル
Version Alpha 4 対応  
© 2019 夢寐郎

## ◆ メソッド一覧
* [AddTargetObject()](#AddTargetObject) : レーザーポインタに反応させるオブジェクトの登録
* [RemoveTargetObject()](#RemoveTargetObject) : レーザーポインタに反応させるオブジェクトの削除


## ◆ プロパティ一覧
* [EnabledLaserL](#EnabledLaserL) : 左手側のレーザーポインタを表示するか否か
* [EnabledLaserR](#EnabledLaserR) : 右手側のレーザーポインタを表示するか否か
* [IsVibration](#IsVibration) : LLaserOver/RLaserOver時のバイブレーションの有効化
* [IsLHandTriggerDown](#IsLHandTriggerDown) : 左中指トリガーを押しているか否か
* [IsLIndexTriggerDown](#IsLIndexTriggerDown) : 左人差し指トリガーを押しているか否か
* [IsLThumbstickMove](#IsLThumbstickMove) : 左親指スティックを動かしているか否か
* [IsRHandTriggerDown](#IsRHandTriggerDown) : 右中指トリガーを押しているか否か
* [IsRIndexTriggerDown](#IsRIndexTriggerDown) : 右人差し指トリガーを押しているか否か
* [IsRThumbstickMove](#IsRThumbstickMove) : 左親指スティックを動かしているか否か
* [L](#L) : 左手側の Oculus Touch コントローラーの動きに連動する GameObject を指定
* [LHandTrigger](#LHandTrigger) : 左中指トリガーを押しているトリガー量（0〜1まで小数点以下15桁表示）
* [LIndexTrigger](#LIndexTrigger) : 左人差し指トリガーを押しているトリガー量（0〜1まで小数点以下15桁表示）
* [LThumbstickRotate](#LThumbstickRotate) : 左親指スティックの角度（度数法）
* [R](#R) : 右手側の Oculus Touch コントローラーの動きに連動する GameObject を指定
* [RHandTrigger](#RHandTrigger) : 右中指トリガーを押しているトリガー量（0〜1まで小数点以下15桁表示）
* [RIndexTrigger](#RIndexTrigger) : 右人差し指トリガーを押しているトリガー量（0〜1まで小数点以下15桁表示）
* [RThumbstickRotate](#RThumbstickRotate) : 右親指スティックの角度（度数法）
* [TargetObjects](#TargetObjects) : レーザーポインタに反応させるオブジェクトのリスト


## ◆ イベント一覧
* [ADown](#ADown) : Aボタンを押した時
* [ARawTouch](#ARawTouch) : Aボタンに触れた時
* [AUp](#AUp) : Aボタンを押した後、離した時
* [BDown](#BDown) : Bボタンを押した時
* [BRawTouch](#BRawTouch) : Bボタンに触れた時
* [BUp](#BUp) : Bボタンを押した後、離した時
* [LHandTriggerDown](#LHandTriggerDown) : 左中指トリガーを押した時
* [LHandTriggerUp](#LHandTriggerUp) : 左中指トリガーを押した後、離した時
* [LIndexTriggerDown](#LIndexTriggerDown) : 左人差し指トリガーを押した時
* [LIndexTriggerRawNearTouch](#LIndexTriggerRawNearTouch) : 左人差し指トリガーに近接した時
* [LIndexTriggerRawTouch](#LIndexTriggerRawTouch) : 左人差し指トリガーにタッチした時
* [LIndexTriggerUp](#LIndexTriggerUp) : 左人差し指トリガーを押した後、離した時
* [LLaserDown](#LLaserDown) : 左手側のレーザーポインタでオブジェクトを押した時
* [LLaserOut](#LLaserOut) : 左手側のレーザーポインタがアウトした時
* [LLaserOver](#LLaserOver) : 左手側のレーザーポインタでヒットした時
* [LLaserUp](#LLaserUp) : 左手側のレーザーポインタを選択オブジェクト上で離した時
* [LLaserUpOutside](#LLaserUpOutside) : 左手側のレーザーポインタを選択オブジェクト外で離した時
* [LThumbstickDown](#LThumbstickDown) : 左親指スティックを押した時
* [LThumbstickDownDown](#LThumbstickDownDown) : 左親指スティックを下に倒した時
* [LThumbstickDownUp](#LThumbstickDownUp) : 左親指スティックを下に倒した後、離した時
* [LThumbstickLeftDown](#LThumbstickLeftDown) : 左親指スティックを左に倒した時
* [LThumbstickLeftUp](#LThumbstickLeftUp) : 左親指スティックを左に倒した後、離した時
* [LThumbstickRawTouch](#LThumbstickRawTouch) : 左親指スティックにタッチした時
* [LThumbstickRightDown](#LThumbstickRightDown) : 左親指スティックを右に倒した時
* [LThumbstickRightUp](#LThumbstickRightUp) : 左親指スティックを右に倒した後、離した時
* [LThumbstickUp](#LThumbstickUp) : 左親指スティックを押した後、離した時
* [LThumbstickUpDown](#LThumbstickUpDown) : 左親指スティックを上に倒した時
* [LThumbstickUpUp](#LThumbstickUpUp) : 左親指スティックを上に倒した後、離した時
* [RHandTriggerDown](#RHandTriggerDown) : 右中指トリガーを押した時
* [RHandTriggerUp](#RHandTriggerUp) : 右中指トリガーを押した後、離した時
* [RIndexTriggerDown](#RIndexTriggerDown) : 右人差し指トリガーを押した時
* [RIndexTriggerRawNearTouch](#RIndexTriggerRawNearTouch) : 右人差し指トリガーに近接した時
* [RIndexTriggerRawTouch](#RIndexTriggerRawTouch) : 右人差し指トリガーにタッチした時
* [RIndexTriggerUp](#RIndexTriggerUp) : 右人差し指トリガーを押した後、離した時
* [RLaserDown](#RLaserDown) : 右手側のレーザーポインタでオブジェクトを押した時
* [RLaserOut](#RLaserOut) : 右手側のレーザーポインタがアウトした時
* [RLaserOver](#RLaserOver) : 右手側のレーザーポインタでヒットした時
* [RLaserUp](#RLaserUp) : 右手側のレーザーポインタを選択オブジェクト上で離した時
* [RLaserUpOutside](#RLaserUpOutside) : 右手側のレーザーポインタを選択オブジェクト外で離した時
* [RThumbstickDown](#RThumbstickDown) : 右親指スティックを押した時
* [RThumbstickDownDown](#RThumbstickDownDown) : 右親指スティックを下に倒した時
* [RThumbstickDownUp](#RThumbstickDownUp) : 右親指スティックを下に倒した後、離した時
* [RThumbstickLeftDown](#RThumbstickLeftDown) : 右親指スティックを左に倒した時
* [RThumbstickLeftUp](#RThumbstickLeftUp) : 右親指スティックを左に倒した後、離した時
* [RThumbstickRawTouch](#RThumbstickRawTouch) : 右親指スティックにタッチした時
* [RThumbstickRightDown](#RThumbstickRightDown) : 右親指スティックを右に倒した時
* [RThumbstickRightUp](#RThumbstickRightUp) : 右親指スティックを右に倒した後、離した時
* [RThumbstickUp](#RThumbstickUp) : 右親指スティックを押した後、離した時
* [RThumbstickUpDown](#RThumbstickUpDown) : 右親指スティックを上に倒した時
* [RThumbstickUpUp](#RThumbstickUpUp) : 右親指スティックを上に倒した後、離した時
* [StartDown](#StartDown) : スタートボタン（Xボタンの下）を押した時
* [StartUp](#StartUp) : スタートボタン（Xボタンの下）を押した後、離した時
* [XDown](#XDown) : Xボタンを押した時
* [XRawTouch](#XRawTouch) : Xボタンに触れた時
* [XUp](#XUp) : Xボタンを押した後、離した時
* [YDown](#YDown) : Yボタンを押した時
* [YRawTouch](#YRawTouch) : Yボタンに触れた時
* [YUp](#YUp) : Yボタンを押した後、離した時

***

<a name="AddTargetObject"></a>

# OQtouch.AddTargetObject()

### ◇ 構文
<em>oqtouch</em>.AddTargetObject(<em>someGameObject</em>)

### ◇ 説明
メソッド。  
左、もしくは右手側のレーザーポインタに反応させるオブジェクトの登録をします。  
追加されたオブジェクトに [OQtouch.LLaserOver](#LLaserOver) または [OQtouch.RLaserOver](#RLaserOver) のイベントが発生すると、バイブレーションが実行されます（初期値）。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.EnabledLaserL = true;

        //レーザーポインタで選択するオブジェクトの登録
        _oqt.AddTargetObject(GameObject.Find("Button1"));
        _oqt.AddTargetObject(GameObject.Find("Button2"));
        _oqt.AddTargetObject(GameObject.Find("Button3"));

        _oqt.LLaserDown += LLaserDownHandler;

        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>();
    }

    private void LLaserDownHandler(GameObject arg) {
        _console.Log("左レーザーが" + arg.name + "を↓");
    }
}
```

### ◇ 参照
[OQtouch.RemoveTargetObject()](#RemoveTargetObject)  
[OQtouch.TargetObjects](#TargetObjects)  
[OQtouch.LLaserDown](#LLaserDown)  
[OQtouch.RLaserDown](#RLaserDown)  
[OQtouch.LLaserOver](#LLaserOver)  
[OQtouch.RLaserOver](#RLaserOver)  
[OQtouch.IsVibration](#IsVibration)  

***

<a name="ADown"></a>

# OQtouch.ADown

### ◇ 構文
<em>oqtouch</em>.ADown += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.ADown -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「Aボタンを押した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _oqt.ADown += ADownHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void ADownHandler() { // イベントハンドラ
        //ここに「Aボタンを押した時」の処理を記述
        _console.Log("Aボタン↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.AUp](#AUp)  
[OQtouch.ARawTouch](#ARawTouch)  

***

<a name="ARawTouch"></a>

# OQtouch.ARawTouch

### ◇ 構文
<em>oqtouch</em>.ARawTouch += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.ARawTouch -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「Aボタンに触れた時」（触れている間ではなく、最初に触れた瞬間）のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _oqt.ARawTouch += ARawTouchHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void ARawTouchHandler() { // イベントハンドラ
        //ここに「Aボタンに触れた時」の処理を記述
        _console.Log("Aボタンにタッチ"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.ADown](#ADown)  
[OQtouch.AUp](#AUp)  

***

<a name="AUp"></a>

# OQtouch.AUp

### ◇ 構文
<em>oqtouch</em>.AUp += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.AUp -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「Aボタンを押した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _oqt.AUp += AUpHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void AUpHandler() { // イベントハンドラ
        //ここに「Aボタンを押した後、離した時」の処理を記述
        _console.Log("Aボタン↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.ADown](#ADown)  
[OQtouch.ARawTouch](#ARawTouch)  

***

<a name="BDown"></a>

# OQtouch.BDown

### ◇ 構文
<em>oqtouch</em>.BDown += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.BDown -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「Bボタンを押した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _oqt.BDown += BDownHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void BDownHandler() { // イベントハンドラ
        //ここに「Bボタンを押した時」の処理を記述
        _console.Log("Bボタン↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.BUp](#BUp)  
[OQtouch.BRawTouch](#BRawTouch)  

***

<a name="BRawTouch"></a>

# OQtouch.BRawTouch

### ◇ 構文
<em>oqtouch</em>.BRawTouch += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.BRawTouch -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「Bボタンに触れた時」（触れている間ではなく、最初に触れた瞬間）のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _oqt.BRawTouch += BRawTouchHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void BRawTouchHandler() { // イベントハンドラ
        //ここに「Bボタンに触れた時」の処理を記述
        _console.Log("Bボタンにタッチ"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.BDown](#BDown)  
[OQtouch.BUp](#BUp)  

***

<a name="BUp"></a>

# OQtouch.BUp

### ◇ 構文
<em>oqtouch</em>.BUp += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.BUp -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「Bボタンを押した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _oqt.BUp += BUpHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void BUpHandler() { // イベントハンドラ
        //ここに「Bボタンを押した後、離した時」の処理を記述
        _console.Log("Bボタン↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.BDown](#BDown)  
[OQtouch.BRawTouch](#BRawTouch)  

***

<a name="EnabledLaserL"></a>

# OQtouch.EnabledLaserL

### ◇ 構文
<em>oqtouch</em>.EnabledLaserL

### ◇ 説明
プロパティ。  
左手側のレーザーポインタを表示するか否かを示すブール値。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.EnabledLaserL = true;
    }
}
```

### ◇ 参照
[レーザーポインタの準備](https://github.com/mubirou/Unity3D/blob/master/oqtouch/doc/start.md#LaserPointer)  
[OQtouch.EnabledLaserR](#EnabledLaserR)  

***

<a name="EnabledLaserR"></a>

# OQtouch.EnabledLaserR

### ◇ 構文
<em>oqtouch</em>.EnabledLaserR

### ◇ 説明
プロパティ。  
右手側のレーザーポインタを表示するか否かを示すブール値。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.R = GameObject.Find("OculusTouchR");
        _oqt.EnabledLaserR = true;
    }
}
```

### ◇ 参照
[レーザーポインタの準備](https://github.com/mubirou/Unity3D/blob/master/oqtouch/doc/start.md#LaserPointer)  
[OQtouch.EnabledLaserL](#EnabledLaserL)  

***

<a name="IsLHandTriggerDown"></a>

# OQtouch.IsLHandTriggerDown

### ◇ 構文
<em>oqtouch</em>.IsLHandTriggerDown

### ◇ 説明
プロパティ。  
「左中指トリガーを押している」か否かを示すブール値（読み取り専用）。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private OQtouch _oqt;
    private Console _console; //DEBUG用

    void Start() {
        _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    void Update() {
        if (_oqt.IsLHandTriggerDown ) {
            _console.Log("左中指トリガー↓"); //DEBUG用
        }
    }
}
```

### ◇ 参照
[OQtouch.IsRHandTriggerDown](#IsRHandTriggerDown)  
[OQtouch.LHandTriggerDown](#LHandTriggerDown)  
[OQtouch.LHandTrigger](#LHandTrigger)  

***

<a name="IsLIndexTriggerDown"></a>

# OQtouch.IsLIndexTriggerDown

### ◇ 構文
<em>oqtouch</em>.IsLIndexTriggerDown

### ◇ 説明
プロパティ。  
「左人差し指トリガーを押している」か否かを示すブール値（読み取り専用）。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private OQtouch _oqt;
    private Console _console; //DEBUG用

    void Start() {
        _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    void Update() {
        if (_oqt.IsLThumbstickMove) {
            _console.Log("左親指スティック↻"); //DEBUG用
        }
    }
}
```

### ◇ 参照
[OQtouch.IsLIndexTriggerDown](#IsRIndexTriggerDown)  
[OQtouch.LIndexTriggerDown](#LIndexTriggerDown)  
[OQtouch.LIndexTrigger](#LIndexTrigger)  

***

<a name="IsLThumbstickMove"></a>

# OQtouch.IsLThumbstickMove

### ◇ 構文
<em>oqtouch</em>.IsLThumbstickMove

### ◇ 説明
プロパティ。  
「左親指スティックを動かしている」か否かを示すブール値（読み取り専用）。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private OQtouch _oqt;
    private Console _console; //DEBUG用

    void Start() {
        _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    void Update() {
        if (_oqt.IsLThumbstickMove) {
            _console.Log("左親指スティック↻"); //DEBUG用
        }
    }
}
```

### ◇ 参照
[OQtouch.IsRThumbstickMove](#IsRThumbstickMove)  
[OQtouch.LThumbstickUpDown](#LThumbstickUpDown)  
[OQtouch.LThumbstickDownDown](#LThumbstickDownDown)  
[OQtouch.LThumbstickLeftDown](#LThumbstickLeftDown)  
[OQtouch.LThumbstickRightDown](#LThumbstickRightDown)  

***

<a name="IsRHandTriggerDown"></a>

# OQtouch.IsRHandTriggerDown

### ◇ 構文
<em>oqtouch</em>.IsRHandTriggerDown

### ◇ 説明
プロパティ。  
「右中指トリガーを押している」か否かを示すブール値（読み取り専用）。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private OQtouch _oqt;
    private Console _console; //DEBUG用

    void Start() {
        _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    void Update() {
        if (_oqt.IsRHandTriggerDown ) {
            _console.Log("右中指トリガー↓"); //DEBUG用
        }
    }
}
```

### ◇ 参照
[OQtouch.IsLHandTriggerDown](#IsLHandTriggerDown)  
[OQtouch.RHandTriggerDown](#RHandTriggerDown)  
[OQtouch.RHandTrigger](#RHandTrigger)  

***

<a name="IsRIndexTriggerDown"></a>

# OQtouch.IsRIndexTriggerDown

### ◇ 構文
<em>oqtouch</em>.IsRIndexTriggerDown

### ◇ 説明
プロパティ。  
「右人差し指トリガーを押している」か否かを示すブール値（読み取り専用）。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private OQtouch _oqt;
    private Console _console; //DEBUG用

    void Start() {
        _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    void Update() {
        if (_oqt.IsRIndexTriggerDown) {
            _console.Log("右人差し指トリガー↓"); //DEBUG用
        }
    }
}
```

### ◇ 参照
[OQtouch.IsLIndexTriggerDown](#IsLIndexTriggerDown)  
[OQtouch.RIndexTriggerDown](#RIndexTriggerDown)  

***

<a name="IsRThumbstickMove"></a>

# OQtouch.IsRThumbstickMove

### ◇ 構文
<em>oqtouch</em>.IsRThumbstickMove

### ◇ 説明
プロパティ。  
「右親指スティックを動かしている」か否かを示すブール値（読み取り専用）。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private OQtouch _oqt;
    private Console _console; //DEBUG用

    void Start() {
        _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    void Update() {
        if (_oqt.IsRThumbstickMove) {
            _console.Log("右親指スティック↻"); //DEBUG用
        }
    }
}
```

### ◇ 参照
[OQtouch.IsLThumbstickMove](#IsLThumbstickMove)  
[OQtouch.RThumbstickUpDown](#RThumbstickUpDown)  
[OQtouch.RThumbstickDownDown](#RThumbstickDownDown)  
[OQtouch.RThumbstickLeftDown](#RThumbstickLeftDown)  
[OQtouch.RThumbstickRightDown](#RThumbstickRightDown)  

***

<a name="IsVibration"></a>

# OQtouch.IsVibration

### ◇ 構文
<em>oqtouch</em>.IsVibration

### ◇ 説明
プロパティ。  
[OQtouch.LLaserOver](#LLaserOver) や [OQtouch.RLaserOver](#RLaserOver) 時のバイブレーションを有効にするか否かを示すブール値。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.EnabledLaserL = true;
        _oqt.AddTargetObject(GameObject.Find("Button1"));
        _oqt.IsVibration = false;
    }
}
```

### ◇ 参照
[OQtouch.AddTargetObject()](#AddTargetObject)  
[OQtouch.LLaserOver](#LLaserOver)  
[OQtouch.RLaserOver](#RLaserOver)  

***

<a name="L"></a>

# OQtouch.L

### ◇ 構文
<em>oqtouch</em>.L

### ◇ 説明
プロパティ。  
Oculus Touch コントローラー（左手側）の動きに連動する GameObject を指定したり、調べることができます。

### ◇ 例文
```
OQtouch _oqt = GetComponent<OQtouch>();
_oqt.L = GameObject.Find("OculusTouchL");
```

### ◇ 参照
[OQtouch.R](#R)

***

<a name="LHandTrigger"></a>

# OQtouch.LHandTrigger

### ◇ 構文
<em>oqtouch</em>.LHandTrigger

### ◇ 説明
プロパティ。  
「左中指トリガーを押しているトリガー量」（0〜1 まで小数点以下15桁表示）。読み取り専用。  
0〜100までの整数値を求める場合、Math.Round((<em>oqtouch</em>.LHandTrigger*100)) とします。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private OQtouch _oqt;
    private Console _console; //DEBUG用

    void Start() {
        _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    void Update() {
        if (_oqt.IsLHandTriggerDown ) {
            _console.Log(_oqt.LHandTrigger.ToString());
        }
    }
}
```

### ◇ 参照
[OQtouch.RHandTrigger](#RHandTrigger)  
[OQtouch.IsLHandTriggerDown](#IsLHandTriggerDown)  

***

<a name="LHandTriggerDown"></a>

# OQtouch.LHandTriggerDown

### ◇ 構文
<em>oqtouch</em>.LHandTriggerDown += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.LHandTriggerDown -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「左中指トリガーを押した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.LHandTriggerDown += LHandTriggerDownHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void LHandTriggerDownHandler() { // イベントハンドラ
        //ここに「左中指トリガーを押した時」の処理を記述
        _console.Log("左中指トリガー↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.RHandTriggerDown](#RHandTriggerDown)  
[OQtouch.LHandTriggerUp](#LHandTriggerUp)  
[OQtouch.IsLHandTriggerDown](#IsLHandTriggerDown)  

***

<a name="LHandTriggerUp"></a>

# OQtouch.LHandTriggerUp

### ◇ 構文
<em>oqtouch</em>.LHandTriggerUp += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.LHandTriggerUp -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「左中指トリガーを押した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.LHandTriggerUp += LHandTriggerUpHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void LHandTriggerUpHandler() { // イベントハンドラ
        //ここに「左中指トリガーを押した後、離した時」の処理を記述
        _console.Log("左中指トリガー↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.RHandTriggerUp](#RHandTriggerUp)  
[OQtouch.LHandTriggerDown](#LHandTriggerDown)  

***

<a name="LIndexTrigger"></a>

# OQtouch.LIndexTrigger

### ◇ 構文
<em>oqtouch</em>.LIndexTrigger

### ◇ 説明
プロパティ。  
「左人差し指トリガーを押しているトリガー量」（0〜1 まで小数点以下15桁表示）。読み取り専用。  
0〜100までの整数値を求める場合、Math.Round((<em>oqtouch</em>.LIndexTrigger*100)) とします。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour{
    private OQtouch _oqt;
    private Console _console; //DEBUG用

    void Start() {
        _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    void Update() {
        if (_oqt.IsLIndexTriggerDown) {
            _console.Log(_oqt.LIndexTrigger.ToString());
        }
    }
}

```

### ◇ 参照
[OQtouch.RIndexTrigger](#RIndexTrigger)  
[OQtouch.IsLIndexTriggerDown](#IsLIndexTriggerDown)  

***

<a name="LIndexTriggerDown"></a>

# OQtouch.LIndexTriggerDown

### ◇ 構文
<em>oqtouch</em>.LIndexTriggerDown += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.LIndexTriggerDown -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「左人差し指トリガーを押した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.LIndexTriggerDown += LIndexTriggerDownHandler; //イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void LIndexTriggerDownHandler() { //イベントハンドラ
        //ここに「左人差し指トリガーを押した時」の処理を記述
        _console.Log("左人差し指トリガー↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.RIndexTriggerDown](#RIndexTriggerDown)  
[OQtouch.LIndexTriggerUp](#LIndexTriggerUp)  
[OQtouch.IsLIndexTriggerDown](#IsLIndexTriggerDown)  

***

<a name="LIndexTriggerRawNearTouch"></a>

# OQtouch.LIndexTriggerRawNearTouch

### ◇ 構文
<em>oqtouch</em>.LIndexTriggerRawNearTouch += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.LIndexTriggerRawNearTouch -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「左人差し指トリガーに近接した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.LIndexTriggerRawNearTouch += LIndexTriggerRawNearTouchHandler; //イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void LIndexTriggerRawNearTouchHandler() { //イベントハンドラ
        //ここに「左人差し指トリガーに近接した時」の処理を記述
        _console.Log("左人差し指トリガーに近接"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.RIndexTriggerRawNearTouch](#RIndexTriggerRawNearTouch)  
[OQtouch.LIndexTriggerRawTouch ](#LIndexTriggerRawTouch)  

***

<a name="LIndexTriggerRawTouch"></a>

# OQtouch.LIndexTriggerRawTouch

### ◇ 構文
<em>oqtouch</em>.LIndexTriggerRawTouch += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.LIndexTriggerRawTouch -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「左人差し指トリガーにタッチした時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.LIndexTriggerRawTouch += LIndexTriggerRawTouchHandler; //イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void LIndexTriggerRawTouchHandler() { //イベントハンドラ
        //ここに「左人差し指トリガーにタッチした時」の処理を記述
        _console.Log("左人差し指トリガーにタッチ"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.RIndexTriggerRawTouch](#RIndexTriggerRawTouch)  
[OQtouch.LIndexTriggerRawNearTouch](#LIndexTriggerRawNearTouch)  

***

<a name="LIndexTriggerUp"></a>

# OQtouch.LIndexTriggerUp

### ◇ 構文
<em>oqtouch</em>.LIndexTriggerUp += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.LIndexTriggerUp -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「左人差し指トリガーを押した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.LIndexTriggerUp += LIndexTriggerUpHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void LIndexTriggerUpHandler() { // イベントハンドラ
        //ここに「左人差し指トリガーを押した後、離した時」の処理を記述
        _console.Log("右人差し指トリガー↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.RIndexTriggerUp](#RIndexTriggerUp)  
[OQtouch.LIndexTriggerDown](#LIndexTriggerDown)  

***

<a name="LLaserDown"></a>

# OQtouch.LLaserDown

### ◇ 構文
<em>oqtouch</em>.LLaserDown

### ◇ 説明
イベント。 
[OQtouch.AddTargetObject()](#AddTargetObject) 等で登録済みのオブジェクトを「左手側のレーザーポインタで押した時」（左人差し指トリガーを押した時）のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");

        //レーザーポインタの表示
        _oqt.EnabledLaserL = true;

        //レーザーポインタで選択するオブジェクトの登録
        _oqt.AddTargetObject(GameObject.Find("Button1"));

        //イベントハンドラの登録
        _oqt.LLaserDown += LLaserDownHandler;

        //DEBUG用
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>();
    }

    //イベントハンドラ
    private void LLaserDownHandler(GameObject arg) {
        _console.Log("左レーザーが" + arg.name + "を↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.RLaserDown](#RLaserDown)  
[OQtouch.LLaserUp](#LLaserUp)  
[OQtouch.LLaserUpOutside](#LLaserUpOutside)  
[OQtouch.LLaserOver](#LLaserOver)  
[OQtouch.LLaserOut](#LLaserOut)  
[OQtouch.AddTargetObject()](#AddTargetObject)

***

<a name="LLaserOut"></a>

# OQtouch.LLaserOut

### ◇ 構文
<em>oqtouch</em>.LLaserOut

### ◇ 説明
イベント。 
[OQtouch.AddTargetObject()](#AddTargetObject) 等で登録済みのオブジェクトから「左手側のレーザーポインタが出た時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");

        //レーザーポインタの表示
        _oqt.EnabledLaserL = true;

        //レーザーポインタで選択するオブジェクトの登録
        _oqt.AddTargetObject(GameObject.Find("Button1"));

        //イベントハンドラの登録
        _oqt.LLaserOut += LLaserOutHandler;

        //DEBUG用
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>();
    }

    //イベントハンドラ
    private void LLaserOutHandler(GameObject arg) {
        _console.Log("左レーザーが" + arg.name + "をアウト"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.RLaserOut](#RLaserOut)  
[OQtouch.LLaserOver](#LLaserOver)  
[OQtouch.LLaserDown](#LLaserDown)  
[OQtouch.LLaserUp](#LLaserUp)  
[OQtouch.LLaserUpOutside](#LLaserUpOutside)  
[OQtouch.AddTargetObject()](#AddTargetObject)  

***

<a name="LLaserOver"></a>

# OQtouch.LLaserOver

### ◇ 構文
<em>oqtouch</em>.LLaserOver

### ◇ 説明
イベント。 
[OQtouch.AddTargetObject()](#AddTargetObject) 等で登録済みのオブジェクトを「左手側のレーザーポインタでヒットした時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");

        //レーザーポインタの表示
        _oqt.EnabledLaserL = true;

        //レーザーポインタで選択するオブジェクトの登録
        _oqt.AddTargetObject(GameObject.Find("Button1"));

        //イベントハンドラの登録
        _oqt.LLaserOver += LLaserOverHandler;

        //DEBUG用
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>();
    }

    //イベントハンドラ
    private void LLaserOverHandler(GameObject arg) {
        _console.Log("左レーザーが" + arg.name + "をヒット"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.RLaserOver](#RLaserOver)  
[OQtouch.LLaserOut](#LLaserOut)  
[OQtouch.LLaserDown](#LLaserDown)  
[OQtouch.LLaserUp](#LLaserUp)  
[OQtouch.LLaserUpOutside](#LLaserUpOutside)  
[OQtouch.AddTargetObject()](#AddTargetObject)  
[OQtouch.IsVibration](#IsVibration)  

***

<a name="LLaserUp"></a>

# OQtouch.LLaserUp

### ◇ 構文
<em>oqtouch</em>.LLaserUp

### ◇ 説明
イベント。 
[OQtouch.AddTargetObject()](#AddTargetObject) 等で登録済みのオブジェクトを [OQtouch.RLaserDown](#RLaserDown) 後、「同じオブジェクトの領域で左人差し指トリガーを離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");

        //レーザーポインタの表示
        _oqt.EnabledLaserL = true;

        //レーザーポインタで選択するオブジェクトの登録
        _oqt.AddTargetObject(GameObject.Find("Button1"));

        //イベントハンドラの登録
        _oqt.LLaserUp += LLaserUpHandler;

        //DEBUG用
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>();
    }

    //イベントハンドラ
    private void LLaserUpHandler(GameObject arg) {
        _console.Log("左レーザーが" + arg.name + "を↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.RLaserUp](#RLaserUp)  
[OQtouch.LLaserDown](#LLaserDown)  
[OQtouch.LLaserUpOutside](#LLaserUpOutside)  
[OQtouch.LLaserOver](#LLaserOver)  
[OQtouch.LLaserOut](#LLaserOut)  
[OQtouch.AddTargetObject()](#AddTargetObject)

***

<a name="LLaserUpOutside"></a>

# OQtouch.LLaserUpOutside

### ◇ 構文
<em>oqtouch</em>.LLaserUpOutside

### ◇ 説明
イベント。 
[OQtouch.AddTargetObject()](#AddTargetObject) 等で登録済みのオブジェクトを [OQtouch.RLaserDown](#RLaserDown) 後、「選択したオブジェクトの領域外で左人差し指トリガーを離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");

        //レーザーポインタの表示
        _oqt.EnabledLaserL = true;

        //レーザーポインタで選択するオブジェクトの登録
        _oqt.AddTargetObject(GameObject.Find("Button1"));

        //イベントハンドラの登録
        _oqt.LLaserUpOutside += LLaserUpOutsideHandler;

        //DEBUG用
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>();
    }

    //イベントハンドラ
    private void LLaserUpOutsideHandler(GameObject arg) {
        _console.Log("左レーザーが" + arg.name + "の外で↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.RLaserUpOutside](#RLaserUpOutside)  
[OQtouch.LLaserUp](#LLaserUp)  
[OQtouch.LLaserDown](#LLaserDown)  
[OQtouch.LLaserOver](#LLaserOver)  
[OQtouch.LLaserOut](#LLaserOut)  
[OQtouch.AddTargetObject()](#AddTargetObject)

***

<a name="LThumbstickDown"></a>

# OQtouch.LThumbstickDown

### ◇ 構文
<em>oqtouch</em>.LThumbstickDown += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.LThumbstickDown -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「左親指スティックを押した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.LThumbstickDown += LThumbstickDownHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void LThumbstickDownHandler() { // イベントハンドラ
        //ここに「左親指スティックを押した時」の処理を記述
        _console.Log("左親指スティック↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.RThumbstickDown](#RThumbstickDown)  
[OQtouch.LThumbstickUp](#LThumbstickUp)  
[OQtouch.LThumbstickRawTouch](#LThumbstickRawTouch)  

***

<a name="LThumbstickDownDown"></a>

# OQtouch.LThumbstickDownDown

### ◇ 構文
<em>oqtouch</em>.LThumbstickDownDown += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.LThumbstickDownDown -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「左親指スティックを下に倒した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.LThumbstickDownDown += LThumbstickDownDownHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void LThumbstickDownDownHandler() { // イベントハンドラ
        //ここに「左親指スティックを下に倒した時」の処理を記述
        _console.Log("左親指スティックを下に↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.RThumbstickDownDown](#RThumbstickDownDown)  
[OQtouch.LThumbstickDownUp](#LThumbstickDownUp)  
[OQtouch.LThumbstickUpDown](#LThumbstickUpDown)  
[OQtouch.LThumbstickLeftDown](#LThumbstickLeftDown)  
[OQtouch.LThumbstickRightDown](#LThumbstickRightDown)  

***

<a name="LThumbstickDownUp"></a>

# OQtouch.LThumbstickDownUp

### ◇ 構文
<em>oqtouch</em>.LThumbstickDownUp += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.LThumbstickDownUp -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「左親指スティックを下に倒した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.LThumbstickDownUp += LThumbstickDownUpHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void LThumbstickDownUpHandler() { // イベントハンドラ
        //ここに「左親指スティックを下に倒した後、離した時」の処理を記述
        _console.Log("左親指スティックを下に↓の後↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.RThumbstickDownUp](#RThumbstickDownUp)  
[OQtouch.LThumbstickDownDown](#LThumbstickDownDown)  
[OQtouch.LThumbstickUpUp](#LThumbstickUpUp)  
[OQtouch.LThumbstickLeftUp](#LThumbstickLeftUp)  
[OQtouch.LThumbstickRightUp](#LThumbstickRightUp)  

***

<a name="LThumbstickLeftDown"></a>

# OQtouch.LThumbstickLeftDown

### ◇ 構文
<em>oqtouch</em>.LThumbstickLeftDown += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.LThumbstickLeftDown -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「左親指スティックを左に倒した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.LThumbstickLeftDown += LThumbstickLeftDownHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void LThumbstickLeftDownHandler() { // イベントハンドラ
        //ここに「左親指スティックを左に倒した時」の処理を記述
        _console.Log("左親指スティックを左に↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.RThumbstickLeftDown](#RThumbstickLeftDown)  
[OQtouch.LThumbstickLeftUp](#LThumbstickLeftUp)  
[OQtouch.LThumbstickUpDown](#LThumbstickUpDown)  
[OQtouch.LThumbstickDownDown](#LThumbstickDownDown)  
[OQtouch.LThumbstickRightDown](#LThumbstickRightDown)  

***

<a name="LThumbstickLeftUp"></a>

# OQtouch.LThumbstickLeftUp

### ◇ 構文
<em>oqtouch</em>.LThumbstickLeftUp += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.LThumbstickLeftUp -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「左親指スティックを左に倒した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.LThumbstickLeftUp += LThumbstickLeftUpHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void LThumbstickLeftUpHandler() { // イベントハンドラ
        //ここに「左親指スティックを左に倒した後、離した時」の処理を記述
        _console.Log("左親指スティックを左に↓の後↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.RThumbstickLeftUp](#RThumbstickLeftUp)  
[OQtouch.LThumbstickLeftDown](#LThumbstickLeftDown)  
[OQtouch.LThumbstickUpUp](#LThumbstickUpUp)  
[OQtouch.LThumbstickDownUp](#LThumbstickDownUp)  
[OQtouch.LThumbstickRightUp](#LThumbstickRightUp)  

***

<a name="LThumbstickRawTouch"></a>

# OQtouch.LThumbstickRawTouch

### ◇ 構文
<em>oqtouch</em>.LThumbstickRawTouch += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.LThumbstickRawTouch -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「左親指スティックにタッチした時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.LThumbstickRawTouch += LThumbstickRawTouchHandler; //イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void LThumbstickRawTouchHandler() { //イベントハンドラ
        //ここに「左親指スティックにタッチした時」の処理を記述
        _console.Log("左親指スティックにタッチ"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.RThumbstickRawTouch](#RThumbstickRawTouch)  
[OQtouch.LThumbstickDown](#LThumbstickDown)  

***

<a name="LThumbstickRightDown"></a>

# OQtouch.LThumbstickRightDown

### ◇ 構文
<em>oqtouch</em>.LThumbstickRightDown += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.LThumbstickRightDown -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「左親指スティックを右に倒した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.LThumbstickRightDown += LThumbstickRightDownHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void LThumbstickRightDownHandler() { // イベントハンドラ
        //ここに「左親指スティックを右に倒した時」の処理を記述
        _console.Log("左親指スティックを右に↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.RThumbstickRightDown](#RThumbstickRightDown)  
[OQtouch.LThumbstickRightUp](#LThumbstickRightUp)  
[OQtouch.LThumbstickUpDown](#LThumbstickUpDown)  
[OQtouch.LThumbstickDownDown](#LThumbstickDownDown)  
[OQtouch.LThumbstickLeftDown](#LThumbstickLeftDown)  

***

<a name="LThumbstickRightUp"></a>

# OQtouch.LThumbstickRightUp

### ◇ 構文
<em>oqtouch</em>.LThumbstickRightUp += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.LThumbstickRightUp -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「左親指スティックを右に倒した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.LThumbstickRightUp += LThumbstickRightUpHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void LThumbstickRightUpHandler() { // イベントハンドラ
        //ここに「左親指スティックを右に倒した後、離した時」の処理を記述
        _console.Log("左親指スティックを右に↓の後↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.RThumbstickRightUp](#RThumbstickRightUp)  
[OQtouch.LThumbstickRightDown](#LThumbstickRightDown)  
[OQtouch.LThumbstickUpUp](#LThumbstickUpUp)  
[OQtouch.LThumbstickDownUp](#LThumbstickDownUp)  
[OQtouch.LThumbstickLeftUp](#LThumbstickLeftUp)  

***

<a name="LThumbstickRotate"></a>

# OQtouch.LThumbstickRotate 

### ◇ 構文
<em>oqtouch</em>.LThumbstickRotate

### ◇ 説明
プロパティ。  
「左親指スティックの角度（度数法）」（読み取り専用）。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private OQtouch _oqt;
    private Console _console; //DEBUG用

    void Start() {
        _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    void Update() {
        if (_oqt.IsLThumbstickMove) { //左親指スティックを動かしている時
            _console.Log(_oqt.LThumbstickRotate.ToString());
        }
    }
}
```

### ◇ 参照
[OQtouch.RThumbstickRotate](#RThumbstickRotate)  
[OQtouch.IsLThumbstickMove](#IsLThumbstickMove)  

***

<a name="LThumbstickUp"></a>

# OQtouch.LThumbstickUp

### ◇ 構文
<em>oqtouch</em>.LThumbstickUp += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.LThumbstickUp -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「左親指スティックを押した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.LThumbstickUp += LThumbstickUpHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void LThumbstickUpHandler() { // イベントハンドラ
        //ここに「左親指スティックを押した後、離した時」の処理を記述
        _console.Log("左親指スティック↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.RThumbstickUp](#RThumbstickUp)  
[OQtouch.LThumbstickDown](#LThumbstickDown)  

***

<a name="LThumbstickUpDown"></a>

# OQtouch.LThumbstickUpDown

### ◇ 構文
<em>oqtouch</em>.LThumbstickUpDown += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.LThumbstickUpDown -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「左親指スティックを上に倒した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.LThumbstickUpDown += LThumbstickUpDownHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void LThumbstickUpDownHandler() { // イベントハンドラ
        //ここに「左親指スティックを上に倒した時」の処理を記述
        _console.Log("左親指スティックを上に↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.RThumbstickUpDown](#RThumbstickUpDown)  
[OQtouch.LThumbstickUpUp](#LThumbstickUpUp)  
[OQtouch.LThumbstickDownDown](#LThumbstickDownDown)  
[OQtouch.LThumbstickLeftDown](#LThumbstickLeftDown)  
[OQtouch.LThumbstickRightDown](#LThumbstickRightDown)  

***

<a name="LThumbstickUpUp"></a>

# OQtouch.LThumbstickUpUp

### ◇ 構文
<em>oqtouch</em>.LThumbstickUpUp += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.LThumbstickUpUp -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「左親指スティックを上に倒した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.LThumbstickUpUp += LThumbstickUpUpHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void LThumbstickUpUpHandler() { // イベントハンドラ
        //ここに「左親指スティックを上に倒した後、離した時」の処理を記述
        _console.Log("左親指スティックを上に↓の後↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.RThumbstickUpUp](#RThumbstickUpUp)  
[OQtouch.LThumbstickUpDown](#LThumbstickUpDown)  
[OQtouch.LThumbstickDownUp](#LThumbstickDownUp)  
[OQtouch.LThumbstickLeftUp](#LThumbstickLeftUp)  
[OQtouch.LThumbstickRightUp](#LThumbstickRightUp)  

***

<a name="R"></a>

# OQtouch.R

### ◇ 構文
<em>oqtouch</em>.R

### ◇ 説明
プロパティ。  
Oculus Touch コントローラー（右手側）の動きに連動する GameObject を指定したり、調べることができます。

### ◇ 例文
```
OQtouch _oqt = GetComponent<OQtouch>();
_oqt.R = GameObject.Find("OculusTouchR");
```

### ◇ 参照
[OQtouch.L](#L)

***

<a name="RemoveTargetObject"></a>

# OQtouch.RemoveTargetObject()

### ◇ 構文
<em>oqtouch</em>.RemoveTargetObject(<em>someGameObject</em>)

### ◇ 説明
メソッド。  
右、もしくは左手側のレーザーポインタに反応させるオブジェクトを削除します。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private OQtouch _oqt;
    private Console _console; //DEBUG用

    void Start() {
        _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.EnabledLaserL = true;

        //レーザーポインタで選択するオブジェクトの登録
        _oqt.AddTargetObject(GameObject.Find("Button1"));
        _oqt.AddTargetObject(GameObject.Find("Button2"));
        _oqt.AddTargetObject(GameObject.Find("Button3"));

        _oqt.LLaserDown += LLaserDownHandler;

        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>();
    }

    private void LLaserDownHandler(GameObject arg) {
        _console.Log("左レーザーが" + arg.name + "を↓");
        _oqt.RemoveTargetObject(arg); //一度選択したものは選べなくする場合
    }
}
```

### ◇ 参照
[OQtouch.AddTargetObject()](#AddTargetObject)  
[OQtouch.TargetObjects](#TargetObjects)  

***

<a name="RHandTrigger"></a>

# OQtouch.RHandTrigger

### ◇ 構文
<em>oqtouch</em>.RHandTrigger

### ◇ 説明
プロパティ。  
「右中指トリガーを押しているトリガー量」（0〜1 まで小数点以下15桁表示）。読み取り専用。  
0〜100までの整数値を求める場合、Math.Round((<em>oqtouch</em>.RHandTrigger*100)) とします。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private OQtouch _oqt;
    private Console _console; //DEBUG用

    void Start() {
        _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    void Update() {
        if (_oqt.IsRHandTriggerDown ) {
            _console.Log(_oqt.RHandTrigger.ToString());
        }
    }
}
```

### ◇ 参照
[OQtouch.LHandTrigger](#LHandTrigger)  
[OQtouch.IsRHandTriggerDown](#IsRHandTriggerDown)  

***

<a name="RHandTriggerDown"></a>

# OQtouch.RHandTriggerDown

### ◇ 構文
<em>oqtouch</em>.RHandTriggerDown += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.RHandTriggerDown -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「右中指トリガーを押した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _oqt.RHandTriggerDown += RHandTriggerDownHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void RHandTriggerDownHandler() { // イベントハンドラ
        //ここに「右中指トリガーを押した時」の処理を記述
        _console.Log("右中指トリガー↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.LHandTriggerDown](#LHandTriggerDown)  
[OQtouch.RHandTriggerUp](#RHandTriggerUp)  
[OQtouch.IsRHandTriggerDown](#IsRHandTriggerDown)  

***

<a name="RHandTriggerUp"></a>

# OQtouch.RHandTriggerUp

### ◇ 構文
<em>oqtouch</em>.RHandTriggerUp += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.RHandTriggerUp -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「右中指トリガーを押した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _oqt.RHandTriggerUp += RHandTriggerUpHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void RHandTriggerUpHandler() { // イベントハンドラ
        //ここに「右中指トリガーを押した後、離した時」の処理を記述
        _console.Log("右中指トリガー↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.LHandTriggerUp](#LHandTriggerUp)  
[OQtouch.RHandTriggerDown](#RHandTriggerDown)  

***

<a name="RIndexTrigger"></a>

# OQtouch.RIndexTrigger

### ◇ 構文
<em>oqtouch</em>.RIndexTrigger

### ◇ 説明
プロパティ。  
「右人差し指トリガーを押しているトリガー量」（0〜1 まで小数点以下15桁表示）。読み取り専用。  
0〜100までの整数値を求める場合、Math.Round((<em>oqtouch</em>.RIndexTrigger*100)) とします。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour{
    private OQtouch _oqt;
    private Console _console; //DEBUG用

    void Start() {
        _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    void Update() {
        if (_oqt.IsRIndexTriggerDown) {
            _console.Log(_oqt.RIndexTrigger.ToString());
        }
    }
}
```

### ◇ 参照
[OQtouch.LIndexTrigger](#LIndexTrigger)  
[OQtouch.IsRIndexTriggerDown](#IsRIndexTriggerDown)  

***

<a name="RIndexTriggerDown"></a>

# OQtouch.RIndexTriggerDown

### ◇ 構文
<em>oqtouch</em>.RIndexTriggerDown += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.RIndexTriggerDown -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「右人差し指トリガーを押した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _oqt.RIndexTriggerDown += RIndexTriggerDownHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void RIndexTriggerDownHandler() { // イベントハンドラ
        //ここに「右人差し指トリガーを押した時」の処理を記述
        _console.Log("右人差し指トリガー↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.LIndexTriggerDown](#LIndexTriggerDown)  
[OQtouch.RIndexTriggerUp](#RIndexTriggerUp)  
[OQtouch.IsRIndexTriggerDown](#IsRIndexTriggerDown)  

***

<a name="RIndexTriggerRawNearTouch"></a>

# OQtouch.RIndexTriggerRawNearTouch

### ◇ 構文
<em>oqtouch</em>.RIndexTriggerRawNearTouch += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.RIndexTriggerRawNearTouch -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「右人差し指トリガーに近接した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _oqt.RIndexTriggerRawNearTouch += RIndexTriggerRawNearTouchHandler; //イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void RIndexTriggerRawNearTouchHandler() { //イベントハンドラ
        //ここに「右人差し指トリガーに近接した時」の処理を記述
        _console.Log("右人差し指トリガーに近接"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.LIndexTriggerRawNearTouch](#LIndexTriggerRawNearTouch)  
[OQtouch.RIndexTriggerRawTouch ](#RIndexTriggerRawTouch)  

***

<a name="RIndexTriggerRawTouch"></a>

# OQtouch.RIndexTriggerRawTouch

### ◇ 構文
<em>oqtouch</em>.RIndexTriggerRawTouch += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.RIndexTriggerRawTouch -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「右人差し指トリガーにタッチした時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _oqt.RIndexTriggerRawTouch += RIndexTriggerRawTouchHandler; //イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void RIndexTriggerRawTouchHandler() { //イベントハンドラ
        //ここに「右人差し指トリガーにタッチした時」の処理を記述
        _console.Log("右人差し指トリガーにタッチ"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.LIndexTriggerRawTouch](#LIndexTriggerRawTouch)  
[OQtouch.RIndexTriggerRawNearTouch](#RIndexTriggerRawNearTouch)  

***

<a name="RIndexTriggerUp"></a>

# OQtouch.RIndexTriggerUp

### ◇ 構文
<em>oqtouch</em>.RIndexTriggerUp += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.RIndexTriggerUp -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「右人差し指トリガーを押した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _oqt.RIndexTriggerUp += RIndexTriggerUpHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void RIndexTriggerUpHandler() { // イベントハンドラ
        //ここに「右人差し指トリガーを押した後、離した時」の処理を記述
        _console.Log("右人差し指トリガー↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.LIndexTriggerUp](#LIndexTriggerUp)  
[OQtouch.RIndexTriggerDown](#RIndexTriggerDown)  

***

<a name="RLaserDown"></a>

# OQtouch.RLaserDown

### ◇ 構文
<em>oqtouch</em>.RLaserDown

### ◇ 説明
イベント。 
[OQtouch.AddTargetObject()](#AddTargetObject) 等で登録済みのオブジェクトを「右手側のレーザーポインタで押した時」（右人差し指トリガーを押した時）のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");

        //レーザーポインタの表示
        _oqt.EnabledLaserR = true;

        //レーザーポインタで選択するオブジェクトの登録
        _oqt.AddTargetObject(GameObject.Find("Button1"));

        //イベントハンドラの登録
        _oqt.RLaserDown += RLaserDownHandler;

        //DEBUG用
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>();
    }

    //イベントハンドラ
    private void RLaserDownHandler(GameObject arg) {
        _console.Log("右レーザーが" + arg.name + "を↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.LLaserDown](#LLaserDown)  
[OQtouch.RLaserUp](#RLaserUp)  
[OQtouch.RLaserUpOutside](#RLaserUpOutside)  
[OQtouch.RLaserOver](#RLaserOver)  
[OQtouch.RLaserOut](#RLaserOut)  
[OQtouch.AddTargetObject()](#AddTargetObject)

***

<a name="RLaserOut"></a>

# OQtouch.RLaserOut

### ◇ 構文
<em>oqtouch</em>.RLaserOut

### ◇ 説明
イベント。 
[OQtouch.AddTargetObject()](#AddTargetObject) 等で登録済みのオブジェクトから「右手側のレーザーポインタがアウトした（領域から出た）時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");

        //レーザーポインタの表示
        _oqt.EnabledLaserL = true;
        _oqt.EnabledLaserR = true;

        //レーザーポインタで選択するオブジェクトの登録
        _oqt.AddTargetObject(GameObject.Find("Button1"));

        //イベントハンドラの登録
        _oqt.RLaserOut += RLaserOutHandler;

        //DEBUG用
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>();
    }

    //イベントハンドラ
    private void RLaserOutHandler(GameObject arg) {
        _console.Log("右レーザーが" + arg.name + "をアウト"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.LLaserOut](#LLaserOut)  
[OQtouch.RLaserOver](#RLaserOver)  
[OQtouch.RLaserDown](#RLaserDown)  
[OQtouch.RLaserUp](#RLaserUp)  
[OQtouch.RLaserUpOutside](#RLaserUpOutside)  
[OQtouch.AddTargetObject()](#AddTargetObject)

***

<a name="RLaserOver"></a>

# OQtouch.RLaserOver

### ◇ 構文
<em>oqtouch</em>.RLaserOver

### ◇ 説明
イベント。 
[OQtouch.AddTargetObject()](#AddTargetObject) 等で登録済みのオブジェクトを「右手側のレーザーポインタでヒット」した時のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");

        //レーザーポインタの表示
        _oqt.EnabledLaserL = true;
        _oqt.EnabledLaserR = true;

        //レーザーポインタで選択するオブジェクトの登録
        _oqt.AddTargetObject(GameObject.Find("Button1"));

        //イベントハンドラの登録
        _oqt.RLaserOver += RLaserOverHandler;

        //DEBUG用
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>();
    }

    //イベントハンドラ
    private void RLaserOverHandler(GameObject arg) {
        _console.Log("右レーザーが" + arg.name + "をヒット"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.LLaserOver](#LLaserOver)  
[OQtouch.RLaserOut](#RLaserOut)  
[OQtouch.RLaserDown](#RLaserDown)  
[OQtouch.RLaserUp](#RLaserUp)  
[OQtouch.RLaserUpOutside](#RLaserUpOutside)  
[OQtouch.AddTargetObject()](#AddTargetObject)  
[OQtouch.IsVibration](#IsVibration)  

***

<a name="RLaserUp"></a>

# OQtouch.RLaserUp

### ◇ 構文
<em>oqtouch</em>.RLaserUp

### ◇ 説明
イベント。 
[OQtouch.AddTargetObject()](#AddTargetObject) 等で登録済みのオブジェクトを [OQtouch.RLaserDown](#RLaserDown) 後、「同じオブジェクトの領域で右人差し指トリガーを離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");

        //レーザーポインタの表示
        _oqt.EnabledLaserL = true;
        _oqt.EnabledLaserR = true;

        //レーザーポインタで選択するオブジェクトの登録
        _oqt.AddTargetObject(GameObject.Find("Button1"));

        //イベントハンドラの登録
        _oqt.RLaserUp += RLaserUpHandler;

        //DEBUG用
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>();
    }

    //イベントハンドラ
    private void RLaserUpHandler(GameObject arg) {
        _console.Log("右レーザーが" + arg.name + "を↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.LLaserUp](#LLaserUp)  
[OQtouch.RLaserDown](#RLaserDown)  
[OQtouch.RLaserUpOutside](#RLaserUpOutside)  
[OQtouch.RLaserOver](#RLaserOver)  
[OQtouch.RLaserOut](#RLaserOut)  
[OQtouch.AddTargetObject()](#AddTargetObject)

***

<a name="RLaserUpOutside"></a>

# OQtouch.RLaserUpOutside

### ◇ 構文
<em>oqtouch</em>.RLaserUpOutside

### ◇ 説明
イベント。 
[OQtouch.AddTargetObject()](#AddTargetObject) 等で登録済みのオブジェクトを [OQtouch.RLaserDown](#RLaserDown) 後、「選択したオブジェクトの領域外で右人差し指トリガーを離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchL");

        //レーザーポインタの表示
        _oqt.EnabledLaserL = true;
        _oqt.EnabledLaserR = true;

        //レーザーポインタで選択するオブジェクトの登録
        _oqt.AddTargetObject(GameObject.Find("Button1"));

        //イベントハンドラの登録
        _oqt.RLaserUpOutside += RLaserUpOutsideHandler;

        //DEBUG用
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>();
    }

    //イベントハンドラ
    private void RLaserUpOutsideHandler(GameObject arg) {
        _console.Log("右レーザーが" + arg.name + "の外で↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.LLaserUpOutside](#LLaserUpOutside)  
[OQtouch.RLaserUp](#RLaserUp)  
[OQtouch.RLaserDown](#RLaserDown)  
[OQtouch.RLaserOver](#RLaserOver)  
[OQtouch.RLaserOut](#RLaserOut)  
[OQtouch.AddTargetObject()](#AddTargetObject)

***

<a name="RThumbstickDown"></a>

# OQtouch.RThumbstickDown

### ◇ 構文
<em>oqtouch</em>.RThumbstickDown += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.RThumbstickDown -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「右親指スティックを押した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _oqt.RThumbstickDown += RThumbstickDownHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void RThumbstickDownHandler() { // イベントハンドラ
        //ここに「右親指スティックを押した時」の処理を記述
        _console.Log("右親指スティック↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.LThumbstickDown](#LThumbstickDown)  
[OQtouch.RThumbstickUp](#RThumbstickUp)  
[OQtouch.RThumbstickRawTouch](#RThumbstickRawTouch)  

***

<a name="RThumbstickDownDown"></a>

# OQtouch.RThumbstickDownDown

### ◇ 構文
<em>oqtouch</em>.RThumbstickDownDown += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.RThumbstickDownDown -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「右親指スティックを下に倒した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _oqt.RThumbstickDownDown += RThumbstickDownDownHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void RThumbstickDownDownHandler() { // イベントハンドラ
        //ここに「右親指スティックを下に倒した時」の処理を記述
        _console.Log("右親指スティックを下に↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.LThumbstickDownDown](#LThumbstickDownDown)  
[OQtouch.RThumbstickDownUp](#RThumbstickDownUp)  
[OQtouch.RThumbstickUpDown](#RThumbstickUpDown)  
[OQtouch.RThumbstickLeftDown](#RThumbstickLeftDown)  
[OQtouch.RThumbstickRightDown](#RThumbstickRightDown)  

***

<a name="RThumbstickDownUp"></a>

# OQtouch.RThumbstickDownUp

### ◇ 構文
<em>oqtouch</em>.RThumbstickDownUp += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.RThumbstickDownUp -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「右親指スティックを下に倒した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _oqt.RThumbstickDownUp += RThumbstickDownUpHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void RThumbstickDownUpHandler() { // イベントハンドラ
        //ここに「右親指スティックを下に倒した後、離した時」の処理を記述
        _console.Log("右親指スティックを下に↓の後↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.LThumbstickDownUp](#LThumbstickDownUp)  
[OQtouch.RThumbstickDownDown](#RThumbstickDownDown)  
[OQtouch.RThumbstickUpUp](#RThumbstickUpUp)  
[OQtouch.RThumbstickLeftUp](#RThumbstickLeftUp)  
[OQtouch.RThumbstickRightUp](#RThumbstickRightUp)  

***

<a name="RThumbstickLeftDown"></a>

# OQtouch.RThumbstickLeftDown

### ◇ 構文
<em>oqtouch</em>.RThumbstickLeftDown += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.RThumbstickLeftDown -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「右親指スティックを左に倒した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _oqt.RThumbstickLeftDown += RThumbstickLeftDownHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void RThumbstickLeftDownHandler() { // イベントハンドラ
        //ここに「右親指スティックを左に倒した時」の処理を記述
        _console.Log("右親指スティックを左に↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.LThumbstickLeftDown](#LThumbstickLeftDown)  
[OQtouch.RThumbstickLeftUp](#RThumbstickLeftUp)  
[OQtouch.RThumbstickUpDown](#RThumbstickUpDown)  
[OQtouch.RThumbstickDownDown](#RThumbstickDownDown)  
[OQtouch.RThumbstickRightDown](#RThumbstickRightDown)  

***

<a name="RThumbstickLeftUp"></a>

# OQtouch.RThumbstickLeftUp

### ◇ 構文
<em>oqtouch</em>.RThumbstickLeftUp += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.RThumbstickLeftUp -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「右親指スティックを左に倒した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _oqt.RThumbstickLeftUp += RThumbstickLeftUpHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void RThumbstickLeftUpHandler() { // イベントハンドラ
        //ここに「右親指スティックを左に倒した後、離した時」の処理を記述
        _console.Log("右親指スティックを左に↓の後↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.LThumbstickLeftUp](#LThumbstickLeftUp)  
[OQtouch.RThumbstickLeftDown](#RThumbstickLeftDown)  
[OQtouch.RThumbstickUpUp](#RThumbstickUpUp)  
[OQtouch.RThumbstickDownUp](#RThumbstickDownUp)  
[OQtouch.RThumbstickRightUp](#RThumbstickRightUp)  

***

<a name="RThumbstickRawTouch"></a>

# OQtouch.RThumbstickRawTouch

### ◇ 構文
<em>oqtouch</em>.RThumbstickRawTouch += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.RThumbstickRawTouch -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「右親指スティックにタッチした時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _oqt.RThumbstickRawTouch += RThumbstickRawTouchHandler; //イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void RThumbstickRawTouchHandler() { //イベントハンドラ
        //ここに「右親指スティックにタッチした時」の処理を記述
        _console.Log("右親指スティックにタッチ"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.LThumbstickRawTouch](#LThumbstickRawTouch)  
[OQtouch.RThumbstickDown](#RThumbstickDown)  

***

<a name="RThumbstickRightDown"></a>

# OQtouch.RThumbstickRightDown

### ◇ 構文
<em>oqtouch</em>.RThumbstickRightDown += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.RThumbstickRightDown -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「右親指スティックを右に倒した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _oqt.RThumbstickRightDown += RThumbstickRightDownHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void RThumbstickRightDownHandler() { // イベントハンドラ
        //ここに「右親指スティックを右に倒した時」の処理を記述
        _console.Log("右親指スティックを右に↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.LThumbstickRightDown](#LThumbstickRightDown)  
[OQtouch.RThumbstickRightUp](#RThumbstickRightUp)  
[OQtouch.RThumbstickUpDown](#RThumbstickUpDown)  
[OQtouch.RThumbstickDownDown](#RThumbstickDownDown)  
[OQtouch.RThumbstickLeftDown](#RThumbstickLeftDown)  

***

<a name="RThumbstickRightUp"></a>

# OQtouch.RThumbstickRightUp

### ◇ 構文
<em>oqtouch</em>.RThumbstickRightUp += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.RThumbstickRightUp -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「右親指スティックを右に倒した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _oqt.RThumbstickRightUp += RThumbstickRightUpHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void RThumbstickRightUpHandler() { // イベントハンドラ
        //ここに「右親指スティックを右に倒した後、離した時」の処理を記述
        _console.Log("右親指スティックを右に↓の後↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.LThumbstickRightUp](#LThumbstickRightUp)  
[OQtouch.RThumbstickRightDown](#RThumbstickRightDown)  
[OQtouch.RThumbstickUpUp](#RThumbstickUpUp)  
[OQtouch.RThumbstickDownUp](#RThumbstickDownUp)  
[OQtouch.RThumbstickLeftUp](#RThumbstickLeftUp)  

***

<a name="RThumbstickRotate"></a>

# OQtouch.RThumbstickRotate 

### ◇ 構文
<em>oqtouch</em>.RThumbstickRotate

### ◇ 説明
プロパティ。  
「右親指スティックの角度（度数法）」（読み取り専用）。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private OQtouch _oqt;
    private Console _console; //DEBUG用

    void Start() {
        _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    void Update() {
        if (_oqt.IsRThumbstickMove) { //右親指スティックを動かしている時
            _console.Log(_oqt.RThumbstickRotate.ToString());
        }
    }
}
```

### ◇ 参照
[OQtouch.LThumbstickRotate](#LThumbstickRotate)  
[OQtouch.IsRThumbstickMove](#IsRThumbstickMove)  

***

<a name="RThumbstickUp"></a>

# OQtouch.RThumbstickUp

### ◇ 構文
<em>oqtouch</em>.RThumbstickUp += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.RThumbstickUp -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「右親指スティックを押した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _oqt.RThumbstickUp += RThumbstickUpHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void RThumbstickUpHandler() { // イベントハンドラ
        //ここに「右親指スティックを押した後、離した時」の処理を記述
        _console.Log("右親指スティック↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.LThumbstickUp](#LThumbstickUp)  
[OQtouch.RThumbstickDown](#RThumbstickDown)  

***

<a name="RThumbstickUpDown"></a>

# OQtouch.RThumbstickUpDown

### ◇ 構文
<em>oqtouch</em>.RThumbstickUpDown += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.RThumbstickUpDown -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「右親指スティックを上に倒した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _oqt.RThumbstickUpDown += RThumbstickUpDownHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void RThumbstickUpDownHandler() { // イベントハンドラ
        //ここに「右親指スティックを上に倒した時」の処理を記述
        _console.Log("右親指スティックを上に↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.LThumbstickUpDown](#LThumbstickUpDown)  
[OQtouch.RThumbstickUpUp](#RThumbstickUpUp)  
[OQtouch.RThumbstickDownDown](#RThumbstickDownDown)  
[OQtouch.RThumbstickLeftDown](#RThumbstickLeftDown)  
[OQtouch.RThumbstickRightDown](#RThumbstickRightDown)  

***

<a name="RThumbstickUpUp"></a>

# OQtouch.RThumbstickUpUp

### ◇ 構文
<em>oqtouch</em>.RThumbstickUpUp += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.RThumbstickUpUp -= <em>SomeMethodHandler</em>

### ◇ 説明
イベント。  
「右親指スティックを上に倒した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.R = GameObject.Find("OculusTouchR");
        _oqt.RThumbstickUpUp += RThumbstickUpUpHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void RThumbstickUpUpHandler() { // イベントハンドラ
        //ここに「右親指スティックを上に倒した後、離した時」の処理を記述
        _console.Log("右親指スティックを上に↓の後↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.LThumbstickUpUp](#LThumbstickUpUp)  
[OQtouch.RThumbstickUpDown](#RThumbstickUpDown)  
[OQtouch.RThumbstickDownUp](#RThumbstickDownUp)  
[OQtouch.RThumbstickLeftUp](#RThumbstickLeftUp)  
[OQtouch.RThumbstickRightUp](#RThumbstickRightUp)  

***

<a name="StartDown"></a>

# OQtouch.StartDown

### ◇ 構文
<em>oqtouch</em>.StartDown += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.StartDown -= <em>SomeMethodHandler</em>

### ◇ 説明
「メニューボタン（Xボタンの下）を押した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.StartDown += StartDownHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void StartDownHandler() { // イベントハンドラ
        //ここに「メニューボタンを押した時」の処理を記述
        _console.Log("メニューボタン↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.StartUp](#StartUp)  

***

<a name="StartUp"></a>

# OQtouch.StartUp

### ◇ 構文
<em>oqtouch</em>.StartUp += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.StartUp -= <em>SomeMethodHandler</em>

### ◇ 説明
「メニューボタン（Xボタンの下）を押した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.StartUp += StartUpHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void StartUpHandler() { // イベントハンドラ
        //ここに「メニューボタンを押した後、離した時」の処理を記述
        _console.Log("メニューボタン↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.StartDown](#StartDown)  

***

<a name="TargetObjects"></a>

# OQtouch.TargetObjects

### ◇ 構文
<em>oqtouch</em>.TargetObjects

### ◇ 説明
プロパティ。  
左、もしくは右手側のレーザーポインタに反応させるオブジェクト（GameObject）のリスト。  
登録するには次の２つの方法があります。  
① [OQtouch.AddTargetObject()](#AddTargetObject) を使う  
② [OQtouch.TargetObjects](#TargetObjects) プロパティに[動的配列](https://github.com/mubirou/HelloWorld/blob/master/languages/C%23Unity/C%23Unity_reference.md#%E5%8B%95%E7%9A%84%E9%85%8D%E5%88%97%EF%BC%88List%EF%BC%89) を代入する  

### ◇ 例文（一つずつ登録する方法）
```
OQtouch _oqt = GetComponent<OQtouch>();

//一つずつ登録する場合
_oqt.AddTargetObject(GameObject.Find("Button1"));
_oqt.AddTargetObject(GameObject.Find("Button2"));
_oqt.AddTargetObject(GameObject.Find("Button3"));

foreach (GameObject value in _oqt.TargetObjects) {
    Debug.Log(value.name); //"Button1"→"Button2"→"Button3"
}
```

### ◇ 例文（一度に複数登録する方法）
```
OQtouch _oqt = GetComponent<OQtouch>();

// 一度に複数のオブジェクトを登録する場合
_oqt.TargetObjects = new System.Collections.Generic.List<GameObject>() {
    GameObject.Find("Button1"),
    GameObject.Find("Button2"),
    GameObject.Find("Button3")
};

foreach (GameObject value in _oqt.TargetObjects) {
    Debug.Log(value.name); //"Button1"→"Button2"→"Button3"
}
```

### ◇ 参照
[OQtouch.AddTargetObject()](#AddTargetObject)  
[OQtouch.RemoveTargetObject()](#RemoveTargetObject)  
[動的配列](https://github.com/mubirou/HelloWorld/blob/master/languages/C%23Unity/C%23Unity_reference.md#%E5%8B%95%E7%9A%84%E9%85%8D%E5%88%97%EF%BC%88List%EF%BC%89)  

***


<a name="XDown"></a>

# OQtouch.XDown

### ◇ 構文
<em>oqtouch</em>.XDown += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.XDown -= <em>SomeMethodHandler</em>

### ◇ 説明
「Xボタンを押した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.XDown += XDownHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void XDownHandler() { // イベントハンドラ
        //ここに「Xボタンを押した時」の処理を記述
        _console.Log("Xボタン↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.XUp](#XUp)  
[OQtouch.XRawTouch](#XRawTouch)  

***

<a name="XRawTouch"></a>

# OQtouch.XRawTouch

### ◇ 構文
<em>oqtouch</em>.XRawTouch += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.XRawTouch -= <em>SomeMethodHandler</em>

### ◇ 説明
「Xボタンに触れた時」（触れている間ではなく、最初に触れた瞬間）のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.XRawTouch += XRawTouchHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void XRawTouchHandler() { // イベントハンドラ
        //ここに「Xボタンに触れた時」の処理を記述
        _console.Log("Xボタンにタッチ"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.XDown](#XDown)  
[OQtouch.XUp](#XUp)  

***

<a name="XUp"></a>

# OQtouch.XUp

### ◇ 構文
<em>oqtouch</em>.XUp += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.XUp -= <em>SomeMethodHandler</em>

### ◇ 説明
「Xボタンを押した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.XUp += XUpHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void XUpHandler() { // イベントハンドラ
        //ここに「Xボタンを押した後、離した時」の処理を記述
        _console.Log("Xボタン↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.XDown](#XDown)  
[OQtouch.XRawTouch](#XRawTouch)  

***

<a name="YDown"></a>

# OQtouch.YDown

### ◇ 構文
<em>oqtouch</em>.YDown += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.YDown -= <em>SomeMethodHandler</em>

### ◇ 説明
「Yボタンを押した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.YDown += YDownHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void YDownHandler() { // イベントハンドラ
        //ここに「Yボタンを押した時」の処理を記述
        _console.Log("Yボタン↓"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.YUp](#YUp)  
[OQtouch.YRawTouch](#YRawTouch)  

***

<a name="YRawTouch"></a>

# OQtouch.YRawTouch

### ◇ 構文
<em>oqtouch</em>.YRawTouch += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.YRawTouch -= <em>SomeMethodHandler</em>

### ◇ 説明
「Yボタンに触れた時」（触れている間ではなく、最初に触れた瞬間）のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.YRawTouch += YRawTouchHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void YRawTouchHandler() { // イベントハンドラ
        //ここに「Yボタンに触れた時」の処理を記述
        _console.Log("Yボタンにタッチ"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.YDown](#YDown)  
[OQtouch.YUp](#YUp)  

***

<a name="YUp"></a>

# OQtouch.YUp

### ◇ 構文
<em>oqtouch</em>.YUp += <em>SomeMethodHandler</em>  
<em>oqtouch</em>.YUp -= <em>SomeMethodHandler</em>

### ◇ 説明
「Yボタンを押した後、離した時」のイベントハンドラの登録や削除を行うことができます。

### ◇ 例文
```
//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Console _console; //DEBUG用

    void Start() {
        OQtouch _oqt = GetComponent<OQtouch>();
        _oqt.L = GameObject.Find("OculusTouchL");
        _oqt.YUp += YUpHandler; // イベントハンドラの登録
        _console = _oqt.L.transform.Find("Console").gameObject.GetComponent<Console>(); //DEBUG用
    }

    private void YUpHandler() { // イベントハンドラ
        //ここに「Yボタンを押した後、離した時」の処理を記述
        _console.Log("Yボタン↑"); //DEBUG用
    }
}
```

### ◇ 参照
[OQtouch.YDown](#YDown)  
[OQtouch.YRawTouch](#YRawTouch)  